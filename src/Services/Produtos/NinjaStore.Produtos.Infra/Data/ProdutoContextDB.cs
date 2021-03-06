using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using NinjaStore.Core.Data;
using NinjaStore.Core.Extensions;
using NinjaStore.Core.Helpers;
using NinjaStore.Core.Mediator;
using NinjaStore.Core.Messages.CommonMessages ;
using NinjaStore.Produtos.Domain;
using NinjaStore.Produtos.Domain.FlatModel;
using Rebus.Bus;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaStore.Produtos.Infra.Data
{
    public class ProdutoContextDB : DbContext, IUnitOfWorks
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IBus _bus;

        public DbSet<Produto> Produtos { get; set; }      


        public ProdutoContextDB(DbContextOptions<ProdutoContextDB> options, 
                  IMediatorHandler mediatorHandler, IBus bus)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
            _bus = bus;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();
            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoContextDB).Assembly);

            modelBuilder.Ignore<ProdutoFlat>();
        }

        public async Task<bool> Commit()
        {
            var cetZone = ZonaDeTempo.ObterZonaDeTempo();

            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataDeCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataDeCadastro").CurrentValue =
                        TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
                    entry.Property("DataDeAlteracao").CurrentValue =
                        entry.Property("DataDeCadastro").CurrentValue;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataDeCadastro").IsModified = false;
                    entry.Property("DataDeAlteracao").CurrentValue =
                        TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
                }
            }    

            var sucesso = await SaveChangesAsync() > 0;
            if (sucesso)
            {
                await _mediatorHandler.PublicarEventosDeDominio(this);
                await _bus.EnfileirarEventos(this);
            }

            return sucesso;
          
        }
    }
}

﻿using CondominioApp.Core.Data;
using CondominioApp.Portaria.Domain;
using CondominioApp.Portaria.Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace CondominioApp.Portaria.Domain.Interfaces
{
    public interface IPortariaRepository : IRepository<Visitante>
    {
        Task<bool> VisitanteJaCadastradoPorDocumento(string documento, Guid visitanteId);
        
        Task<Visitante> ObterPorIdAsNoTracking(Guid Id);

        void AdicionarVisita(Visita entity);

        void AtualizarVisita(Visita entity);

        void ApagarVisita(Func<Visita, bool> predicate);

        Task<Visita> ObterVisitaPorId(Guid id);

    }
}

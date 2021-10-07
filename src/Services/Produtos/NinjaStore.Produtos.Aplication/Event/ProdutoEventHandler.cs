﻿using MediatR;
using NinjaStore.Core.Messages;
using NinjaStore.Produtos.Domain.FlatModel;
using NinjaStore.Produtos.Domain.Interfaces;
using Rebus.Handlers;
using System.Threading;
using System.Threading.Tasks;

namespace NinjaStore.Produtos.Aplication.Events
{
    public class ProdutoEventHandler : CommandHandler,
         IHandleMessages<ProdutoAdicionadoEvent>,
         System.IDisposable
    {

        private readonly IProdutoQueryRepository _produtoQueryRepository;

        public ProdutoEventHandler(IProdutoQueryRepository produtoQueryRepository)
        {
            _produtoQueryRepository = produtoQueryRepository;
        }


        public async Task Handle(ProdutoAdicionadoEvent notification)
        {
            var produtoFlat = new ProdutoFlat
                (notification.Id, notification.Descricao, notification.Valor, notification.Foto);
           
            _produtoQueryRepository.Adicionar(produtoFlat);
           
            await PersistirDados(_produtoQueryRepository.UnitOfWork);
        }
               

        public void Dispose()
        {
            _produtoQueryRepository?.Dispose();
        }

    }
}

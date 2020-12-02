﻿using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Principal.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Principal.Aplication.Events
{
    public class GrupoEventHandler : EventHandler,
        INotificationHandler<GrupoCadastradoEvent>,
        INotificationHandler<GrupoEditadoEvent>,
        INotificationHandler<GrupoRemovidoEvent>,
        System.IDisposable
    {
        private ICondominioQueryRepository _condominioQueryRepository;

        public GrupoEventHandler(ICondominioQueryRepository condominioQueryRepository)
        {
            _condominioQueryRepository = condominioQueryRepository;
        }
       

        public async Task Handle(GrupoCadastradoEvent notification, CancellationToken cancellationToken)
        {
            var grupoFlat = new GrupoFlat
                (notification.GrupoId, notification.DataDeCadastro, notification.DataDeAlteracao, 
                false, notification.Descricao, notification.CondominioId, 
                notification.CondominioCnpj, notification.CondominioNome, notification.CondominioLogoMarca);

            _condominioQueryRepository.AdicionarGrupo(grupoFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }

        public async Task Handle(GrupoEditadoEvent notification, CancellationToken cancellationToken)
        {

            //Atualizar no GrupoFlat
            var grupoFlat = await _condominioQueryRepository.ObterGrupoPorId(notification.GrupoId);

            grupoFlat.SetDataDeAlteracao(notification.DataDeAlteracao);

            grupoFlat.SetDescricao(notification.Descricao);

            _condominioQueryRepository.AtualizarGrupo(grupoFlat);

            //Atualizar no UnidadeFlat
            var unidadesDoCondominio = await _condominioQueryRepository.ObterUnidadesPorGrupo(notification.GrupoId);
            foreach (UnidadeFlat unidade in unidadesDoCondominio)
            {
                unidade.SetGrupoDescricao(notification.Descricao);               

                _condominioQueryRepository.AtualizarUnidade(unidade);
            }

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }


        public async Task Handle(GrupoRemovidoEvent notification, CancellationToken cancellationToken)
        {
            //Atualizar no GrupoFlat
            var grupoFlat = await _condominioQueryRepository.ObterGrupoPorId(notification.GrupoId);

            grupoFlat.SetDataDeAlteracao(notification.DataDeAlteracao);

            grupoFlat.EnviarParaLixeira();

            _condominioQueryRepository.AtualizarGrupo(grupoFlat);
            
            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }



        public void Dispose()
        {
            _condominioQueryRepository?.Dispose();
        }
    }
}

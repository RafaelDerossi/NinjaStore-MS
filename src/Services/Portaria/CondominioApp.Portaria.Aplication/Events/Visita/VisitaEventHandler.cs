﻿using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Portaria.Domain.FlatModel;
using CondominioApp.Portaria.Domain.Interfaces;
using MediatR;

namespace CondominioApp.Portaria.Aplication.Events
{
    public class VisitaEventHandler : EventHandler,
        INotificationHandler<VisitaCadastradaEvent>,
        INotificationHandler<VisitaEditadaEvent>,
        INotificationHandler<VisitaRemovidaEvent>,
        INotificationHandler<VisitaAprovadaEvent>,
        INotificationHandler<VisitaReprovadaEvent>,
        INotificationHandler<VisitaIniciadaEvent>,
        INotificationHandler<VisitaTerminadaEvent>,
        System.IDisposable
    {        

        private IVisitanteQueryRepository _visitanteQueryRepository;

        public VisitaEventHandler(
            IVisitanteQueryRepository visitanteQueryRepository)
        {
            _visitanteQueryRepository = visitanteQueryRepository;          
        }


        public async Task Handle(VisitaCadastradaEvent notification, CancellationToken cancellationToken)
        {
            var visitanteFlat = await _visitanteQueryRepository.ObterPorId(notification.VisitanteId);
            if (visitanteFlat ==null)
            {
                visitanteFlat =  new VisitanteFlat
                (notification.VisitanteId, notification.NomeVisitante, notification.TipoDeDocumentoVisitante,
                notification.RgVisitante.Numero, notification.CpfVisitante.Numero, notification.EmailVisitante.Endereco,
                notification.FotoVisitante.NomeDoArquivo, notification.CondominioId, notification.NomeCondominio,
                notification.UnidadeId, notification.NumeroUnidade, notification.AndarUnidade, notification.GrupoUnidade,
                false, "", notification.TipoDeVisitante, notification.NomeEmpresaVisitante, notification.TemVeiculo,
                notification.Veiculo.Placa, notification.Veiculo.Modelo, notification.Veiculo.Cor);

                _visitanteQueryRepository.Adicionar(visitanteFlat);
            }
            else
            {
                visitanteFlat.SetNome(notification.NomeVisitante);
                visitanteFlat.SetTipoDeDocumento(notification.TipoDeDocumentoVisitante);
                visitanteFlat.SetCpf(notification.CpfVisitante.Numero);
                visitanteFlat.SetRg(notification.RgVisitante.Numero);
                visitanteFlat.SetEmail(notification.EmailVisitante.Endereco);
                visitanteFlat.SetFoto(notification.FotoVisitante.NomeDoArquivo);                                
                visitanteFlat.SetTipoDeVisitante(notification.TipoDeVisitante);
                visitanteFlat.SetNomeEmpresa(notification.NomeEmpresaVisitante);

                visitanteFlat.MarcarNaoTemVeiculo();
                if (notification.TemVeiculo)
                    visitanteFlat.MarcarTemVeiculo();

                visitanteFlat.SetPlacaVeiculo(notification.Veiculo.Placa);
                visitanteFlat.SetModeloVeiculo(notification.Veiculo.Modelo);
                visitanteFlat.SetCorVeiculo(notification.Veiculo.Cor);

                _visitanteQueryRepository.Atualizar(visitanteFlat);
            }

            
            var visitaFlat = new VisitaFlat
                (notification.Id, notification.DataDeEntrada, notification.NomeCondomino, notification.Observacao,
                notification.Status, notification.VisitanteId, notification.NomeVisitante,
                notification.TipoDeDocumentoVisitante, notification.RgVisitante.Numero, notification.CpfVisitante.Numero,
                notification.EmailVisitante.Endereco, notification.FotoVisitante.NomeDoArquivo, notification.TipoDeVisitante,
                notification.NomeEmpresaVisitante, notification.CondominioId, notification.NomeCondominio,
                notification.UnidadeId, notification.NumeroUnidade, notification.AndarUnidade, notification.GrupoUnidade,
                notification.TemVeiculo, notification.Veiculo.Placa, notification.Veiculo.Modelo, notification.Veiculo.Cor);
                                   

            _visitanteQueryRepository.AdicionarVisita(visitaFlat);

            await PersistirDados(_visitanteQueryRepository.UnitOfWork);
        }

        public async Task Handle(VisitaEditadaEvent notification, CancellationToken cancellationToken)
        {
            var visitanteFlat = await _visitanteQueryRepository.ObterPorId(notification.VisitanteId);
            if (visitanteFlat != null)            
            {
                visitanteFlat.SetNome(notification.NomeVisitante);
                visitanteFlat.SetTipoDeDocumento(notification.TipoDeDocumentoVisitante);
                visitanteFlat.SetCpf(notification.CpfVisitante.Numero);
                visitanteFlat.SetRg(notification.RgVisitante.Numero);
                visitanteFlat.SetEmail(notification.EmailVisitante.Endereco);
                visitanteFlat.SetFoto(notification.FotoVisitante.NomeDoArquivo);
                visitanteFlat.SetTipoDeVisitante(notification.TipoDeVisitante);
                visitanteFlat.SetNomeEmpresa(notification.NomeEmpresaVisitante);

                visitanteFlat.MarcarNaoTemVeiculo();
                if (notification.TemVeiculo)
                    visitanteFlat.MarcarTemVeiculo();

                visitanteFlat.SetPlacaVeiculo(notification.Veiculo.Placa);
                visitanteFlat.SetModeloVeiculo(notification.Veiculo.Modelo);
                visitanteFlat.SetCorVeiculo(notification.Veiculo.Cor);

                _visitanteQueryRepository.Atualizar(visitanteFlat);
            }

            var visitaFlat = await _visitanteQueryRepository.ObterVisitaPorId(notification.Id);
            if (visitanteFlat != null)
            {
                visitaFlat.SetNomeCondomino(notification.NomeCondomino);
                visitaFlat.SetNomeVisitante(notification.NomeVisitante);
                visitaFlat.SetTipoDocumentoVisitante(notification.TipoDeDocumentoVisitante);
                visitaFlat.SetCpfVisitante(notification.CpfVisitante.Numero);
                visitaFlat.SetRgVisitante(notification.RgVisitante.Numero);
                visitaFlat.SetEmailVisitante(notification.EmailVisitante.Endereco);
                visitaFlat.SetFotoVisitante(notification.FotoVisitante.NomeDoArquivo);
                visitaFlat.SetTipoDeVisitante(notification.TipoDeVisitante);
                visitaFlat.SetNomeEmpresaVisitante(notification.NomeEmpresaVisitante);
                visitaFlat.SetUnidadeId(notification.UnidadeId);
                visitaFlat.SetNumeroUnidade(notification.NumeroUnidade);
                visitaFlat.SetAndarUnidade(notification.AndarUnidade);
                visitaFlat.SetGrupoUnidade(notification.GrupoUnidade);

                visitaFlat.MarcarNaoTemVeiculo();
                if (notification.TemVeiculo)
                    visitaFlat.MarcarTemVeiculo();

                visitaFlat.SetPlacaVeiculo(notification.Veiculo.Placa);
                visitaFlat.SetModeloVeiculo(notification.Veiculo.Modelo);
                visitaFlat.SetCorVeiculo(notification.Veiculo.Cor);


                _visitanteQueryRepository.AtualizarVisita(visitaFlat);

                await PersistirDados(_visitanteQueryRepository.UnitOfWork);
            }          

           
        }

        public async Task Handle(VisitaRemovidaEvent notification, CancellationToken cancellationToken)
        {
            var visitaFlat = await _visitanteQueryRepository.ObterVisitaPorId(notification.Id);
            if(visitaFlat != null)
            {
                visitaFlat.EnviarParaLixeira();

                _visitanteQueryRepository.AtualizarVisita(visitaFlat);

                await PersistirDados(_visitanteQueryRepository.UnitOfWork);
            }            
        }

        public async Task Handle(VisitaAprovadaEvent notification, CancellationToken cancellationToken)
        {
            var visitaFlat = await _visitanteQueryRepository.ObterVisitaPorId(notification.Id);
            if (visitaFlat != null)
            {
                visitaFlat.AprovarVisita();

                _visitanteQueryRepository.AtualizarVisita(visitaFlat);

                await PersistirDados(_visitanteQueryRepository.UnitOfWork);
            }           
        }

        public async Task Handle(VisitaReprovadaEvent notification, CancellationToken cancellationToken)
        {
            var visitaFlat = await _visitanteQueryRepository.ObterVisitaPorId(notification.Id);
            if (visitaFlat != null)
            {
                visitaFlat.ReprovarVisita();

                _visitanteQueryRepository.AtualizarVisita(visitaFlat);

                await PersistirDados(_visitanteQueryRepository.UnitOfWork);
            }            
        }

        public async Task Handle(VisitaIniciadaEvent notification, CancellationToken cancellationToken)
        {
            var visitaFlat = await _visitanteQueryRepository.ObterVisitaPorId(notification.Id);
            if (visitaFlat != null)
            {
                visitaFlat.IniciarVisita(notification.DataDeEntrada);

                _visitanteQueryRepository.AtualizarVisita(visitaFlat);

                await PersistirDados(_visitanteQueryRepository.UnitOfWork);
            }            
        }

        public async Task Handle(VisitaTerminadaEvent notification, CancellationToken cancellationToken)
        {
            var visitaFlat = await _visitanteQueryRepository.ObterVisitaPorId(notification.Id);
            if (visitaFlat != null)
            {
                visitaFlat.TerminarVisita(notification.DataDeSaida);

                _visitanteQueryRepository.AtualizarVisita(visitaFlat);

                await PersistirDados(_visitanteQueryRepository.UnitOfWork);
            }            
        }


        public void Dispose()
        {
            _visitanteQueryRepository?.Dispose();
        }        

    }
}

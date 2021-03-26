﻿using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents;
using CondominioApp.Ocorrencias.App.Aplication.Commands;
using CondominioApp.Ocorrencias.App.Models;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Comunicados.App.Aplication.Commands
{
    public class OcorrenciaCommandHandler : CommandHandler,
         IRequestHandler<CadastrarOcorrenciaCommand, ValidationResult>,
         IRequestHandler<EditarOcorrenciaCommand, ValidationResult>,
         IRequestHandler<RemoverOcorrenciaCommand, ValidationResult>,
         IDisposable
    {

        private IOcorrenciaRepository _ocorrenciaRepository;

        public OcorrenciaCommandHandler(IOcorrenciaRepository ocorrenciaRepository)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarOcorrenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var ocorrencia = OcorrenciaFactory(request);           
           
            _ocorrenciaRepository.Adicionar(ocorrencia);

            ocorrencia.EnviarPushNovaOcorrencia();

            return await PersistirDados(_ocorrenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditarOcorrenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var ocorrencia = await _ocorrenciaRepository.ObterPorId(request.Id);
            if (ocorrencia == null)
            {
                AdicionarErro("Ocorrência não encontrada!");
                return ValidationResult;
            }

            var retorno = ocorrencia.Editar(request.Descricao, request.Foto, request.Publica);
            if (!retorno.IsValid)
                return retorno;
                       

            _ocorrenciaRepository.Atualizar(ocorrencia);

            return await PersistirDados(_ocorrenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverOcorrenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var ocorrencia = await _ocorrenciaRepository.ObterPorId(request.Id);
            if (ocorrencia == null)
            {
                AdicionarErro("Ocorrência não encontrada!");
                return ValidationResult;
            }
           
            var retorno = ocorrencia.Remover();
            if (!retorno.IsValid)
                return retorno;

            _ocorrenciaRepository.Atualizar(ocorrencia);            

            return await PersistirDados(_ocorrenciaRepository.UnitOfWork);
        }

        private Ocorrencia OcorrenciaFactory(CadastrarOcorrenciaCommand request)
        {
            var ocorrencia = new Ocorrencia(
                request.Descricao, request.Foto, request.Publica, request.UnidadeId, request.MoradorId,
                request.CondominioId, request.Panico);
           
            return ocorrencia;
        }

        public void Dispose()
        {
            _ocorrenciaRepository?.Dispose();
        }


    }
}

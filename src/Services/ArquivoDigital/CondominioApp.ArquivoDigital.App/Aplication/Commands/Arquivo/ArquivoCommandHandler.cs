﻿using CondominioApp.ArquivoDigital.App.Models;
using CondominioApp.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class ArquivoCommandHandler : CommandHandler,
         IRequestHandler<CadastrarArquivoCommand, ValidationResult>,
         IRequestHandler<EditarArquivoCommand, ValidationResult>,
         IRequestHandler<AlterarPastaDoArquivoCommand, ValidationResult>,
         IRequestHandler<MarcarArquivoComoPublicoCommand, ValidationResult>,
         IRequestHandler<MarcarArquivoComoPrivadoCommand, ValidationResult>,
         IRequestHandler<RemoverArquivoCommand, ValidationResult>,
         IDisposable
    {

        private IArquivoDigitalRepository _arquivoDigitalRepository;

        public ArquivoCommandHandler(IArquivoDigitalRepository arquivoDigitalRepository)
        {
            _arquivoDigitalRepository = arquivoDigitalRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarArquivoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;           

            var pasta = await _arquivoDigitalRepository.ObterPorId(request.PastaId);
            if (pasta == null)
            {
                AdicionarErro("Pasta não encontrada!");
                return ValidationResult;
            }

            var arquivo = ArquivoFactory(request, pasta.CondominioId);

            _arquivoDigitalRepository.AdicionarArquivo(arquivo);           

            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditarArquivoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var arquivoBd = await _arquivoDigitalRepository.ObterArquivoPorId(request.Id);
            if (arquivoBd == null)
            {
                AdicionarErro("Arquivo não encontrado.");
                return ValidationResult;
            }

            arquivoBd.SetTitulo(request.Titulo);
            arquivoBd.SetDescricao(request.Descricao);
            arquivoBd.MarcarComoPrivado();
            if (request.Publico)
                arquivoBd.MarcarComoPublico();

            _arquivoDigitalRepository.AtualizarArquivo(arquivoBd);


            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarPastaDoArquivoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var arquivoBd = await _arquivoDigitalRepository.ObterArquivoPorId(request.Id);
            if (arquivoBd == null)
            {
                AdicionarErro("Arquivo não encontrado.");
                return ValidationResult;
            }

            arquivoBd.SetPastaId(request.PastaId);           

            _arquivoDigitalRepository.AtualizarArquivo(arquivoBd);


            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(MarcarArquivoComoPublicoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var arquivoBd = await _arquivoDigitalRepository.ObterArquivoPorId(request.Id);
            if (arquivoBd == null)
            {
                AdicionarErro("Arquivo não encontrado.");
                return ValidationResult;
            }

            arquivoBd.MarcarComoPublico();

            _arquivoDigitalRepository.AtualizarArquivo(arquivoBd);



            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(MarcarArquivoComoPrivadoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var arquivoBd = await _arquivoDigitalRepository.ObterArquivoPorId(request.Id);
            if (arquivoBd == null)
            {
                AdicionarErro("Arquivo não encontrado.");
                return ValidationResult;
            }
                        
            arquivoBd.MarcarComoPrivado();
            
            _arquivoDigitalRepository.AtualizarArquivo(arquivoBd);


            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverArquivoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var arquivoBd = await _arquivoDigitalRepository.ObterArquivoPorId(request.Id);
            if (arquivoBd == null)
            {
                AdicionarErro("Arquivo não encontrado.");
                return ValidationResult;
            }

            arquivoBd.EnviarParaLixeira();

            _arquivoDigitalRepository.AtualizarArquivo(arquivoBd);


            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }



        private Arquivo ArquivoFactory(CadastrarArquivoCommand request, Guid condominioId)
        {
            var arquivo = new Arquivo(request.Nome, request.Tamanho, condominioId, request.PastaId, request.Publico, 
                                      request.UsuarioId, request.NomeUsuario, request.Titulo, request.Descricao);

            arquivo.SetEntidadeId(request.Id);
            return arquivo;
        }


        public void Dispose()
        {
            _arquivoDigitalRepository?.Dispose();
        }


    }
}

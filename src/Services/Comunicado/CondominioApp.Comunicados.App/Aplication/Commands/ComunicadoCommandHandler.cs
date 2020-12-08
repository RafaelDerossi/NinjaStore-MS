﻿using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Comunicados.App.Aplication.Commands
{
    public class ComunicadoCommandHandler : CommandHandler,
         IRequestHandler<CadastrarComunicadoCommand, ValidationResult>,
         IDisposable
    {

        private IComunidadoRepository _ComunicadoRepository;

        public ComunicadoCommandHandler(IComunidadoRepository comunicadoRepository)
        {
            _ComunicadoRepository = comunicadoRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarComunicadoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var comunicado = ComunicadoFactory(request);

            foreach (Unidade unidade in request.Unidades)
            {
               var resultado = comunicado.AdicionarUnidade(unidade);
                if (!resultado.IsValid) return resultado;
            }
            _ComunicadoRepository.Adicionar(comunicado);

            return await PersistirDados(_ComunicadoRepository.UnitOfWork);
        }

       
        private Comunicado ComunicadoFactory(CadastrarComunicadoCommand request)
        {
            var comunicado = new Comunicado(
                request.Titulo, request.Descricao, request.DataDeRealizacao, request.CondominioId, 
                request.NomeCondominio, request.UsuarioId, request.NomeUsuario, request.Visibilidade,
                request.Categoria, request.TemAnexos, request.CriadoPelaAdministradora);

            comunicado.SetEntidadeId(request.ComunicadoId);

            return comunicado;
        }


        public void Dispose()
        {
            _ComunicadoRepository?.Dispose();
        }


    }
}

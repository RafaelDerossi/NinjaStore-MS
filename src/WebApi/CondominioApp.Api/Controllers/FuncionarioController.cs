﻿using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CondominioApp.Usuarios.App.ViewModels;
using AutoMapper;
using CondominioApp.Usuarios.App.Aplication.Commands;
using System.Linq;
using CondominioApp.Usuarios.App.FlatModel;
using System.Collections.Generic;

namespace CondominioApp.Api.Controllers
{
    [Route("/api/funcionario")]
    public class FuncionarioController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly ICondominioQuery _condominioQuery;        

        public FuncionarioController(IMediatorHandler mediatorHandler, IUsuarioQuery usuarioQuery,
            ICondominioQuery condominioQuery)
        {
            _mediatorHandler = mediatorHandler;            
            _usuarioQuery = usuarioQuery;
            _condominioQuery = condominioQuery;            
        }


        [HttpGet("{usuarioId:Guid}")]
        public async Task<ActionResult<IEnumerable<FuncionarioFlat>>> ObterFuncionariosPorUsuarioId(Guid usuarioId)
        {
            var funcionario = await _usuarioQuery.ObterFuncionariosPorUsuarioId(usuarioId);
            if (funcionario.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum funcionario encontrado.");
                return CustomResponse();
            }

            return funcionario.ToList();
        }


        [HttpPost("vincular-funcionario-condominio")]
        public async Task<ActionResult> Post(VincularFuncionarioCondominioViewModel vincularViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(vincularViewModel.UsuarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionario não encontrado!");
                return CustomResponse();
            }

            var condominio = await _condominioQuery.ObterPorId(vincularViewModel.CondominioId);
            if (condominio == null)
            {
                AdicionarErroProcessamento("Condomínio não encontrado!");
                return CustomResponse();
            }

            var comando = new CadastrarFuncionarioCommand
                (funcionario.UsuarioId, condominio.Id, condominio.Nome, vincularViewModel.Atribuicao,
                vincularViewModel.Funcao, vincularViewModel.Permissao);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            if (!resultado.IsValid)
                CustomResponse(resultado);


            return CustomResponse();

        }
     
    }
}
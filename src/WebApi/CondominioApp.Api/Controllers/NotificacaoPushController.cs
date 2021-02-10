﻿using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CondominioApp.Core.Mediator;
using CondominioApp.NotificacaoPush.App.Services.Interfaces;
using CondominioApp.OneSignal.Recursos;
using CondominioApp.OneSignal.Recursos.Dispositivos.Enuns;
using CondominioApp.NotificacaoPush.App.DTO;
using CondominioApp.NotificacaoPush.App.ViewModel;
using CondominioApp.NotificacaoPush.App.OneSignalApps;


namespace CondominioApp.Api.Controllers
{
    [Route("api/notificacaoPush")]
    public class NotificacaoPushController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly INotificacaoPushService _notificacaoPushService;

        public NotificacaoPushController(IMediatorHandler mediatorHandler, INotificacaoPushService notificacaoPushService)
        {
            _mediatorHandler = mediatorHandler;
            _notificacaoPushService = notificacaoPushService;
        }



        [HttpPost("adicionar-dispositivo-AppV2")]
        public ActionResult AdicionarDispositivoAppV2()
        {
            var dispositvoDTO = new DispositivoDTO();

            dispositvoDTO.AppOneSignal = new CondominioAppV2OneSignalApp();
            dispositvoDTO.Identificador = "0b2eb4f89990b6e3";
            dispositvoDTO.CodigoDaLingua = CodigosDeLingua.Portuguese;
            dispositvoDTO.Modelo = "SM-A307GT";
            dispositvoDTO.SOdoDispositivo = "10";
            dispositvoDTO.TipoDoDispositivo = TipoDeDispositivo.Android;

            _notificacaoPushService.AdcionarDispositivo(dispositvoDTO);

            return CustomResponse();
        }


        [HttpPost("criar-notificacao-AppV1")]
        public ActionResult CriarNotificacaoAppV1(NotificacaoPushViewModel notificacaoVM)
        {
            var notificacaoDTO = new NotificacaoPushDTO();

            notificacaoDTO.AppOneSignal = new CondominioAppOneSignalApp();

            //notificacaoDTO.Titulos.Add(CodigosDeLingua.English, "Condominio App");
            notificacaoDTO.Titulos.Add(CodigosDeLingua.English, notificacaoVM.Titulo);

            //notificacaoDTO.Conteudo.Add(CodigosDeLingua.English, "Hello world 6!");
            notificacaoDTO.Conteudo.Add(CodigosDeLingua.English, notificacaoVM.Conteudo);

            //notificacaoDTO.DispositivosIds = new List<string> { "159b6c6f-99b2-4e82-9875-3aa5295c5c74" };
            notificacaoDTO.DispositivosIds = notificacaoVM.DispositivosIds;

            _notificacaoPushService.CriarNotificacao(notificacaoDTO);

            return CustomResponse();
        }


        [HttpPost("criar-notificacao-AppV2")]
        public ActionResult CriarNotificacaoAppV2(NotificacaoPushViewModel notificacaoVM)
        {
            var notificacaoDTO = new NotificacaoPushDTO();

            notificacaoDTO.AppOneSignal = new CondominioAppV2OneSignalApp();
            notificacaoDTO.Titulos.Add(CodigosDeLingua.English, "Condominio App");
            notificacaoDTO.Conteudo.Add(CodigosDeLingua.English, "Hello world 6!");
            notificacaoDTO.DispositivosIds = new List<string> { "159b6c6f-99b2-4e82-9875-3aa5295c5c74" };

            _notificacaoPushService.CriarNotificacao(notificacaoDTO);

            return CustomResponse();

        }

    }
}
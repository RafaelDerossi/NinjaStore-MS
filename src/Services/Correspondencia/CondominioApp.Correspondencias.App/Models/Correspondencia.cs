﻿using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents;
using CondominioApp.Correspondencias.App.ValueObjects;
using FluentValidation.Results;
using System;

namespace CondominioApp.Correspondencias.App.Models
{
   public class Correspondencia : Entity, IAggregateRoot
    {
        public const int Max = 200;

        public Guid CondominioId { get; private set; }

        public Guid UnidadeId { get; private set; }

        public string NumeroUnidade { get; private set; }

        public string Bloco { get; private set; }
        
        public bool Visto { get; private set; }
        
        public string NomeRetirante { get; private set; }
        
        public string Observacao { get; private set; }

        public DateTime? DataDaRetirada { get; private set; }

        public Guid FuncionarioId { get; private set; }

        public string NomeFuncionario { get; private set; }

        public Foto Foto { get; private set; }

        public string NumeroRastreamentoCorreio { get; private set; }

        public DateTime DataDeChegada { get; private set; }

        public int QuantidadeDeAlertasFeitos { get; private set; }

        public string TipoDeCorrespondencia { get; private set; }

        public StatusCorrespondencia Status { get; private set; }



        /// <summary>
        /// Construtores
        /// </summary>
        protected Correspondencia()
        {
        }
        public Correspondencia(Guid condominioId, Guid unidadeId, string numeroUnidade, string bloco, bool visto, 
            string nomeRetirante, string observacao, DateTime? dataDaRetirada, Guid funcionarioId, 
            string nomeFuncionario, Foto foto, string numeroRastreamentoCorreio, DateTime dataDeChegada, 
            int quantidadeDeAlertasFeitos, string tipoDeCorrespondencia, StatusCorrespondencia status)
        {
            CondominioId = condominioId;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            Bloco = bloco;
            Visto = visto;
            NomeRetirante = nomeRetirante;
            Observacao = observacao;
            DataDaRetirada = dataDaRetirada;
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
            Foto = foto;
            NumeroRastreamentoCorreio = numeroRastreamentoCorreio;
            DataDeChegada = dataDeChegada;
            QuantidadeDeAlertasFeitos = quantidadeDeAlertasFeitos;
            TipoDeCorrespondencia = tipoDeCorrespondencia;
            Status = status;
        }


        ///Metodos Set
        ///
        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;

        public void SetUnidadeId(Guid unidadeId) => UnidadeId = unidadeId;

        public void SetNumeroUnidade(string numeroUnidade) => NumeroUnidade = numeroUnidade;

        public void SetBloco(string bloco) => Bloco = bloco;

        public void SetVisto() => Visto = true;

        public void SetNaoVisto() => Visto = false;

        public void SetNomeRetirante(string nomeRetirante) => NomeRetirante = nomeRetirante;

        public void SetObservacao(string observacao) => Observacao = observacao;

        public void SetDataRetirada(DateTime dataRetirada) => DataDaRetirada = dataRetirada;

        public void SetFuncionarioId(Guid usuarioId) => FuncionarioId = usuarioId;

        public void SetNomeFuncionario(string nomeUsuario) => NomeFuncionario = nomeUsuario;

        public void SetFoto(Foto foto) => Foto = foto;

        public void SetNumeroRastreamentoCorreio(string numeroRastreamento) => NumeroRastreamentoCorreio = numeroRastreamento;

        public void SetDataDeChegada(DateTime dataDeChegada) => DataDeChegada = dataDeChegada;

   

        

        public void SetTipoDeCorrespondencia(string tipoDeCorrespondencia) => TipoDeCorrespondencia = tipoDeCorrespondencia;

        public void SetPendente() => Status = StatusCorrespondencia.PENDENTE;

        public void SetRetirado() => Status = StatusCorrespondencia.RETIRADO;

        public void SetDevolvido() => Status = StatusCorrespondencia.DEVOLVIDO;
       


        public ValidationResult MarcarComRetirada
            (string nomeRetirante, string observacao, Guid funcionarioId, string nomeFuncionario)
        {
            if (Status == StatusCorrespondencia.DEVOLVIDO)
            {
                AdicionarErrosDaEntidade("Essa Correspondência consta como DEVOLVIDA.");
                return ValidationResult;
            }

            if (Status == StatusCorrespondencia.RETIRADO)
            {
                AdicionarErrosDaEntidade("Essa Correspondência ja consta como RETIRADA.");
                return ValidationResult;
            }

            SetNomeRetirante(nomeRetirante);
            SetObservacao(observacao);
            SetFuncionarioId(funcionarioId);
            SetNomeFuncionario(nomeFuncionario);

            SetRetirado();
            SetDataRetirada(DataHoraDeBrasilia.Get());
            SetVisto();

            return ValidationResult;
        }


        public ValidationResult MarcarComDevolvida
          (string observacao, Guid funcionarioId, string nomeFuncionario)
        {
            if (Status == StatusCorrespondencia.DEVOLVIDO)
            {
                AdicionarErrosDaEntidade("Essa Correspondência consta como DEVOLVIDA.");
                return ValidationResult;
            }

            if (Status == StatusCorrespondencia.RETIRADO)
            {
                AdicionarErrosDaEntidade("Essa Correspondência ja consta como RETIRADA.");
                return ValidationResult;
            }

            SetDevolvido();
            SetObservacao(observacao);
            SetFuncionarioId(funcionarioId);
            SetNomeFuncionario(nomeFuncionario);

            return ValidationResult;
        }


        public ValidationResult SomarAlerta()
        {
            if (Status == StatusCorrespondencia.DEVOLVIDO)
            {
                AdicionarErrosDaEntidade("Essa Correspondência consta como DEVOLVIDA.");
                return ValidationResult;
            }

            if (Status == StatusCorrespondencia.RETIRADO)
            {
                AdicionarErrosDaEntidade("Essa Correspondência consta como RETIRADA.");
                return ValidationResult;
            }

            QuantidadeDeAlertasFeitos += 1;

            return ValidationResult;
        }


        public void EnviarPush()
        {
            switch (Status)
            {
                case StatusCorrespondencia.PENDENTE:
                    EnviarPushNovaCorrespondencia();
                    break;
                case StatusCorrespondencia.RETIRADO:
                    EnviarPushCorrespondenciaRetirada();
                    break;
                case StatusCorrespondencia.DEVOLVIDO:
                    EnviarPushCorrespondenciaDevolvida();
                    break;
                default:
                    break;
            }
        }


        private void EnviarPushNovaCorrespondencia()
        {
            var titulo = "NOVA CORRESPONDÊNCIA";
            var descricao = ObterDescricaoDoPushParaNovaCorrespondencia();

            AdicionarEvento
                (new EnviarPushParaUnidadeIntegrationEvent(UnidadeId, titulo, descricao));
            return;
        }
        private string ObterDescricaoDoPushParaNovaCorrespondencia()
        {
            var descricao = $"Chegou uma correspondência para você.  Recebido por {NomeFuncionario}.";

            if (TipoDeCorrespondencia != null && TipoDeCorrespondencia != "")
                descricao = $"{descricao}   Tipo: {TipoDeCorrespondencia}.";

            if (Observacao != null && Observacao != "")
                descricao = $"{descricao}   {Observacao}.";

            return descricao;
        }


        private void EnviarPushCorrespondenciaRetirada()
        {
            var titulo = "CORRESPONDÊNCIA RETIRADA";
            var descricao = ObterDescricaoDoPushParaCorrespondenciaRetirada();

            AdicionarEvento
                (new EnviarPushParaUnidadeIntegrationEvent(UnidadeId, titulo, descricao));
            return;
        }
        private string ObterDescricaoDoPushParaCorrespondenciaRetirada()
        {
            var descricao = $"Correspondência retirada por {NomeRetirante} em {DataDaRetirada.Value.ToLongDateString()} as {DataDaRetirada.Value.ToLongTimeString()}.";

            if (TipoDeCorrespondencia != null && TipoDeCorrespondencia != "")
                descricao = $"{descricao}   Tipo da Corrêspondencia: {TipoDeCorrespondencia}.";

            if (Observacao != null && Observacao != "")
                descricao = $"{descricao}   {Observacao}.";

            return descricao;
        }


        private void EnviarPushCorrespondenciaDevolvida()
        {
            var titulo = "CORRESPONDÊNCIA DEVOLVIDA";
            var descricao = ObterDescricaoDoPushParaCorrespondenciaDevolvida();

            AdicionarEvento
                (new EnviarPushParaUnidadeIntegrationEvent(UnidadeId, titulo, descricao));
            return;
        }
        private string ObterDescricaoDoPushParaCorrespondenciaDevolvida()
        {
            var descricao = $"Correspondência devolvida por {NomeFuncionario}.";

            if (TipoDeCorrespondencia != null && TipoDeCorrespondencia != "")
                descricao = $"{descricao}   Tipo da Corrêspondencia: {TipoDeCorrespondencia}.";

            if (Observacao != null && Observacao != "")
                descricao = $"{descricao}   {Observacao}.";

            return descricao;
        }


        public void EnviarPushDeAlerta()
        {
            var titulo = "CORRESPONDÊNCIA";
            var descricao = ObterDescricaoDoPushDeAlerta();

            AdicionarEvento
                (new EnviarPushParaUnidadeIntegrationEvent(UnidadeId, titulo, descricao));
            return;
        }
        private string ObterDescricaoDoPushDeAlerta()
        {
            var descricao = $"Existe uma correspondência para você esperando ser retira.";

            if (TipoDeCorrespondencia != null && TipoDeCorrespondencia != "")
                descricao = $"{descricao}   Tipo: {TipoDeCorrespondencia}.";

            if (Observacao != null && Observacao != "")
                descricao = $"{descricao}   {Observacao}.";

            return descricao;
        }


    }
}

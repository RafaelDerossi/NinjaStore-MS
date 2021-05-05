﻿using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain;
using CondominioApp.Principal.Domain.ValueObjects;
using System;


namespace CondominioApp.Principal.Aplication.Commands
{
    public abstract class CondominioCommand : Command
    {
        public Guid CondominioId { get; protected set; }

        public Cnpj Cnpj { get; protected set; }      

        public string Nome { get; protected set; }

        public string Descricao { get; protected set; }

        public Foto LogoMarca { get; protected set; }       

        public Telefone Telefone { get; protected set; }

        public Endereco Endereco { get; protected set; }

       

        /// Referencia Externa
        /// <summary>
        /// Id de referencia externa do condominio
        /// </summary>
        public int? RefereciaId { get; protected set; }

        public string LinkGeraBoleto { get; protected set; }

        public string BoletoFolder { get; protected set; }

        public Url UrlWebServer { get; protected set; }

        public Guid FuncionarioIdDoSindico { get; protected set; }

        public string NomeDoSindico { get; protected set; }

        ///Parametros
        /// <summary>
        /// Habilita/Desabilita Portaria
        /// </summary>
        public bool Portaria { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Portaria Para o Morador
        /// </summary>
        public bool PortariaMorador { get; protected set; }

        /// <summary>
        ///  Habilita/Desabilita Classificado
        /// </summary>
        public bool Classificado { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Classificado para o morador
        /// </summary>
        public bool ClassificadoMorador { get; protected set; }

        /// <summary>
        ///  Habilita/Desabilita Mural
        /// </summary>
        public bool Mural { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Mural para o morador
        /// </summary>
        public bool MuralMorador { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Chat
        /// </summary>
        public bool Chat { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Chat para o morador
        /// </summary>
        public bool ChatMorador { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Reserva
        /// </summary>
        public bool Reserva { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Reserva na Portaria
        /// </summary>
        public bool ReservaNaPortaria { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Ocorrencia
        /// </summary>
        public bool Ocorrencia { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Ocorrencia para o morador
        /// </summary>
        public bool OcorrenciaMorador { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Correspondencia 
        /// </summary>
        public bool Correspondencia { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Correspondencia na Portaria
        /// </summary>
        public bool CorrespondenciaNaPortaria { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Limite de Tempo na Reserva
        /// </summary>
        public bool LimiteTempoReserva { get; protected set; }


        public Contrato Contrato { get; protected set; }    


        public void SetCNPJ(string cnpj)
        {
            try
            {
                Cnpj = new Cnpj(cnpj);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }            

        public void SetFoto(string logomarca, string nomeOriginal)
        {
            try
            {
                LogoMarca = new Foto(nomeOriginal, logomarca);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetTelefone(string telefone)
        {
            try
            {
                Telefone = new Telefone(telefone);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetEndereco(string logradouro, string complemento, string numero, 
            string cep, string bairro, string cidade, string estado)
        {
            try
            {
                Endereco = new Endereco(logradouro,complemento,numero,cep,bairro,cidade,estado);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetUrlWebServer(string url)
        {
            try
            {
                UrlWebServer = new Url(url);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetContrato(
            DateTime dataAssinatura, TipoDePlano tipoPlano, 
            string descricaoContrato, bool ativo, string linkContrato)
        {
            if (tipoPlano != 0)
            {
                Contrato = new Contrato(CondominioId, dataAssinatura, tipoPlano, descricaoContrato, ativo, linkContrato);
            }            
        }

        public void SetNome(string nome) => Nome = nome;

        public void SetSindico(Guid id, string nome)
        {
            FuncionarioIdDoSindico = id;
            NomeDoSindico = nome;
        }
    }
}

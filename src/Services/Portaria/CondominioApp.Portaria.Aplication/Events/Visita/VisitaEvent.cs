﻿using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Events
{
    public abstract class VisitaEvent : Event
    {
        public Guid Id { get; protected set; }

        public DateTime DataDeEntrada { get; protected set; }
        public bool Terminada { get; protected set; }
        public DateTime DataDeSaida { get; protected set; }
        
        public string Observacao { get; protected set; }
        public string Status { get; protected set; }
       

        public Guid VisitanteId { get; protected set; }
        public string NomeVisitante { get; protected set; }
        public string TipoDeDocumentoVisitante { get; protected set; }
        public string DocumentoVisitante { get; protected set; }
        public Cpf CpfVisitante { get; protected set; }
        public Email EmailVisitante { get; protected set; }
        public Foto FotoVisitante { get; protected set; }
        public string TipoDeVisitante { get; protected set; }       
        public string NomeEmpresaVisitante { get; protected set; }


        public Guid CondominioId { get; protected set; }
        public string NomeCondominio { get; protected set; }

        public Guid UnidadeId { get; protected set; }
        public string NumeroUnidade { get; protected set; }
        public string AndarUnidade { get; protected set; }
        public string GrupoUnidade { get; protected set; }

        public bool TemVeiculo { get; protected set; }
        public Veiculo Veiculo { get; protected set; }


        public Guid UsuarioId { get; protected set; }
        public string NomeUsuario { get; protected set; }


        public void SetDocumentoVisitante(string documento, TipoDeDocumento tipoDeDocumento)
        {
            TipoDeDocumentoVisitante = tipoDeDocumento.ToString();
            DocumentoVisitante = documento;
        }       

        public void SetEmailVisitante(Email email) => EmailVisitante = email;


        public void SetFotoVisitante(Foto foto) => FotoVisitante = foto;
        
        public void MarcarQueTemVeiculo() => TemVeiculo = true;
        public void MarcarQueNaoTemVeiculo() => TemVeiculo = false;
        public void SetVeiculo(Veiculo veiculo) => Veiculo = veiculo;
        

        public void SetDataDeEntrada(DateTime dataDeEntrada) => DataDeEntrada = dataDeEntrada;

        public void AprovarVisita() => Status = StatusVisita.APROVADA.ToString();

        public void SetVisitanteId(Guid visitanteId) => VisitanteId = visitanteId;

        public void SetTipoDeVisitante(TipoDeVisitante tipoDeVisiante) => TipoDeVisitante = tipoDeVisiante.ToString();

        public void SetNomeEmpresaVisitante(string  nomeEmpresaVisitante) => NomeEmpresaVisitante = nomeEmpresaVisitante;

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;

        public void SetNomeDoCondominio(string nomeDoCondominio) => NomeCondominio = nomeDoCondominio;

        public void SetUnidadeId(Guid unidadeId) => UnidadeId = unidadeId;

        public void SetNumeroUnidade(string numeroUnidade) => NumeroUnidade = numeroUnidade;

        public void SetAndarUnidade(string andarUnidade) => AndarUnidade = andarUnidade;

        public void SetGrupoUnidade(string grupoUnidade) => GrupoUnidade = grupoUnidade;
     
        public void SetUsuario(Guid usuarioId, string nomeUsuario)
        {
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
        }

    }
}

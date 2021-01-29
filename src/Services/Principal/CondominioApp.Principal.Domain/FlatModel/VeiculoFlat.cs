﻿using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Principal.Domain.FlatModel
{
    public class VeiculoFlat
    {
        public const int Max = 200;

        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public Guid VeiculoId { get; private set; }

        public string Placa { get; private set; }
        
        public string Modelo { get; private set; }

        public string Cor { get; private set; }

        public Guid UsuarioId { get; private set; }

        public string NomeUsuario { get; private set; }

        public Guid UnidadeId { get; private set; }

        public string NumeroUnidade { get; private set; }

        public string AndarUnidade { get; private set; }

        public string GrupoUnidade { get; private set; }

        public Guid CondominioId { get; private set; }



        protected VeiculoFlat() { }

        public VeiculoFlat
            (Guid id, Guid veiculoId, string placa, string modelo, string cor, Guid usuarioId,
             string nomeUsuario, Guid unidadeId, string numeroUnidade, string andarUnidade,
             string grupoUnidade, Guid codominioId)
        {
            Id = id;           
            VeiculoId = veiculoId;
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            GrupoUnidade = grupoUnidade;
            CondominioId = codominioId;
        }

        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;

        public void SetVeiculo(Guid veiculoId, string placa, string modelo, string cor)
        {
            VeiculoId = veiculoId;
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
        }

        public void SetUsuario(Guid usuarioId, string nomeUsuario)
        {
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
        }

        public void SetUnidade(Guid unidadeId, string numero, string andar, string grupo, Guid condominioId)
        {
            UnidadeId = unidadeId;
            NumeroUnidade = numero;
            AndarUnidade = andar;
            GrupoUnidade = grupo;
            CondominioId = condominioId;
        }
    }
}
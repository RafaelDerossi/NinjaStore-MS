﻿

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class EditarAreaComumCommand : AreaComumCommand
    {

        public EditarAreaComumCommand(
            Guid areaComumId, string nome, string descricao, string termoDeUso, int capacidade, string diasPermitidos,
            int antecedenciaMaximaEmMeses, int antecedenciaMaximaEmDias, int antecedenciaMinimaEmDias,
            int antecedenciaMinimaParaCancelamentoEmDias, bool requerAprovacaoDeReserva, bool temHorariosEspecificos,
            string tempoDeIntervaloEntreReservas, string tempoDeDuracaoDeReserva, 
            int numeroLimiteDeReservaPorUnidade, bool permiteReservaSobreposta, int numeroLimiteDeReservaSobreposta,
            int numeroLimiteDeReservaSobrepostaPorUnidade, ICollection<Periodo> periodos)
        {
            AreaComumId = areaComumId;
            Nome = nome;
            Descricao = descricao;
            TermoDeUso = termoDeUso;
            Capacidade = capacidade;
            DiasPermitidos = diasPermitidos;
            AntecedenciaMaximaEmMeses = antecedenciaMaximaEmMeses;
            AntecedenciaMaximaEmDias = antecedenciaMaximaEmDias;
            AntecedenciaMinimaEmDias = antecedenciaMinimaEmDias;
            AntecedenciaMinimaParaCancelamentoEmDias = antecedenciaMinimaParaCancelamentoEmDias;
            RequerAprovacaoDeReserva = requerAprovacaoDeReserva;
            TemHorariosEspecificos = temHorariosEspecificos;
            TempoDeIntervaloEntreReservas = tempoDeIntervaloEntreReservas;
            TempoDeDuracaoDeReserva = tempoDeDuracaoDeReserva;
            NumeroLimiteDeReservaPorUnidade = numeroLimiteDeReservaPorUnidade;
            PermiteReservaSobreposta = permiteReservaSobreposta;
            NumeroLimiteDeReservaSobreposta = numeroLimiteDeReservaSobreposta;
            NumeroLimiteDeReservaSobrepostaPorUnidade = numeroLimiteDeReservaSobrepostaPorUnidade;
            Periodos = periodos;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarAreaComumCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarAreaComumCommandValidation :AreaComumValidation<EditarAreaComumCommand>
        {
            public EditarAreaComumCommandValidation()
            {
                ValidateId();
                ValidateNome();
                ValidateDiasPermitidos();
                ValidateAntecedenciaMaximaEmMeses();
                ValidateAntecedenciaMaximaEmDias();
                ValidateAntecedenciaMinimaEmDias();
                ValidateAntecedenciaMinimaParaCancelamentoEmDias();
                ValidateRequerAprovacaoDeReserva();
                ValidateTemHorariosEspecificos();
                ValidatePermiteReservaSobreposta();
                ValidateNumeroLimiteDeReservaSobreposta();
                ValidateNumeroLimiteDeReservaSobrepostaPorUnidade();
                ValidatePeriodos();
            }
        }

    }
}

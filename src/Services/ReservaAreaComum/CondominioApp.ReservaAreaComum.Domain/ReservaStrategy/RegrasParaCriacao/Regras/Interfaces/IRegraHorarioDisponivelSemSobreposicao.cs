﻿using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces
{
    public interface IRegraHorarioDisponivelSemSobreposicao
    {
        ValidationResult Validar(Reserva reserva, AreaComum areaComum);
    }
}

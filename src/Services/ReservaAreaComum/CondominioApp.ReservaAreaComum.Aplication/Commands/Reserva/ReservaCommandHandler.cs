﻿using CondominioApp.Core.Messages;
using CondominioApp.ReservaAreaComum.Aplication.Events;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
    public class ReservaCommandHandler : CommandHandler,
         IRequestHandler<CadastrarReservaCommand, ValidationResult>,
         IRequestHandler<AprovarReservaCommand, ValidationResult>,
         IRequestHandler<CancelarReservaComoUsuarioCommand, ValidationResult>,
         IRequestHandler<CancelarReservaComoAdministradorCommand, ValidationResult>,
         IDisposable
    {

        private IAreaComumRepository _areaComumRepository;

        public ReservaCommandHandler(IAreaComumRepository areaComumRepository)
        {
            _areaComumRepository = areaComumRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarReservaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var reserva = ReservaFactory(request);

            var areacomum = await _areaComumRepository.ObterPorId(request.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

           var Result = areacomum.AdicionarReserva(reserva);

            if (!Result.IsValid) return Result;
            
            _areaComumRepository.AdicionarReserva(reserva);


           //Evento
           //

            return await PersistirDados(_areaComumRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(AprovarReservaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var reserva = await _areaComumRepository.ObterReservaPorId(request.Id);
            if (reserva == null)
            {
                AdicionarErro("Reserva não encontrada!");
                return ValidationResult;
            }

            reserva.Aprovar();

            //Evento
            //

            return await PersistirDados(_areaComumRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(CancelarReservaComoUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

           
            var areaComum = await _areaComumRepository.ObterPorId(await _areaComumRepository.ObterAreaComumIdPorReservaId(request.Id));
            if (areaComum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            var reserva = areaComum.ObterReserva(request.Id);

            var result = areaComum.CancelarReservaComoUsuario(reserva, request.Justificativa);
            if (!result.IsValid)
                return result;


            //Evento
            reserva.AdicionarEvento(new ReservaCanceladaEvent(reserva.Id));


            return await PersistirDados(_areaComumRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(CancelarReservaComoAdministradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var areaComum = await _areaComumRepository.ObterPorId(await _areaComumRepository.ObterAreaComumIdPorReservaId(request.Id));
            if (areaComum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            var reserva = areaComum.ObterReserva(request.Id);          

            var result = areaComum.CancelarReservaComoAdministrador(reserva, request.Justificativa);
            if (!result.IsValid)
                return result;

            //Evento
            reserva.AdicionarEvento(new ReservaCanceladaEvent(reserva.Id));

            return await PersistirDados(_areaComumRepository.UnitOfWork);
        }


        private Reserva ReservaFactory(CadastrarReservaCommand request)
        {
            return new Reserva
                (request.AreaComumId, request.Observacao, request.UnidadeId, request.NumeroUnidade, request.AndarUnidade,
                 request.DescricaoGrupoUnidade, request.UsuarioId, request.NomeUsuario, request.DataDeRealizacao.Date,
                 request.HoraInicio, request.HoraFim, request.Preco, request.EstaNaFila, request.Origem,
                 request.ReservadoPelaAdministracao);
        }
        
        public void Dispose()
        {
            _areaComumRepository?.Dispose();
        }

    }
}

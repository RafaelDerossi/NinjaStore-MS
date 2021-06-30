﻿using CondominioApp.Automacao.Models;
using CondominioApp.Core.Enumeradores;
using System;
using System.Threading.Tasks;

namespace CondominioApp.Automacao.App.Aplication.Query
{
    public interface IAutomacaoQuery : IDisposable
    {
        Task<CondominioCredencial> ObterPorId(Guid id);

        Task<CondominioCredencial> ObterPorCondominioETipoApi(Guid condominioId, TipoApiAutomacao tipoApiAutomacao);

        Task<bool> VerificaSeJaEstaCadastrado(Guid condominioId, TipoApiAutomacao tipoApiAutomacao);
      
    }
}
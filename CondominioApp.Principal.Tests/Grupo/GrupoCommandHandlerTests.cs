﻿using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal;
using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using CondominioApp.Principal.Domain.Interfaces;
using CondominioApp.Principal.Domain;
using CondominioApp.Core.ValueObjects;
using System;

namespace CondominioApp.Principal.Tests
{
   public class GrupoCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly GrupoCommandHandler _grupoCommandHandler;

        public GrupoCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _grupoCommandHandler = _mocker.CreateInstance<GrupoCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Grupo Válido")]
        [Trait("Categoria", "Grupos - GrupoCommandHandler")]
        public async Task AdicionarGrupo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = GrupoCommandFactory.CriarComandoCadastroDeGrupo();

            var condominio = new Condominio(new Cnpj("26585345000148"), "Condominio TU",
                "Condominio Teste Unitario", new Foto("Foto.jpg", "Foto.jpg"), new Telefone("(21) 99796-7038"),
                0, null, null, null, false, false, false, false, false, false, false, false, false, false, false,
                false, false, false, false);

            condominio.SetEntidadeId(command.CondominioId);

           

            _mocker.GetMock<ICondominioRepository>().Setup(r => r.GrupoJaExiste(command.Descricao,command.CondominioId,command.GrupoId))
                .Returns(Task.FromResult(true));

            _mocker.GetMock<ICondominioRepository>().Setup(r => r.ObterPorId(command.CondominioId))
               .Returns(Task.FromResult(condominio));

            _mocker.GetMock<ICondominioRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _grupoCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<ICondominioRepository>().Verify(r => r.AdicionarGrupo(It.IsAny<Grupo>()), Times.Once);
            _mocker.GetMock<ICondominioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }
    }
}

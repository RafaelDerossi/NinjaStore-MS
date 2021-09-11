﻿using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using CondominioApp.Ocorrencias.App.Models;
using CondominioApp.Ocorrencias.App.Aplication.Commands;

namespace CondominioApp.Ocorrencias.App.Tests
{
   public class RespostaOcorrenciaCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly RespostaOcorrenciaCommandHandler _respostaOcorrenciaCommandCommandHandler;

        public RespostaOcorrenciaCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _respostaOcorrenciaCommandCommandHandler = _mocker.CreateInstance<RespostaOcorrenciaCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar RespostaOcorrenciaSindico Válido")]
        [Trait("Categoria", "RespostasOcorrencias - RespostaOcorrenciaCommandHandler")]
        public async Task AdicionarRespostaOcorrenciaSindico_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var ocorrencia = OcorrenciaFactoryTests.Criar_Ocorrencia_Valida();
            var command = RespostaOcorrenciaCommandFactory.CriarComando_CadastroDeRespostaOcorrenciaSindico();
            ocorrencia.SetEntidadeId(command.OcorrenciaId);

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.ObterPorId(command.OcorrenciaId))
               .Returns(Task.FromResult(ocorrencia));

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _respostaOcorrenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IOcorrenciaRepository>().Verify(r => r.AdicionarResposta(It.IsAny<RespostaOcorrencia>()), Times.Once);
            _mocker.GetMock<IOcorrenciaRepository>().Verify(r => r.Atualizar(It.IsAny<Ocorrencia>()), Times.Once);
            _mocker.GetMock<IOcorrenciaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Adicionar RespostaOcorrenciaSindico em Ocorrencia Resolvida - Inválido")]
        [Trait("Categoria", "RespostasOcorrencias - RespostaOcorrenciaCommandHandler")]
        public async Task AdicionarRespostaOcorrenciaSindico_EmOcorrenciaResolvida_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var ocorrencia = OcorrenciaFactoryTests.Criar_Ocorrencia_Resolvida_Valido();
            var command = RespostaOcorrenciaCommandFactory.CriarComando_CadastroDeRespostaOcorrenciaSindico();
            ocorrencia.SetEntidadeId(command.OcorrenciaId);

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.ObterPorId(command.OcorrenciaId))
               .Returns(Task.FromResult(ocorrencia));

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _respostaOcorrenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }



        [Fact(DisplayName = "Adicionar RespostaOcorrenciaMorador Válido")]
        [Trait("Categoria", "RespostasOcorrencias - RespostaOcorrenciaCommandHandler")]
        public async Task AdicionarRespostaOcorrenciaMorador_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var ocorrencia = OcorrenciaFactoryTests.Criar_Ocorrencia_Valida();
            var command = RespostaOcorrenciaCommandFactory.CriarComando_CadastroDeRespostaOcorrenciaMorador();
            ocorrencia.SetEntidadeId(command.OcorrenciaId);
            ocorrencia.SetMoradorId(command.AutorId);

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.ObterPorId(command.OcorrenciaId))
               .Returns(Task.FromResult(ocorrencia));

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _respostaOcorrenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IOcorrenciaRepository>().Verify(r => r.AdicionarResposta(It.IsAny<RespostaOcorrencia>()), Times.Once);
            _mocker.GetMock<IOcorrenciaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Adicionar RespostaOcorrenciaMorador Em Ocorrencia criada por outro - Inválido")]
        [Trait("Categoria", "RespostasOcorrencias - RespostaOcorrenciaCommandHandler")]
        public async Task AdicionarRespostaOcorrenciaMorador_EmOcorrenciaCriadaPorOutro_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var ocorrencia = OcorrenciaFactoryTests.Criar_Ocorrencia_Valida();
            var command = RespostaOcorrenciaCommandFactory.CriarComando_CadastroDeRespostaOcorrenciaMorador();
            ocorrencia.SetEntidadeId(command.OcorrenciaId);            

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.ObterPorId(command.OcorrenciaId))
               .Returns(Task.FromResult(ocorrencia));

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _respostaOcorrenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);            

        }


        [Fact(DisplayName = "Adicionar RespostaOcorrenciaMorador Em Ocorrencia Resolvida - Inválido")]
        [Trait("Categoria", "RespostasOcorrencias - RespostaOcorrenciaCommandHandler")]
        public async Task AdicionarRespostaOcorrenciaMorador_EmOcorrenciaResolvida_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var ocorrencia = OcorrenciaFactoryTests.Criar_Ocorrencia_Resolvida_Valido();
            var command = RespostaOcorrenciaCommandFactory.CriarComando_CadastroDeRespostaOcorrenciaMorador();
            ocorrencia.SetEntidadeId(command.OcorrenciaId);
            ocorrencia.SetMoradorId(command.AutorId);

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.ObterPorId(command.OcorrenciaId))
               .Returns(Task.FromResult(ocorrencia));

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _respostaOcorrenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);

        }

        [Fact(DisplayName = "Editar RespostaOcorrencia Válido")]
        [Trait("Categoria", "RespostasOcorrencias - RespostaOcorrenciaCommandHandler")]
        public async Task EditarRespostaOcorrencia_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var resposta = RespostaOcorrenciaFactoryTests.Criar_RespostaOcorrencia_Morador_Valido();
            var command = RespostaOcorrenciaCommandFactory.CriarComando_EdicaoDeRespostaOcorrencia();
            resposta.SetEntidadeId(command.OcorrenciaId);
            resposta.SetMoradorIdFuncionarioId(command.AutorId);

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.ObterRespostaPorId(command.Id))
               .Returns(Task.FromResult(resposta));

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _respostaOcorrenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IOcorrenciaRepository>().Verify(r => r.AtualizarResposta(It.IsAny<RespostaOcorrencia>()), Times.Once);
            _mocker.GetMock<IOcorrenciaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Editar RespostaOcorrencia ja vista - Inválido")]
        [Trait("Categoria", "RespostasOcorrencias - RespostaOcorrenciaCommandHandler")]
        public async Task EditarRespostaOcorrencia_JaVista_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var resposta = RespostaOcorrenciaFactoryTests.Criar_RespostaOcorrencia_Morador_Valido();
            var command = RespostaOcorrenciaCommandFactory.CriarComando_EdicaoDeRespostaOcorrencia();
            resposta.SetEntidadeId(command.OcorrenciaId);
            resposta.SetMoradorIdFuncionarioId(command.AutorId);
            resposta.MarcarComoVisto();

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.ObterRespostaPorId(command.Id))
               .Returns(Task.FromResult(resposta));

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _respostaOcorrenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
            
        }
    }
}

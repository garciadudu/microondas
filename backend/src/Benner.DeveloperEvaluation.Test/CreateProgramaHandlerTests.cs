using Benner.DeveloperEvaluation.Application.Programa.CreatePrograma;
using Benner.DeveloperEvaluation.Domain.Entities;
using Benner.DeveloperEvaluation.Domain.Repositories;
using Benner.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using NSubstitute;
using FluentAssertions;
using Xunit;

namespace Benner.DeveloperEvaluation.Unit
{
    public class CreateProgramaHandlerTests
    {
        private readonly IProgramaMicroondaRepository _programaMicroondaRepository;
        private readonly IMapper _mapper;
        private readonly CreateProgramaHandler _handler;

        public CreateProgramaHandlerTests()
        {
            _programaMicroondaRepository = Substitute.For<IProgramaMicroondaRepository>();
            _mapper = Substitute.For<IMapper>();

            _handler = new CreateProgramaHandler(_programaMicroondaRepository, _mapper);
        }

        [Fact(DisplayName = "Dado um programa de micro-ondas válido, quando criando um programa de micro-ondas então retorna resposta de sucesso")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            var command = CreateProgramaHandlerTestData.GenerateValidCommand();

            var programa = new ProgramaMicroonda
            {
                Id = Guid.NewGuid(),
                Alimento = command.Alimento,
                Aquecimento = command.Aquecimento,
                Instrucoes = command.Instrucoes,
                Nome = command.Nome,
                Potencia = command.Potencia,
                Tempo = command.Tempo,
            };

            var result = new CreateProgramaResult
            {
                Id = programa.Id,
            };

            _mapper.Map<ProgramaMicroonda>(command).Returns(programa);
            _mapper.Map<CreateProgramaResult>(result).Returns(result);

            var createProgramaResult = await _handler.Handle(command, CancellationToken.None);

            createProgramaResult.Should().NotBeNull();

            createProgramaResult.Id.Should().Be(programa.Id);
            await _programaMicroondaRepository.Received(1).CreateAsync(Arg.Any<ProgramaMicroonda>(), Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "Dado um comando válido, quando manipula os mapas para Programa Micro-ondas")]
        public async Task Handle_ValidRequest_MapsCommandToProgramaMicroondas()
        {
            var command = CreateProgramaHandlerTestData.GenerateValidCommand();

            var programa = new ProgramaMicroonda
            {
                Id = Guid.NewGuid(),
                Alimento = command.Alimento,
                Aquecimento = command.Aquecimento,
                Instrucoes = command.Instrucoes,
                Nome = command.Nome,
                Potencia = command.Potencia,
                Tempo = command.Tempo,
            };

            _mapper.Map<ProgramaMicroonda>(command).Returns(programa);
            _programaMicroondaRepository.CreateAsync(Arg.Any<ProgramaMicroonda>(), Arg.Any<CancellationToken>())
                .Returns(programa);

            // When
            await _handler.Handle(command, CancellationToken.None);

            // Then
            _mapper.Received(1).Map<ProgramaMicroonda>(Arg.Is<CreateProgramaCommand>(c =>
                c.Alimento == command.Alimento &&
                c.Aquecimento == command.Aquecimento &&
                c.Instrucoes == command.Instrucoes &&
                c.Nome == command.Nome &&
                c.Potencia == command.Potencia &&
                c.Tempo == command.Tempo
            ));
        }
    }
}
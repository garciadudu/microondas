using Benner.DeveloperEvaluation.Application.Programa.CreatePrograma;
using Bogus;

namespace Benner.DeveloperEvaluation.Unit.Application.TestData
{
    public static class CreateProgramaHandlerTestData
    {

        private static readonly Faker<CreateProgramaCommand> createProgramaHandlerFaker = new Faker<CreateProgramaCommand>()
            .RuleFor(x => x.Id, f => f.Random.Guid().ToString())
            .RuleFor(x => x.Nome, f => f.Random.ToString())
            .RuleFor(x => x.Alimento, f => f.Random.ToString())
            .RuleFor(x => x.Tempo, f => f.Random.Double())
            .RuleFor(x => x.Potencia, f => f.Random.Int())
            .RuleFor(x => x.Aquecimento, f => f.Random.ToString())
            .RuleFor(x => x.Instrucoes, f => f.Random.ToString());

        public static CreateProgramaCommand GenerateValidCommand()
        {
            return createProgramaHandlerFaker.Generate();
        }
    }
}

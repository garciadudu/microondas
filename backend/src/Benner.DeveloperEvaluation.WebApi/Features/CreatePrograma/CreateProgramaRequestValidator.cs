using FluentValidation;

namespace Benner.DeveloperEvaluation.WebApi.Features.CreatePrograma
{
    public class CreateProgramaRequestValidator : AbstractValidator<CreateProgramaRequest>
    {
        public CreateProgramaRequestValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().Length(3, 50);
            RuleFor(x => x.Alimento).NotEmpty().Length(3, 50);
            RuleFor(x => x.Nome).Must(y => !y.Equals('.')).WithMessage("Programa não deve ser.");
        }
    }
}
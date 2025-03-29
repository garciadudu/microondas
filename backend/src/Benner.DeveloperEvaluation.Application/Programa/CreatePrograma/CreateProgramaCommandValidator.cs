using FluentValidation;

namespace Benner.DeveloperEvaluation.Application.Programa.CreatePrograma
{
    public class CreateProgramaCommandValidator : AbstractValidator<CreateProgramaCommand>
    {
        public CreateProgramaCommandValidator() 
        {
            RuleFor(x => x.Nome).NotEmpty().Length(3, 50);
            RuleFor(x => x.Alimento).NotEmpty().Length(3, 50);
            RuleFor(x => x.Nome).Must(y => !y.Equals('.')).WithMessage("Programa não deve ser.");
        }
    }
}

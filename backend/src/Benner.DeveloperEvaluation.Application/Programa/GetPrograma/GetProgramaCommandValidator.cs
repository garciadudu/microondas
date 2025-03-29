using FluentValidation;

namespace Benner.DeveloperEvaluation.Application.Programa.GetPrograma
{
    public class GetProgramaCommandValidator : AbstractValidator<GetProgramaCommand>
    {
        public GetProgramaCommandValidator() 
        {
            RuleFor(x => x.Nome).NotEmpty().Length(3, 50);
            RuleFor(x => x.Alimento).NotEmpty().Length(3, 50);
            RuleFor(x => x.Nome).Must(y => !y.Equals('.')).WithMessage("Programa não deve ser.");
        }
    }
}

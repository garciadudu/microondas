using Benner.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Benner.DeveloperEvaluation.Application.Programa.CreatePrograma
{
    public class CreateProgramaCommand: IRequest<CreateProgramaResult>
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Alimento { get; set; }
        public double Tempo { get; set; }
        public int Potencia { get; set; }
        public string Aquecimento { get; set; }
        public string Instrucoes { get; set; }


        public ValidationResultDetail Validate()
        {
            var validator = new CreateProgramaCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}

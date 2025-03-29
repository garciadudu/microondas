using Benner.DeveloperEvaluation.Domain.Common;

namespace Benner.DeveloperEvaluation.Domain.Entities
{
    public class ProgramaMicroonda: BaseEntity
    {
        public string Nome { get; set; }
        public string Alimento { get; set; }
        public double Tempo { get; set; }
        public int Potencia { get; set; }
        public string Aquecimento { get; set; }
        public string Instrucoes { get; set; }
    }
}

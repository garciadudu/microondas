using Benner.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benner.DeveloperEvaluation.ORM.Mapping
{
    public class ProgramaMicroondaConfiguration: IEntityTypeConfiguration<ProgramaMicroonda>
    {
        public void Configure(EntityTypeBuilder<ProgramaMicroonda> builder) 
        {
            builder.ToTable("ProgramaMicroondas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasMaxLength(255);
            builder.Property(x => x.Alimento).HasMaxLength(255);
            builder.Property(x => x.Tempo);
            builder.Property(x => x.Potencia);
            builder.Property(x => x.Aquecimento).HasMaxLength(255);
            builder.Property(x => x.Instrucoes).HasMaxLength(255);
        }
    }
}

using AutoMapper;
using Benner.DeveloperEvaluation.Domain.Entities;

namespace Benner.DeveloperEvaluation.Application.Programa.CreatePrograma
{
    public class CreateProgramaProfile : Profile
    {
        public CreateProgramaProfile() 
        {
            CreateMap<CreateProgramaCommand, ProgramaMicroonda>();
            CreateMap<ProgramaMicroonda, CreateProgramaResult>();
        }
    }
}

using AutoMapper;
using Benner.DeveloperEvaluation.Domain.Entities;

namespace Benner.DeveloperEvaluation.Application.Programa.GetPrograma
{
    public class GetProgramaProfile : Profile
    {
        public GetProgramaProfile() 
        {
            CreateMap<GetProgramaCommand, ProgramaMicroonda>();
            CreateMap<ProgramaMicroonda, GetProgramaResult>();
        }
    }
}

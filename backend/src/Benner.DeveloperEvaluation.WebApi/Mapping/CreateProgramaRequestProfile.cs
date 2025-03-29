using AutoMapper;
using Benner.DeveloperEvaluation.Application.Programa.CreatePrograma;
using Benner.DeveloperEvaluation.WebApi.Features.CreatePrograma;

namespace Benner.DeveloperEvaluation.WebApi.Mapping
{
    public class CreateProgramaRequestProfile : Profile
    {
        public CreateProgramaRequestProfile()
        {
            CreateMap<CreateProgramaRequest, CreateProgramaCommand>();
        }
    }
}

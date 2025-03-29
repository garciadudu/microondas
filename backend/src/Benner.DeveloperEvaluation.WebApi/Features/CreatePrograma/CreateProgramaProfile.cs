using AutoMapper;
using Benner.DeveloperEvaluation.Application.Programa.CreatePrograma;

namespace Benner.DeveloperEvaluation.WebApi.Features.CreatePrograma
{
    public class CreateProgramaProfile: Profile
    {
        public CreateProgramaProfile()
        {
            CreateMap<CreateProgramaResult, CreateProgramaCommand>();
            CreateMap<CreateProgramaResult, CreateProgramaResponse>();
        }
        protected internal CreateProgramaProfile(string profileName): base(profileName) { }

        protected internal CreateProgramaProfile(string profileName, Action<IProfileExpression> configurationAction) : base(profileName, configurationAction) { }
    }
}

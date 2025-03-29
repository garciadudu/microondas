using AutoMapper;
using Benner.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Benner.DeveloperEvaluation.Application.Programa.GetPrograma
{
    public class GetProgramaHandler: IRequestHandler<GetProgramaCommand, GetProgramaResult>
    {
        private readonly IProgramaMicroondaRepository _programaMicroondaRepository;
        private readonly IMapper _mapper;

        public GetProgramaHandler(IProgramaMicroondaRepository programaMicroondaRepository, IMapper mapper)
        {
            _programaMicroondaRepository = programaMicroondaRepository;
            _mapper = mapper;
        }

        public async Task<GetProgramaResult> Handle(GetProgramaCommand command, CancellationToken cancellationToken)
        {
            var validatior = new GetProgramaCommandValidator();
            var validationResult = await validatior.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var programaMicroonda = _mapper.Map<Domain.Entities.ProgramaMicroonda>(command);

            var getProgramaMicroonda = await _programaMicroondaRepository.GetByIdAsync(programaMicroonda.Id);

            var result = _mapper.Map<GetProgramaResult>(getProgramaMicroonda);

            return result;
        }
    }
}

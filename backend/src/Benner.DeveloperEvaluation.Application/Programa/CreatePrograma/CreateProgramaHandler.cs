using AutoMapper;
using Benner.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Benner.DeveloperEvaluation.Application.Programa.CreatePrograma
{
    public class CreateProgramaHandler: IRequestHandler<CreateProgramaCommand, CreateProgramaResult>
    {
        private readonly IProgramaMicroondaRepository _programaMicroondaRepository;
        private readonly IMapper _mapper;

        public CreateProgramaHandler(IProgramaMicroondaRepository programaMicroondaRepository, IMapper mapper)
        {
            _programaMicroondaRepository = programaMicroondaRepository;
            _mapper = mapper;
        }

        public async Task<CreateProgramaResult> Handle(CreateProgramaCommand command, CancellationToken cancellationToken)
        {
            var validatior = new CreateProgramaCommandValidator();
            var validationResult = await validatior.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var programaMicroonda = _mapper.Map<Domain.Entities.ProgramaMicroonda>(command);

            var createProgramaMicroonda = await _programaMicroondaRepository.CreateAsync(programaMicroonda);

            var result = _mapper.Map<CreateProgramaResult>(createProgramaMicroonda);

            return result;
        }
    }
}

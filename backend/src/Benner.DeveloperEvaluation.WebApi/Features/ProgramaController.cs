using AutoMapper;
using Benner.DeveloperEvaluation.Domain.Repositories;
using Benner.DeveloperEvaluation.WebApi.Common;
using Benner.DeveloperEvaluation.WebApi.Features.CreatePrograma;
using Benner.DeveloperEvaluation.WebApi.Features.GetPrograma;
using Benner.DeveloperEvaluation.WebApi.Features.ListPrograma;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Benner.DeveloperEvaluation.WebApi.Features
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramaController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IProgramaMicroondaRepository _programaMicroondaRepository;

        public ProgramaController(IMediator mediator, IMapper mapper, IProgramaMicroondaRepository programaMicroondaRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _programaMicroondaRepository = programaMicroondaRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateProgramaResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePrograma([FromBody] CreateProgramaRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateProgramaRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var command = _mapper.Map<Application.Programa.CreatePrograma.CreateProgramaCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateProgramaResponse>
            {
                Success = true,
                Message = "Programa created sucessfully",
                Data = _mapper.Map<CreateProgramaResponse>(response)
            });

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetProgramaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPrograma([FromBody] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetProgramaRequest { Id = id };
            var validator = new GetProgramaRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var command = _mapper.Map<Application.Programa.GetPrograma.GetProgramaCommand>(request.Id);
            var response = _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetProgramaResponse>
            {
                Success = true,
                Message = "Programa retrieved successfully",
                Data = _mapper.Map<GetProgramaResponse>(response),
            });
        }

        [HttpGet("/api/ProgramaMicrondas")]
        [ProducesResponseType(typeof(ApiResponseWithData<ListProgramaResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList(CancellationToken cancellationToken)
        {
            var result = await _programaMicroondaRepository.ListAsync(cancellationToken);


            var list = result.Select(x => new ListProgramaResponse
            {
                Id = x.Id.ToString(),
                Nome = x.Nome,
                Alimento = x.Alimento,
                Tempo = x.Tempo,
                Potencia = x.Potencia,
                Aquecimento = x.Aquecimento,
                Instrucoes = x.Instrucoes,
            });

            return Ok(new ApiResponseWithData<IEnumerable<ListProgramaResponse>>
            {
                Success = true,
                Message = "Programa retrieved successfully",
                Data = list
            });
        }
    }
}

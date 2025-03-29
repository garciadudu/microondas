using Benner.DeveloperEvaluation.Domain.Entities;

namespace Benner.DeveloperEvaluation.Domain.Repositories
{
    public interface IProgramaMicroondaRepository
    {
        Task<ProgramaMicroonda> CreateAsync(ProgramaMicroonda programaMicroonda, CancellationToken cancellationToken = default);
        Task<ProgramaMicroonda?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<ProgramaMicroonda>> ListAsync(CancellationToken cancellationToken = default);
    }
}

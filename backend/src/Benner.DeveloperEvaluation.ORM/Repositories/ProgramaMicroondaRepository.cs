using Benner.DeveloperEvaluation.Domain.Entities;
using Benner.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Benner.DeveloperEvaluation.ORM.Repositories
{
    public class ProgramaMicroondaRepository: IProgramaMicroondaRepository
    {
        private readonly DefaultContext _context;

        public ProgramaMicroondaRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<ProgramaMicroonda> CreateAsync(ProgramaMicroonda programaMicroonda, CancellationToken cancellationToken = default)
        {
            await _context.ProgramaMicroondas.AddAsync(programaMicroonda, cancellationToken);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
            }
            return programaMicroonda;
        }

        public async Task<ProgramaMicroonda?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.ProgramaMicroondas.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await GetByIdAsync(id, cancellationToken);

            if (user == null)
                return false;

            _context.ProgramaMicroondas.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<ProgramaMicroonda>> ListAsync(CancellationToken cancellationToken = default)
        {
            var lists = await _context.ProgramaMicroondas
                .ToListAsync(cancellationToken);

            return lists;
        }
    }
}

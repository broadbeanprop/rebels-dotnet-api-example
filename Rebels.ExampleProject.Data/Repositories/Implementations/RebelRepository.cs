using Microsoft.EntityFrameworkCore;
using Rebels.ExampleProject.Data.Entities;

namespace Rebels.ExampleProject.Data.Repositories.Implementations;

public class RebelRepository : IRebelRepository
{
    private readonly DataContext _context;

    public RebelRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Rebel> CreateAsync(Rebel rebel, CancellationToken cancellationToken)
    {
        _context.Rebels.Add(rebel);
        await _context.SaveChangesAsync(cancellationToken);

        return rebel;
    }

    public IQueryable<Rebel> Get()
    {
        return _context.Rebels.AsQueryable();
    }
    
    public async Task<Rebel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Rebels.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    
    public async Task<Rebel> UpdateAsync(Rebel rebel, CancellationToken cancellationToken)
    {
        _context.Rebels.Update(rebel);
        await _context.SaveChangesAsync(cancellationToken);

        return rebel;
    }
    
    public async Task DeleteAsync(Rebel rebel, CancellationToken cancellationToken)
    {
        _context.Rebels.Remove(rebel);
        await _context.SaveChangesAsync(cancellationToken);
    }
}

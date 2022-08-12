using Rebels.ExampleProject.Data.Entities;

namespace Rebels.ExampleProject.Data.Repositories;

public interface IRebelRepository
{
    Task<Rebel> CreateAsync(Rebel rebel, CancellationToken cancellationToken);
    IQueryable<Rebel> Get();
    Task<Rebel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Rebel> UpdateAsync(Rebel rebel, CancellationToken cancellationToken);
    Task DeleteAsync(Rebel rebel, CancellationToken cancellationToken);
}
using Rebels.ExampleProject.Api.Dtos;

namespace Rebels.ExampleProject.Core.Services;

public interface IRebelService
{
    Task<IEnumerable<RebelDto>> GetRebelsAsync(CancellationToken cancellationToken);
    Task<RebelDto?> GetRebelByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<RebelDto> AddRebelAsync(RebelDto rebelDto, CancellationToken cancellationToken);
    Task<RebelDto> UpdateRebelAsync(RebelDto rebelDto, CancellationToken cancellationToken);
    Task DeleteRebelAsync(RebelDto rebelDto, CancellationToken cancellationToken);
}
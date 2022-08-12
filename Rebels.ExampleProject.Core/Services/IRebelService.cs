using Rebels.ExampleProject.Api.Dtos;

namespace Rebels.ExampleProject.Core.Services;

public interface IRebelService
{
    Task<IEnumerable<RebelDto>> GetRebels(CancellationToken cancellationToken);
    Task<RebelDto?> GetRebelById(Guid id, CancellationToken cancellationToken);
    Task<RebelDto> AddRebel(RebelDto rebelDto, CancellationToken cancellationToken);
    Task<RebelDto> UpdateRebel(RebelDto rebelDto, CancellationToken cancellationToken);
    Task DeleteRebel(RebelDto rebelDto, CancellationToken cancellationToken);
}
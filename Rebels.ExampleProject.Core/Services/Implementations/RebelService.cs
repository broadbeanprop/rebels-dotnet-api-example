using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rebels.ExampleProject.Api.Dtos;
using Rebels.ExampleProject.Data.Entities;
using Rebels.ExampleProject.Data.Repositories;

namespace Rebels.ExampleProject.Core.Services.Implementations;

public class RebelService : IRebelService
{
    private readonly IRebelRepository _repository;
    private readonly IMapper _mapper;

    public RebelService(IRebelRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RebelDto>> GetRebels(CancellationToken cancellationToken)
    {
        var rebels = await _repository.Get().ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<RebelDto>>(rebels);
    }
    
    public async Task<RebelDto?> GetRebelById(Guid id, CancellationToken cancellationToken)
    {
        var rebel = await _repository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<RebelDto>(rebel);
    }
    
    public async Task<RebelDto> AddRebel(RebelDto rebelDto, CancellationToken cancellationToken)
    {
        var newRebel = await _repository.CreateAsync(_mapper.Map<Rebel>(rebelDto), cancellationToken);
        return _mapper.Map<RebelDto>(newRebel);
    }
    
    public async Task<RebelDto> UpdateRebel(RebelDto rebelDto, CancellationToken cancellationToken)
    {
        var rebel = await _repository.UpdateAsync(_mapper.Map<Rebel>(rebelDto), cancellationToken);
        return _mapper.Map<RebelDto>(rebel);
    }
    
    public async Task DeleteRebel(RebelDto rebelDto, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(_mapper.Map<Rebel>(rebelDto), cancellationToken);
    }
}
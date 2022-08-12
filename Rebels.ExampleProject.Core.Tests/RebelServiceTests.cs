using AutoMapper;
using Rebels.ExampleProject.Api.Dtos;
using Rebels.ExampleProject.Core.AutoMapper;
using Rebels.ExampleProject.Core.Services.Implementations;
using Rebels.ExampleProject.Data.Entities;
using Rebels.ExampleProject.Data.Repositories;

namespace Rebels.ExampleProject.Core.Tests;

public class RebelServiceTests
{
    private readonly IMapper _mapper;
    private readonly Fixture _fixture;
    private readonly Mock<IRebelRepository> _repositoryMock;
    
    public RebelServiceTests()
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutomapperProfile());
        });
        _mapper = mappingConfig.CreateMapper();
        
        _fixture = new Fixture();
        _repositoryMock = new Mock<IRebelRepository>();
    }

    [Fact(DisplayName = "Add Rebel")]
    public async Task Test1()
    {
        var rebelDtoFixture = _fixture.Create<RebelDto>();
        var rebelFixture = _fixture
            .Build<Rebel>()
            .With(x => x.Id, rebelDtoFixture.Id)
            .With(x => x.Name, rebelDtoFixture.Name)
            .Create();

        _repositoryMock
            .Setup(x => 
                x.CreateAsync(It.IsAny<Rebel>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(rebelFixture);
        
        var service = new RebelService(_repositoryMock.Object, _mapper);

        var rebel = await service.AddRebelAsync(rebelDtoFixture, CancellationToken.None);
        
        Assert.Equal(rebelDtoFixture.Id, rebel.Id);
        Assert.Equal(rebelDtoFixture.Name, rebel.Name);
    }
}
using Betting.API.Controllers;
using Betting.Application.Fixture;
using Betting.Application.Fixture.Queries;
using Betting.Test.Fixtures;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Betting.Test.System.Controllers;
public class FixtureControllerTests
{
    private readonly Mock<ILogger<FixtureController>> loggerMock = new Mock<ILogger<FixtureController>>();
    private readonly Mock<IMediator> mediatrMock = new Mock<IMediator>();

    [Fact]
    public async Task Get_WhenIsCalled_ReturnsOk()
    {
        //Arrange
        var request = new ListFixturesQuery();
        var sut = new FixtureController(loggerMock.Object, mediatrMock.Object);
        var fixtures = BettingFixtureTestFixtures.GetTestFixtureList();

        mediatrMock.Setup(x => x.Send(request, It.IsAny<CancellationToken>())).ReturnsAsync(fixtures);

        //Act
        var response = await sut.Get(It.IsAny<CancellationToken>(), request);

        //Assert
        response.Should().NotBeNull();
        response.Result.Should().BeOfType<OkObjectResult>();

        var result = (OkObjectResult)response.Result;
        result.Value.Should().NotBeNull();
        result.Value.Should().BeOfType<List<FixtureListItemDto>>();
        result.StatusCode.Should().Be(200);

        var returnedFixtures = (List<FixtureListItemDto>)result.Value;
        returnedFixtures.Should().BeEquivalentTo(fixtures);
    }

    [Fact]
    public async Task Get_WhenFixtureNotFound_ReturnsNotFound()
    {
        //Arrange
        var request = new ListFixturesQuery();
        var sut = new FixtureController(loggerMock.Object, mediatrMock.Object);

        mediatrMock.Setup(x => x.Send(request, It.IsAny<CancellationToken>())).ReturnsAsync(new List<FixtureListItemDto>());

        //Act
        var response = await sut.Get(It.IsAny<CancellationToken>(), request);

        //Assert
        response.Should().NotBeNull();
        response.Result.Should().BeOfType<NotFoundResult>();
        var result = (NotFoundResult)response.Result;
        result.StatusCode.Should().Be(404);
    }
}
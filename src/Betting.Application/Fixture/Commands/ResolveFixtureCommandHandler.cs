using Betting.Application.Common.Exceptions;
using Betting.Domain.Contracts;
using Betting.Domain.Enums;
using Betting.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Betting.Application.Fixture.Commands;
public class ResolveFixtureCommandHandler : IRequestHandler<ResolveFixtureCommand, Unit>
{
    private readonly IMediator _mediator;
    private readonly ICommandDBContext _commandDBContext;

    public ResolveFixtureCommandHandler(IMediator mediator, ICommandDBContext commandDBContext)
    {
        _mediator = mediator;
        _commandDBContext = commandDBContext;
    }
    public async Task<Unit> Handle(ResolveFixtureCommand request, CancellationToken cancellationToken)
    {
        var fixture = await _commandDBContext.Fixtures.FirstOrDefaultAsync(x => x.Id == request.FixtureId, cancellationToken);

        if (fixture is null)
            throw new CustomException($"Fixture {request.FixtureId} has not been found.");

        if (fixture.FixtureStatusId != (short)FixtureStatus.Active)
            throw new CustomException($"Fixture {request.FixtureId} could not be resolved.");

        fixture.FixtureStatusId = (short)FixtureStatus.Finished;
        await _commandDBContext.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new FixtureResolvedEvent(fixture.Id), cancellationToken);

        return Unit.Value;
    }
}
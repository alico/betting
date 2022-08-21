using Betting.Application.Common.Exceptions;
using Betting.Application.Fixture;
using Betting.Application.Fixture.Commands;
using Betting.Application.Fixture.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Betting.API.Controllers
{
    public class FixtureController : BaseController
    {
        public FixtureController(ILogger<FixtureController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        /// <summary>
        /// Lists fixtures by competition
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseWrapper<ErrorResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<FixtureListItemDto>), StatusCodes.Status200OK)]
        [ResponseCache(VaryByQueryKeys = new[] { "*" }, Duration = 60)]
        public async Task<ActionResult<IEnumerable<FixtureListItemDto>>> Get(CancellationToken cancellationToken, [FromQuery] ListFixturesQuery request)
        {
            var response = await _mediator.Send(request, cancellationToken);

            if (!response.Any())
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Creates a fixture
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseWrapper<ErrorResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Post(AddFixtureCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return Ok();
        }

    }
}
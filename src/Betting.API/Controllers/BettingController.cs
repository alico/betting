using Betting.Application.Betting;
using Betting.Application.Betting.Commands;
using Betting.Application.Betting.Queries;
using Betting.Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Betting.API.Controllers
{
    public class BettingController : BaseController
    {
        public BettingController(ILogger<BettingController> logger, IMediator mediator) : base(logger, mediator)
        {

        }

        /// <summary>
        /// Lists a user's bets
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseWrapper<ErrorResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<BetListItemDto>), StatusCodes.Status200OK)]
        [ResponseCache(VaryByQueryKeys = new[] { "*" }, Duration = 60)]
        public async Task<ActionResult<IEnumerable<BetListItemDto>>> Get(CancellationToken cancellationToken, [FromQuery] ListUserBetsQuery request)
        {
            var response = await _mediator.Send(request, cancellationToken);

            if (!response.Any())
                return NotFound();

            return Ok(response);
        }


        /// <summary>
        /// Places a bet
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseWrapper<ErrorResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public async Task<ActionResult> Post(PlaceBetCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
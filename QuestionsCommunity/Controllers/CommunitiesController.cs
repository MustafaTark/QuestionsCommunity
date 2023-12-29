using Application.Comminuties.Commands.Create;
using Application.Comminuties.Queries.GetAll;
using Application.Questions.Commands.Create;
using Application.Questions.Queries.GetAll;
using Domain.Dto.Community;
using Domain.Dto.Questions;
using Infrastructure.RequestParamters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommunitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateCommunity")]
        public async Task<IActionResult> CreateCommunity([FromBody] CommunityForCreateDto community)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _mediator.Send(new CreateCommunityCommand(community));
            return StatusCode(201);
        }
        [HttpGet("GetAllCommunities")]
        public async Task<IActionResult> GetAllCommunities([FromQuery] CommunityParamters paramters)
        {
            var questions = await _mediator.Send(new GetAllCommunitiesQuery(paramters));
            return Ok(questions);
        }
    }
}

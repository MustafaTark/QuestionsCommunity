using Application.Tags.Commands.Create;
using Application.Tags.Queries.GetAll;
using Domain.Dto.Tags;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateTag")]
        public async Task<IActionResult> CreateTag(TagForCreateDto tag)
        {
            await  _mediator.Send(new CreateTagCommand(tag));
            return Created("","");
        }
        [HttpGet("GetAllTags")]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await _mediator.Send(new GetAllTagsQuery());
            return Ok(tags);
        }
    }
}

using Application.Comments.Commands.Create;
using Application.Comments.Queries.GetAllCommentsByQuestuionId;
using Domain.Dto.Comments;
using Infrastructure.RequestParamters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment(CommentForCreateDto comment)
        {
            await _mediator.Send(new CreateCommentCommand(comment));
            return Created("","");
        }
        [HttpGet("GetAllCommentsByQuestionId")]
        public async Task<IActionResult> GetAllCommentsByQuestionId(CommentParamters paramters)
        {
            var comments = await _mediator.Send(new GetAllCommemtsByQuestuionIdQuery(paramters));
            return Ok(comments);
        }
    }
}

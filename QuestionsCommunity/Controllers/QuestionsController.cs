using Application.Questions.Commands.Create;
using Application.Questions.Queries.GetAll;
using Domain.Dto.Questions;
using Infrastructure.RequestParamters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion([FromForm] QuestionForCreateDto question)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await  _mediator.Send(new CreateQuestionCommand(question));
            return StatusCode(201);
        }
        [HttpGet("GetAllQuestions")]
        public async Task<IActionResult> GetAllQuestions([FromQuery]QuestionParamters paramters)
        {
            var questions = await _mediator.Send(new GetAllQuestionsQuery(paramters));
            return Ok(questions);
        }
    }
}

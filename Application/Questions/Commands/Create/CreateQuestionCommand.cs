using Domain.Dto.Questions;
using Domain.Models.Questions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Questions.Commands.Create
{
    public record CreateQuestionCommand(QuestionForCreateDto Question) : IRequest;
}

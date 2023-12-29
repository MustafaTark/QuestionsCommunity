using Domain.Dto.Questions;
using Domain.Models.Questions;
using Infrastructure.RequestParamters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Questions.Queries.GetAll
{
    public record GetAllQuestionsQuery(QuestionParamters Paramters): IRequest<IEnumerable<QuestionDto>>;
}

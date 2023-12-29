using Domain.Dto.Questions;
using Infrastructure.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Questions.Queries.GetAll
{
    public class GetAllQuestionsQueryHandler : IRequestHandler<GetAllQuestionsQuery,IEnumerable<QuestionDto>>
    {
        private readonly IQuestionRepository _questionRepository;
        public GetAllQuestionsQueryHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<IEnumerable<QuestionDto>> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.FindAll(false)
                                                     .Select(q=> new QuestionDto
                                                     {
                                                         Content = q.Content,
                                                         CreatedDate = q.CreatedDate,
                                                         Id = q.Id,
                                                         Title = q.Title
                                                     })
                                                     .Skip((request.Paramters.PageNumber - 1) * request.Paramters.PageSize)
                                                     .Take(request.Paramters.PageSize)
                                                     .ToListAsync();
            return questions;
        }
    }
}

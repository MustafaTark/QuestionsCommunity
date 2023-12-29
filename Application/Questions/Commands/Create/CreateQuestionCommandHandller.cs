using Domain.Models.Questions;
using Infrastructure.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Questions.Commands.Create
{
    public class CreateQuestionCommandHandller : IRequestHandler<CreateQuestionCommand>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IFilesManager _filesManager;
        public CreateQuestionCommandHandller(IQuestionRepository questionRepository,IFilesManager filesManager)
        {
            _questionRepository = questionRepository;
            _filesManager = filesManager;
        }
        public async Task Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            List<QuestionFile> questionFiles = new List<QuestionFile>();
            foreach(var file in request.Question.Files) 
            { 
                string url = _filesManager.UploadFiles(file);
                var questionFile = QuestionFile.Create(url);
                questionFiles.Add(questionFile);
            }
          var question =   Question.Create(request.Question.Title,request.Question.Content,request.Question.CommunityId, questionFiles);
            _questionRepository.Create(question);
        }
    }
}

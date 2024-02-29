using Domain.Models.Comments;
using Domain.Models.Questions;
using Infrastructure.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Commands.Create
{
    public class CreateCommentCommandHandller : IRequestHandler<CreateCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IFilesManager _filesManager;
        public CreateCommentCommandHandller(ICommentRepository commentRepository, IFilesManager filesManager)
        {
            _filesManager = filesManager;
            _commentRepository = commentRepository;
        }
        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            List<CommentFile> commentFiles = new List<CommentFile>();
            foreach (var file in request.Comment.Files)
            {
                string url = _filesManager.UploadFiles(file);
                var commentFile = CommentFile.Create(url);
                commentFiles.Add(commentFile);
            }
            var comment = Comment.Create(request.Comment.Content,
                                            request.Comment.QuestionId,
                                            commentFiles);
            _commentRepository.Create(comment);
        }
    }
}

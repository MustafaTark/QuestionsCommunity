using Domain.Dto.Comments;
using Infrastructure.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Queries.GetAllCommentsByQuestuionId
{
    public class GetAllCommemtsByQuestuionIdQueryHandller : IRequestHandler<GetAllCommemtsByQuestuionIdQuery, IEnumerable<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        public GetAllCommemtsByQuestuionIdQueryHandller(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<IEnumerable<CommentDto>> Handle(GetAllCommemtsByQuestuionIdQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.FindByCondition(c => c.QuestionId == request.paramters.QuestionId, false)
                                             .Select(c => new CommentDto
                                             {
                                                 Id = c.Id,
                                                 QuestionId = c.QuestionId,
                                                 Content = c.Content,
                                                 CreatedDate = c.CreatedDate
                                             }).ToListAsync();
            return comments;
        }
    }
}

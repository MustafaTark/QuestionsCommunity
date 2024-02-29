using Domain.Dto.Comments;
using Infrastructure.RequestParamters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Queries.GetAllCommentsByQuestuionId
{
    public record GetAllCommemtsByQuestuionIdQuery(CommentParamters paramters) : IRequest<IEnumerable<CommentDto>>;
}

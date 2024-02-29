using Domain.Dto.Comments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Commands.Create
{
    public record CreateCommentCommand(CommentForCreateDto Comment) : IRequest;
}

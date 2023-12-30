using Domain.Dto.Tags;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tags.Commands.Create
{
    public record CreateTagCommand(TagForCreateDto Tag):IRequest;
}

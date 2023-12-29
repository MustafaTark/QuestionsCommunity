using Domain.Dto.Community;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comminuties.Commands.Create
{
    public record CreateCommunityCommand(CommunityForCreateDto CommunityDto) : IRequest;
}

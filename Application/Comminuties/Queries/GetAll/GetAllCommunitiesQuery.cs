using Domain.Dto.Community;
using Infrastructure.RequestParamters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comminuties.Queries.GetAll
{
    public record GetAllCommunitiesQuery(CommunityParamters paramters) : IRequest<IEnumerable<CommunityDto>>;
}

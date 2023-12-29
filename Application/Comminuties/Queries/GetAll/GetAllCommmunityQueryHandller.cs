using Domain.Dto.Community;
using Infrastructure.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comminuties.Queries.GetAll
{
    public class GetAllCommmunityQueryHandller : IRequestHandler<GetAllCommunitiesQuery,IEnumerable<CommunityDto>>
    {
        private readonly ICommunityRepository _communityRepository;
        public GetAllCommmunityQueryHandller(ICommunityRepository communityRepository)
        {
            _communityRepository = communityRepository;
        }

        public async Task<IEnumerable<CommunityDto>> Handle(GetAllCommunitiesQuery request, CancellationToken cancellationToken)
        {
            var communities = await _communityRepository
                                    .FindAll(trackChanges: false)
                                    .Select(c=> new CommunityDto
                                    { 
                                        Id = c.Id,
                                        Name = c.Name,
                                        Description = c.Description
                                    })
                                    .ToListAsync();
            return communities;
        }
    }
}

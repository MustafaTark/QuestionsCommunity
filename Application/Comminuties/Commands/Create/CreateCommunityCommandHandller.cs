using Domain.Models.Communities;
using Infrastructure.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comminuties.Commands.Create
{
    public class CreateCommunityCommandHandller : IRequestHandler<CreateCommunityCommand>
    {
        private readonly ICommunityRepository _communityRepository;
        public CreateCommunityCommandHandller(ICommunityRepository communityRepository)
        {
            _communityRepository = communityRepository;
        }
        public async Task Handle(CreateCommunityCommand request, CancellationToken cancellationToken)
        {
            var community = Community.Create(request.CommunityDto.Name, request.CommunityDto.Description);
            _communityRepository.Create(community);
        }
    }
}

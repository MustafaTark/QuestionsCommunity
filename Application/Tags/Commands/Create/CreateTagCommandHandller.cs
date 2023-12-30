using Domain.Models.Tags;
using Infrastructure.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tags.Commands.Create
{
    public class CreateTagCommandHandller : IRequestHandler<CreateTagCommand>
    {
        private readonly ITagRepository _tagRepository;
        public CreateTagCommandHandller(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = Tag.Create(request.Tag.Name);
            _tagRepository.Create(tag);
        }
    }
}

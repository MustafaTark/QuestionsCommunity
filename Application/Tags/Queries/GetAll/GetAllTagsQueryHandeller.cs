using Domain.Dto.Tags;
using Infrastructure.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tags.Queries.GetAll
{
    public class GetAllTagsQueryHandeller : IRequestHandler<GetAllTagsQuery, IEnumerable<TagDto>>
    {
        private ITagRepository _tagRepository;
        public GetAllTagsQueryHandeller(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<IEnumerable<TagDto>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _tagRepository.FindAll(false).Select(t=> new TagDto { Id = t.Id,Name = t.Name}).ToListAsync();
            return tags;
        }
    }
}

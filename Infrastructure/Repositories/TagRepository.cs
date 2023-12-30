using Domain.Models.Tags;
using Infrastructure.Contracts;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TagRepository : BaseRepository<Tag> , ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }
    }
}

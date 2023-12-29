using Domain.Models.Communities;
using Infrastructure.Contracts;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CommunityRepository : BaseRepository<Community>, ICommunityRepository
    {
        public CommunityRepository(AppDbContext context) : base(context)
        {
        }
    }
}

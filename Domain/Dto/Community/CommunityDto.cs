using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Community
{
    public class CommunityDto
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
    }
}

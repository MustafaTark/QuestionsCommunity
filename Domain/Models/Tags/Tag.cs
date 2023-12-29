using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Shared;

namespace Domain.Models.Tags
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
    }
}

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
        public string Name { get; private set; }
        public static Tag? Create(string Name)
        {
            if (Name.Contains(" "))
                return null;
            var tag = new Tag
            {
                CreatedDate = DateTime.Now,
                Name = Name,
            };    
            return tag;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain.Models.Tags.Rules;
using Domain.SeedWork;
using Domain.Shared;
using Microsoft.Extensions.FileSystemGlobbing.Internal;

namespace Domain.Models.Tags
{
    public class Tag : BaseEntity
    {
        public string Name { get; private set; }
        public static Tag Create(string Name)
        {
            if (Regex.IsMatch(Name, @"[\W_]"))
                throw new  BusinessRuleValidationException(new TagShouldNotIncludeSpaceOrSpecialCharachter());
            var tag = new Tag
            {
                CreatedDate = DateTime.Now,
                Name = Name,
            };    
            return tag;
        }
    }
}

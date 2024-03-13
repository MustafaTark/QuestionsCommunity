using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Communities.Rules;
using Domain.Models.Questions.Rules;
using Domain.SeedWork;
using Domain.Shared;

namespace Domain.Models.Communities
{
    public class Community : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public static Community Create(string Name, string Description)
        {
            if(Name.Length > 50)
               throw new BusinessRuleValidationException(new NameMaximum50charachter());

            Community community = new Community
            {
                CreatedDate = DateTime.Now,
                Name = Name,
                Description = Description,
            };
            return community;
        }

    }
}

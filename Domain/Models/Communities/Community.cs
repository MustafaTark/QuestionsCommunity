using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Shared;

namespace Domain.Models.Communities
{
    public class Community : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public static Community Create(string Name, string Description)
        { 
            if(string.IsNullOrEmpty(Name)) 
                throw new ArgumentNullException("Name Is Required Field");
            if(Name.Length > 50)
            {
                throw new ArgumentNullException("Name Should be less than 50 charchter");
            }

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

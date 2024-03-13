using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Tags.Rules
{
    public class TagShouldNotIncludeSpaceOrSpecialCharachter : IBusinessRule
    {
        public string Message => "Tags Must Not Include Spaces or Special Charachter";
    }
}

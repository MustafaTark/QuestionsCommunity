using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Communities.Rules
{
    public class NameMaximum50charachter : IBusinessRule
    {
        public string Message =>"Community Name Should be not More than 50 chrachter";
    }
}

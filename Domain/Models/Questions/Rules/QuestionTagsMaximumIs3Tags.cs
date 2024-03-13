using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Questions.Rules
{
    public class QuestionTagsMaximumIs3Tags : IBusinessRule
    {
        public string Message => "Maximum Tags is 3 Tags";
    }
}

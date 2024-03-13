using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Questions.Rules
{
    public class QuestionTitleMaximumIs100Charachter : IBusinessRule
    {
        public string Message => "Title Should Be Not More than 100 charachter";
    }
}

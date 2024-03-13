using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Questions.Rules
{
    public class QuestionFilesMaximum5Files : IBusinessRule
    {
        public string Message => "Files Should be not more than 5 files";
    }
}

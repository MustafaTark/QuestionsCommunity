using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Shared;

namespace Domain.Models.Questions
{
    public class QuestionFile : BaseEntity
    {
        public string Url { get; private set; }
        public static QuestionFile Create (string url)
        {
            return new QuestionFile { Url = url };
        }
    }
}

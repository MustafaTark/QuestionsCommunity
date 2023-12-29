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
        public static QuestionFile? Create (string url)
        {
            if (url == null)
            {
                return null;
            }
            //if(!url.Contains('/'))
            //{
            //    return null;
            //}
            return new QuestionFile { Url = url };
        }
    }
}

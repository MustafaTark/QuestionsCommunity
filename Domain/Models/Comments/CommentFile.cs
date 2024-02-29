using Domain.Models.Questions;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Comments
{
    public class CommentFile : BaseEntity
    {
        public string Url { get; private set; }
        public static CommentFile? Create(string url)
        {
            if (url == null)
            {
                return null;
            }
            //if(!url.Contains('/'))
            //{
            //    return null;
            //}
            return new CommentFile { Url = url };
        }
    }
}

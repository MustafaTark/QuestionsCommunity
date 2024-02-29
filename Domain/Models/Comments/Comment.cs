using Domain.Models.Questions;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Comments
{
    public class Comment : BaseEntity
    {
        public string Content { get; private set; }
        public Guid QuestionId { get; private set; }
        public Question? Question { get; private set; }
        public ICollection<CommentFile>? Files { get; private set;}
        public static Comment? Create(string content , Guid questionId , ICollection<CommentFile> files) {
            if (string.IsNullOrEmpty(content)) { 
                return null;
            }
            var comment = new Comment {
                Content = content,
                QuestionId = questionId,
                Files = files,
                CreatedDate = DateTime.Now,
            };
            return comment;
        }


    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Comments
{
    public class CommentForCreateDto
    {
        public string Content { get; set; }
        public Guid QuestionId { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}

using Domain.Models.Questions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Questions
{
    public class QuestionForCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CommunityId { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<Guid>? QuestionTags { get; set; }
        public QuestionForCreateDto() { 
            Files = new List<IFormFile>();
            QuestionTags = new List<Guid>();
        }
    }
}

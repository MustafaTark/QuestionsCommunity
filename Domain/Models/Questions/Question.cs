using Domain.Models.Communities;
using Domain.Models.Tags;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Questions
{
    public class Question : BaseEntity
    {
        [MaxLength(100)]
        public string Title { get; private set; }
        public string Content { get; private set; }
        public Guid ComminutyId { get; private set; }   
        public Community? Community { get; private set; }
        public ICollection<QuestionFile>? Files { get; set; }
        
        public static Question? Create(string title , string content,Guid CommunityId ,ICollection<QuestionFile>? questionFiles)
        {
            Question question = new Question
            {
                Content = content,
                Title = title,
                Files = questionFiles,
                ComminutyId = CommunityId,
                CreatedDate = DateTime.Now,
            };
            if (question.Title.Length > 100)
            {
                return null;
            }
            if(question.Content == null || question.Title == null || question.ComminutyId == null) {
                return null;
            }
            return question;
        }

       
    }
}

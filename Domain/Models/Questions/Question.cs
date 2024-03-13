using Domain.Models.Communities;
using Domain.Models.Questions.Rules;
using Domain.Models.Tags;
using Domain.SeedWork;
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
        public ICollection<QuestionTag>? QuestionTags { get; set; }
        
        public static Question? Create(string title , string content,Guid CommunityId ,ICollection<QuestionFile>? questionFiles,ICollection<QuestionTag> questionTags)
        {
            Question question = new Question
            {
                Content = content,
                Title = title,
                Files = questionFiles != null? questionFiles : new List<QuestionFile>() ,
                QuestionTags = questionTags !=null ? questionTags : new List<QuestionTag>(),
                ComminutyId = CommunityId,
                CreatedDate = DateTime.Now,
            };
            if (question.Title.Length > 100)
            {
                throw new BusinessRuleValidationException(new QuestionTitleMaximumIs100Charachter());
            }
            if(question.QuestionTags?.Count >3)
            {
                throw new BusinessRuleValidationException(new QuestionTagsMaximumIs3Tags()); 
            }
            if (question.Files?.Count > 5)
            {
                throw new BusinessRuleValidationException(new QuestionFilesMaximum5Files());
            }
            return question;
        }

       
    }
}

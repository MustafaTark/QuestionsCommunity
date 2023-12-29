using Domain.Models.Tags;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Questions
{
    public class QuestionTag : BaseEntity
    {
        public Guid QuestionId { get; set; }
        public Question? Question { get; set; }
        public Guid TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace PollApi.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? SurveyId { get; set; }
        public string? Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Survey? Survey { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}

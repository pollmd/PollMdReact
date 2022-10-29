using System;
using System.Collections.Generic;

namespace PollApi.Models
{
    public partial class Survey
    {
        public Survey()
        {
            //Questions = new HashSet<Question>();
            //UsersSurveys = new HashSet<UsersSurvey>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Price { get; set; }
        public string? Type { get; set; }

        //public virtual ICollection<Question> Questions { get; set; }
        //public virtual ICollection<UsersSurvey> UsersSurveys { get; set; }
    }
}

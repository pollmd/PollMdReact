using System;
using System.Collections.Generic;

namespace PollApi.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            UserAnswers = new HashSet<UserAnswer>();
            UsersSurveys = new HashSet<UsersSurvey>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? FbId { get; set; }

        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
        public virtual ICollection<UsersSurvey> UsersSurveys { get; set; }
    }
}

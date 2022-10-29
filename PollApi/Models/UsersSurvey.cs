using System;
using System.Collections.Generic;

namespace PollApi.Models
{
    public partial class UsersSurvey
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? SurveyId { get; set; }
        public string? Status { get; set; }
        public DateTime? Date { get; set; }

        public virtual Survey? Survey { get; set; }
        public virtual UserProfile? User { get; set; }
    }
}

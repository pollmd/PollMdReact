using System;
using System.Collections.Generic;

namespace PollApi.Models
{
    public partial class UserAnswer
    {
        public long Id { get; set; }
        public int? UserId { get; set; }
        public int? AnswerId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Answer? Answer { get; set; }
        public virtual UserProfile? User { get; set; }
    }
}

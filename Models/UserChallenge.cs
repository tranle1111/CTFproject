using System;

namespace CTFproject.Models
{
    public class UserChallenge
    {
        public int UserID { get; set; }
        public int ChallengeID { get; set; }
        public bool IsSolved { get; set; }
        public DateTime SubmissionTime { get; set; }
    }
}

using System;
namespace Domain.Models
{
    public class Step : Entity
    {
        public Step()
        {
        }

        public Step NextStep { get; private set; }
        public int NextStepId { get; private set; }
        public int VideoId { get; private set; }
        public int QuestionId { get; private set; }
    }
}

using System;
namespace Domain.Models
{
    public class Answer : Entity
    {
        public Answer()
        {
        }

        public string Text { get; private set; }
        public DateTime InsertTime { get; private set; }
        public int Points { get; private set; }
        public DateTime DeleteTime { get; private set; }
        public string VoiceOverLink { get; private set; }
        // public int QuestionId { get; private set; }
    }
}

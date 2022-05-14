using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Question : Entity
    {
        private readonly List<Answer> _answers = new List<Answer>();

        public Question()
        {
        }

        public string Text { get; private set; }
        public DateTime InsertTime { get; private set; }
        public DateTime DeleteTime { get; private set; }
        public string VoiceOverLink { get; private set; }
        public IReadOnlyList<Answer> Answers => _answers;
    }
}

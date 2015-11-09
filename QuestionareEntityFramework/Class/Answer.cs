using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionareEntityFramework
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int QuestId { get; set; }
        public int Sorted { get; set; }
        public bool Correct { get; set; }
        public DateTime DateCreated { get; set; }
        public int User { get; set; }
        public DateTime Modify { get; set; }

        public Quest Quest { get; set; }
    }
}

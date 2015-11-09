using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionareEntityFramework
{
    public class Quest
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int User { get; set; }
        public DateTime modify {get; set;}

        public ICollection<Question> Questions { get; set; }
        public ICollection<Answer> Answers { get; set; }

        public Quest()
        {
            Questions = new List<Question>();
            Answers = new List<Answer>();
        }
    }
}

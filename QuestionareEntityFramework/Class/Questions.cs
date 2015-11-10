using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionareEntityFramework
{
    public class Question
    {
        public int Id { get; set; }
        public int? ChapterId { get; set; }
        public int? VariantId { get; set; }
        public int QuestId { get; set; }
        public int Sorted { get; set; }
        public DateTime DateCreated { get; set; }
        public int User { get; set; }
        public DateTime Modify { get; set; }

        public Chapter Chapter { get; set; }
        public Variant Variant { get; set; }
        public ICollection<Answer> Answers { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}

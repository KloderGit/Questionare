using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionareEntityFramework
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public int User { get; set; }
        public DateTime Modify { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionareEntityFramework;

namespace Data
{
    public class DataQuestionare
    {
        public List<QuestItem> select_quests2()
        {

            using (QustionareContex db = new QustionareContex())
            {
                db.Database.Log = Console.Write;
                var items = db.QuestItems.Include("Quest").Where(a => a.ChapterId == 1);
                return items.ToList<QuestItem>();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace QuestionareEntityFramework
{
    public class Questionare
    {
        protected List<Chapter> _Chapters;

        public Questionare() {
            LoadChapter();
        }

        //      -----------------  Чтение Тем включая варианты и вопросы  --------------------------------

        public List<Chapter> GetChapter() {
            return _Chapters;
        }

        public Chapter GetChapter(int _item)
        {
            return _Chapters.Where(c => c.Id == _item).FirstOrDefault();
        }

        public List<Chapter> GetChapter(Chapter _item)
        {
            return _Chapters.Where(c => c.Id == _item.Id).ToList<Chapter>();
        }

        protected void LoadChapter()
        {
            using (QustionareContex db = new QustionareContex())
            {
                _Chapters = db.Chapters.Include("Variants.QuestItems.Quest").ToList<Chapter>();
            }
        }

        public List<Quest> LoadQuestItemForExample()
        {
            using (QustionareContex db = new QustionareContex())
            {
                db.Database.Log = Console.Write;

                return db.Quests.ToList<Quest>();
            }
        }


        //      -----------------  Сохранение  --------------------------------

        public void SaveDB()
        {
            using (QustionareContex db = new QustionareContex())
            {
                db.Database.Log = Console.Write;
                db.SaveChanges();
            }
        }

//      -----------------  Сохранение  --------------------------------

        public void AddToChapter(Chapter item)
        {
            using (QustionareContex db = new QustionareContex())
            {
                db.Database.Log = Console.Write;

                db.Chapters.Attach(item);
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }
    }
}
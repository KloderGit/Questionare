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
        protected ObservableCollection<Chapter> _Chapters;
        protected ObservableCollection<Variant> _Variants;

        public Questionare() {
            UpdateChapter();
        }

        //      -----------------  Чтение Тем включая варианты и вопросы  --------------------------------

        public ObservableCollection<Chapter> GetChapter() {
            return _Chapters;
        }

        public ObservableCollection<Chapter> GetChapter(int ChapterID)
        {
            var lst = from ch in _Chapters where ch.Id == ChapterID select ch;
            return new ObservableCollection<Chapter>(lst);
        }

        public ObservableCollection<Chapter> GetChapter(Chapter Chapter)
        {
            var lst = from ch in _Chapters where ch.Id == Chapter.Id select ch;
            return new ObservableCollection<Chapter>(lst);
        }

        public void UpdateChapter() { LoadChapter(); }

        protected void LoadChapter()
        {
            using (QustionareContex db = new QustionareContex())
            {
                db.Database.Log = Console.Write;
                var items = db.Chapters.Include("Variants.QuestItems.Quest").ToList<Chapter>();
                _Chapters = new ObservableCollection<Chapter>(items);
            }
        }

//      -----------------  Чтение Вариантов включая вопросы  --------------------------------

        public ObservableCollection<Variant> GetVariants()
        {
            return _Variants;
        }

        public ObservableCollection<Variant> GetVariants(int VariantId)
        {
            var lst = from ch in _Variants where ch.Id == VariantId select ch;
            return new ObservableCollection<Variant>(lst);
        }

        public ObservableCollection<Variant> GetVariants(Variant var_input)
        {
            var lst = from vnt in _Variants where vnt.ChapterId == var_input.ChapterId && vnt.Id == var_input.Id select vnt;
            return new ObservableCollection<Variant>(lst);
        }

        public void UpdateVariant() { LoadVariant(); }

        protected void LoadVariant()
        {
            using (QustionareContex db = new QustionareContex())
            {
                db.Database.Log = Console.Write;
                var items = db.Variants.Include("QuestItems.Quest").ToList<Variant>();
                _Variants = new ObservableCollection<Variant>(items);
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
                db.Chapters.Add(item);
                db.SaveChanges();
            }
        }
    }
}

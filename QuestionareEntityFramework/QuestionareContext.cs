using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace QuestionareEntityFramework
{
    public class QuestionareContext: DbContext
    {
        public QuestionareContext() : base("QuestionareConnection")
        {
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Variant> Variants { get; set; }
    }
}

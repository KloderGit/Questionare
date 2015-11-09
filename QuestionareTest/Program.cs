using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionareEntityFramework;
//using System.Data.Entity;

namespace QuestionareTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (QuestionareContext db = new QuestionareContext())
            {
                // создаем два объекта User
                Quest user1 = new Quest { Text = "Tom", Description = "OOOOOOOOOOOOOOOO", User=1, modify=DateTime.Now };
                Quest user2 = new Quest { Text = "Sam", Description = "RRRRRRRRRRRRRRRRR", User = 1, modify = DateTime.Now };

                // добавляем их в бд
                db.Quests.Add(user1);
                db.Quests.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var users = db.Quests;
                Console.WriteLine("Список объектов:");
                foreach (Quest u in users)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.Id, u.Text, u.Description);
                }
            }
            Console.WriteLine();
            Console.Read();
        }
    }
}

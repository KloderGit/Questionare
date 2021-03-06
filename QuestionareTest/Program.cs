﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionareEntityFramework;
//using System.Data.Entity;
using System.Diagnostics;

namespace QuestionareTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (QustionareContex db = new QustionareContex())
            {
                var users = db.Quests.Include("Answers");

                Console.WriteLine("Список объектов:");

                Debug.WriteLine("OOOOOOOOOOOOOO");

                foreach (Quest u in users)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.Id, u.Text, u.Description);

                    foreach (Answer io in u.Answers) {
                        Console.WriteLine("{0} - {1}", io.Text, io.Description);
                    }

                }
            }

            Console.Read();
        }
    }
}

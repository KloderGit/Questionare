using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuestionareEntityFramework;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;

namespace TestUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DataTable dt = new DataTable();
        public List<Quest> Quests;

        public MainWindow()
        {
            InitializeComponent();

            //Quests = select_quests();

            //listBox.ItemsSource = select_quests();
            listBox1.ItemsSource = select_quests2();
            treeView.ItemsSource = select_quests4();
            //treeView1.ItemsSource = select_quests4();
            gridAcc.DataContext = select_quests4();
            //acc.ItemsSource = select_quests4();
        }

        public List<string> select_quests() {

            using (QustionareContex db = new QustionareContex()) {
                db.Database.Log = Console.Write;

                var items = from p in db.Quests select p.Text;


                return items.ToList<string>();
            }
        }

        public List<QuestItem> select_quests2()
        {

            using (QustionareContex db = new QustionareContex())
            {
                db.Database.Log = Console.Write;

               // var items = from p in db.QuestItems join Quest  select p;
                //var dt = db.Quests.AsQueryable();

                // foreach (Quest ii in items) {
                // var dt = query.CopyToDataTable<Vendedor>();
                //}

                //var items = db.Quests.Select(p => p.Text).ToList<String>();
                var items = db.QuestItems.Include("Quest").Where(a => a.ChapterId == 1);

                //dataGrid.ItemsSource = dt.ToArray();

                return items.ToList<QuestItem>();
            }
        }

        public List<string> select_quests3()
        {

            using (QustionareContex db = new QustionareContex())
            {
                db.Database.Log = Console.Write;

                //var items = from p in db.Quests select p;
                //var dt = db.Quests.AsQueryable();

                // foreach (Quest ii in items) {
                // var dt = query.CopyToDataTable<Vendedor>();
                //}

                var items = db.Chapters.Select(p => p.Text).ToList<String>();

                //dataGrid.ItemsSource = dt.ToArray();

                return items;
            }
        }

        public List<Chapter> select_quests4()
        {

            using (QustionareContex db = new QustionareContex())
            {
                db.Database.Log = Console.Write;

                var items = db.Chapters.Include("Variants.QuestItems.Quest").ToList<Chapter>();

                return items;
            }
        }

        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            listBox1.ItemsSource = select_questItems(e.NewValue);
        }

        private List<QuestItem> select_questItems(object selected)
        {
            using (QustionareContex db = new QustionareContex())
            {
                db.Database.Log = Console.Write;

                if (selected.GetType().BaseType == typeof(Chapter)) {
                    Chapter ch = (Chapter)selected;
                    Console.WriteLine(ch.ModifyAt);
                    var items = db.QuestItems.Include("Quest").Where(a => a.ChapterId == ch.Id);
                    return items.ToList<QuestItem>();
                }
                else if(selected.GetType().BaseType == typeof(Variant))
                {
                    Variant vr = (Variant)selected;
                    var items = db.QuestItems.Include("Quest").Where(a => a.ChapterId == vr.Chapter.Id & a.VariantId == vr.Id);
                    return items.ToList<QuestItem>();
                }
            }

            return null;
        }

    }
}

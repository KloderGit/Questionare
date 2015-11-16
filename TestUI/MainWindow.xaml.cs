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

            Quests = select_quests();

            //listBox1.ItemsSource = select_quests4();
            treeView.ItemsSource = select_quests4();
            //treeView1.ItemsSource = select_quests4();
        }

        public List<Quest> select_quests() {

            using (QustionareContex db = new QustionareContex()) {
                db.Database.Log = Console.Write;

                //var items = from p in db.Quests select p;
                //var dt = db.Quests.AsQueryable();

                // foreach (Quest ii in items) {
                // var dt = query.CopyToDataTable<Vendedor>();
                //}

                var items = db.Quests.Include("Answers").ToList<Quest>();

                //dataGrid.ItemsSource = dt.ToArray();

                return items;
            }
        }

        public List<string> select_quests2()
        {

            using (QustionareContex db = new QustionareContex())
            {
                db.Database.Log = Console.Write;

                //var items = from p in db.Quests select p;
                //var dt = db.Quests.AsQueryable();

                // foreach (Quest ii in items) {
                // var dt = query.CopyToDataTable<Vendedor>();
                //}

                var items = db.Quests.Select(p => p.Text).ToList<String>();

                //dataGrid.ItemsSource = dt.ToArray();

                return items;
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

                //var items = from p in db.Quests select p;
                //var dt = db.Quests.AsQueryable();

                // foreach (Quest ii in items) {
                // var dt = query.CopyToDataTable<Vendedor>();
                //}

                var items = db.Chapters.Include("Variants").ToList<Chapter>();

                //dataGrid.ItemsSource = dt.ToArray();

                return items;
            }
        }

        private void lstKld_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var i = (ListBox)sender;
            Console.WriteLine("sdfasdfasdf");
            var p = (Variant)i.DataContext;
            Console.WriteLine(p);
        }



    }
}

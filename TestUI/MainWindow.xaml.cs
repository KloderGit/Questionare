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

namespace TestUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DataTable dt = new DataTable();
        
        public MainWindow()
        {
            InitializeComponent();
            select_quests();

        }

        public void select_quests() {

            QustionareContex db = new QustionareContex();
            db.Database.Log = Console.Write;

            //var items = from p in db.Quests select p;
            var dt = db.Quests.AsQueryable();

            // foreach (Quest ii in items) {
            // var dt = query.CopyToDataTable<Vendedor>();
            //}

            dataGrid.ItemsSource = dt.ToArray();

        }
    }
}

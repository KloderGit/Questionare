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


namespace MainProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Questionare questionare = new Questionare();

            //listBox.ItemsSource = questionare.select_quests2();

            TabItem tabitem = new TabItem();
            tabitem.Header = "Тестирование";
            Frame tabFrame = new Frame();
            Questionare page1 = new Questionare();
            tabFrame.Content = page1;
            tabitem.Content = tabFrame;
            tabProjects.Items.Add(tabitem);
        }
    }
}

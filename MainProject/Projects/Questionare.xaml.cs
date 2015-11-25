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
using Quest = QuestionareEntityFramework;
using System.Collections.ObjectModel;

namespace MainProject
{
    /// <summary>
    /// Interaction logic for Questionare.xaml
    /// </summary>
    public partial class Questionare : Page
    {
        MainWindow _parent;
        Quest.Questionare _questionare;

        public Questionare(MainWindow parentItem)
        {
            InitializeComponent();

            _parent = parentItem;

            _questionare = new Quest.Questionare();
            panelLeftPanel.DataContext = _questionare.GetChapter();

            //_questionare.UpdateVariant();
            
        }

        private void lstVariants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox _listbox = (ListBox)sender;
            Quest.Variant _item = (Quest.Variant)_listbox.SelectedItem;
            Console.WriteLine(_item.Text);

            WrapperLIst.DataContext = _item;
 
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            _parent.ShowHideAdditionalPanel("right", true);
        }
    }
}

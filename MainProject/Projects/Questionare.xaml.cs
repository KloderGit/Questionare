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

        public Questionare(MainWindow parentItem, Quest.Questionare _dbObjectLink)
        {
            _dbObjectLink = new QuestionareEntityFramework.Questionare();

            InitializeComponent();

            _parent = parentItem;

            _questionare = _dbObjectLink;
            panelLeftPanel.DataContext = _questionare.GetChapter();          

        }

        private void lstVariants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox _listbox = (ListBox)sender;
            Quest.Variant _item = (Quest.Variant)_listbox.SelectedItem;
            Console.WriteLine(_item.Text);

            WrapperLIst.DataContext = _item;

            Console.WriteLine(acc.Items.Groups);

        }


        




        private void button_Click(object sender, RoutedEventArgs e)
        {
            ListBox _listbox = lslboxListQuestions;
            Quest.QuestItem _item = (Quest.QuestItem)_listbox.SelectedItem;

            Console.WriteLine(_item.Quest.Text);

            DialogWindowRight chapterExample = new DialogWindowRight();
            chapterExample.Owner = App.Current.MainWindow;
            chapterExample.AllowsTransparency = true;
            chapterExample.WindowStyle = WindowStyle.None;
            chapterExample.WrapperEntity.DataContext = _item.Quest;
            _parent.shadowFace = true;
            chapterExample.ShowDialog();
            _parent.shadowFace = false;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AddEntity EditEntity = new AddEntity();

            EditEntity.WrapperEntity.DataContext = _questionare.GetChapter(1);

            _parent.ShowHideAdditionalPanel("right", true, "Редактирование", EditEntity);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DialogWindowRight chapterExample = new DialogWindowRight();

            chapterExample.Owner = App.Current.MainWindow;

            chapterExample.WrapperEntity.DataContext = _questionare.GetChapter(1);

            var pp = chapterExample.WrapperEntity.DataContext;
            Console.WriteLine(pp);

            var tt = pp.GetType().BaseType;
            Console.WriteLine(tt);

            var mm = (QuestionareEntityFramework.Chapter)pp;
                       
            Console.WriteLine(mm);

            if ((bool)chapterExample.ShowDialog()) {
                _questionare.AddToChapter(mm);
                Console.WriteLine(mm.Text);
            }


        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Quest.Chapter i = _questionare.GetChapter(1);

            i.Text = "OOOOOOOOOOO";
            i.Description = "55555555555555555555555";
            i.DateCreated = DateTime.Today;
            i.ModifyAt = DateTime.Today;
            i.ModifyBy = 1;

            _questionare.AddToChapter(i);
        }

        private void lslboxListQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}

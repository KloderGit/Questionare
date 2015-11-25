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
using System.Windows.Media.Animation;


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

            //QuestionareEntityFramework.Questionare questionare = new QuestionareEntityFramework.Questionare();

            //listBox.ItemsSource = questionare.select_quests2();

            TabItem tabitem = new TabItem();
            tabitem.Header = "Тестирование";
            Frame tabFrame = new Frame();
            Questionare page1 = new Questionare(this);
            tabFrame.Content = page1;
            tabitem.Content = tabFrame;
            tabProjects.Items.Add(tabitem);
        }



        public void ShowHideAdditionalPanel(string position, bool visible, string _caption, AddEntity Item) {

            Storyboard sb; StackPanel pnl = null;

            if (position == "right") { pnl = pnlRightMenu; }

            if (visible)
            {
                sb = Resources["sbShowRightMenu"] as Storyboard;
                ShadowPanel.Visibility = Visibility.Visible;
                WrapperPanel.Children.Add(Item);
            }
            else {
                sb = Resources["sbHideRightMenu"] as Storyboard;
                ShadowPanel.Visibility = Visibility.Hidden;
                WrapperPanel.Children.Clear();
            }

            PanelName.Text = _caption;

            sb.Begin(pnl);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowHideAdditionalPanel("right", false, "", null);
        }
    }
}

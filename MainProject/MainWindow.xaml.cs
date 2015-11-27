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
using System.Windows.Media.Animation;


namespace MainProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _shadowFace;
        Quest.Questionare _linkToQuestionare;

        public MainWindow()
        {
            InitializeComponent();

            TabItem tabitem = new TabItem();
            tabitem.Header = "Тестирование";
            Frame tabFrame = new Frame();
            Questionare page1 = new Questionare(this, _linkToQuestionare);
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

        public bool shadowFace {
            get { return _shadowFace; }
            set {
                if (value)
                {
                    ShadowPanel.Visibility = Visibility.Visible;
                }
                else {
                    ShadowPanel.Visibility = Visibility.Hidden;
                }
            }
        }

    }
}

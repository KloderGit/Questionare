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
using Word = Microsoft.Office.Interop.Word;

namespace ToWord
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        public MainWindow()
        {
            InitializeComponent();
            listBox1.ItemsSource = select_quests2();


            Word.Application App = new Word.Application();

            Word.Document doc = App.Documents.Add(Visible: false);

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */



            foreach (var item in select_quests2()) {
                //Insert a paragraph at the end of the document.
                Word.Paragraph oPara2;
                object oRng = doc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara2 = doc.Content.Paragraphs.Add(ref oRng);
                oPara2.Range.Font.Bold = 1;
                oPara2.Format.SpaceBefore = 25;
                oPara2.Range.Text = item.Text;
                oPara2.Range.InsertParagraphAfter();

                foreach (var answ in item.Answers) {
                    Word.Paragraph oPara3;
                    oRng = doc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                    oPara3 = doc.Content.Paragraphs.Add(ref oRng);
                    oPara3.Range.Font.Bold = 0;
                    oPara3.Range.Text = "-----------------------------------------------------------------------------------------";
                    oPara3.Range.Text += answ.Text;
                    oPara3.Range.InsertParagraphAfter();
                }

                Word.Range r = doc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                Word.Table t = doc.Tables.Add(r, 2, 4);
                t.Borders.Enable = 1;

                foreach (Word.Row row in t.Rows) {
                    foreach (Word.Cell cell in row.Cells) {
                        if (cell.RowIndex == 1)
                        {
                            cell.Range.Bold = 1;
                            if (cell.ColumnIndex == 1) { cell.Range.Text = "Теория и мет.";  }
                            if (cell.ColumnIndex == 2) { cell.Range.Text = "Физиология"; }
                            if (cell.ColumnIndex == 3) { cell.Range.Text = "Анатомия"; }
                            if (cell.ColumnIndex == 4) { cell.Range.Text = "Для ИГП"; }
                        }
                        else {
                            cell.Range.Text = " ";
                        }
                    }
                }

                Word.Paragraph oPara5;
                oRng = doc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara5 = doc.Content.Paragraphs.Add(ref oRng);
                oPara5.Range.Font.Bold = 0;
                oPara5.Range.Text = "---";
                oPara5.Range.InsertParagraphAfter();
            }



            doc.Save();

            try
            {
                doc.Close();
                App.Quit();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }


        }

        public List<Quest> select_quests2()
        {

            using (QustionareContex db = new QustionareContex())
            {
                db.Database.Log = Console.Write;
                var items = db.Quests.Include("Answers");

                var limitedProductQuery = items.Take(100);
                return limitedProductQuery.ToList<Quest>();
            }
        }
    }
}

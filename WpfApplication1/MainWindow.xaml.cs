using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            createForm();
            
        }
        int[] wyniki = new int[100];
        public IList<StackPanel> panele = new List<StackPanel>();
        public IList<TextBox> formularzpytania;
        public IList<TextBox> odpowiedzi1;
        public IList<TextBox> odpowiedzi2;
        public IList<TextBox> odpowiedzi3;
        public IList<RadioButton> radio1;
        public IList<RadioButton> radio2;
        public IList<RadioButton> radio3;
        public List<Int32> odpowiedzi;
        
        private int liczba;
        public void createForm()
        {
            

            StreamReader plik = File.OpenText(@"F:\output.txt");
            string tekst = plik.ReadLine();
            int liczbapytan = Int32.Parse(tekst);
            formularzpytania = new List<TextBox>(liczbapytan);
            liczba = liczbapytan;
            
            odpowiedzi1 = new List<TextBox>(liczbapytan);
            odpowiedzi2 = new List<TextBox>(liczbapytan);
            odpowiedzi3 = new List<TextBox>(liczbapytan);

            radio1 = new List<RadioButton>(liczbapytan);
            radio2 = new List<RadioButton>(liczbapytan);
            radio3 = new List<RadioButton>(liczbapytan);
            int[] tablica = new int[liczbapytan];
            

            for (int i = 0; i < liczbapytan; i++)
            {
                StackPanel panel = new StackPanel();
                Label pytanie = new Label();
                RadioButton radiop = new RadioButton();
                RadioButton radiod = new RadioButton();
                RadioButton radiot = new RadioButton();
                Label odp1 = new Label();
                Label odp2 = new Label();
                Label odp3 = new Label();

                pytanie.Content = plik.ReadLine();
                odp1.Content = plik.ReadLine();
                odp2.Content = plik.ReadLine();
                odp3.Content = plik.ReadLine();

                radiop.Content = odp1;
                radiod.Content = odp2;
                radiot.Content = odp3;

                StackPanelzpytaniami.Children.Add(pytanie);

                panel.Children.Add(radiop);
                panel.Children.Add(radiod);
                panel.Children.Add(radiot);
                StackPanelzpytaniami.Children.Add(panel);

                radio1.Add(radiop);
                radio2.Add(radiod);
                radio3.Add(radiot);

               
            }

            for (int y = 0; y < liczbapytan; y++)
            {
                string tekstzpliku = plik.ReadLine();
                int liczbazpliku = Int32.Parse(tekstzpliku);
                int dobraodp=0;
               // wynikilabel.Content += liczbazpliku.ToString()+" ";
                dobraodp = liczbazpliku % 13;
                tablica[y] = dobraodp;
                wyniki[y] = dobraodp;
                // odpowiedzi[y] = dobraodp;
            }
        }

        private void ZakonczClick(object sender, RoutedEventArgs e)
        {
            int wynik = 0;
            for (int i = 0; i<liczba;i++)
            {
                
                if (wyniki[i] == 1)
                {
                    if (radio1[i].IsChecked == true)
                    {
                        wynik++;
                    }
                }

                if (wyniki[i] == 2)
                {
                    if (radio2[i].IsChecked == true)
                    {
                        wynik++;
                    }
                }

                if (wyniki[i] == 3)
                {
                    if (radio3[i].IsChecked == true)
                    {
                        wynik++;
                    }
                }
            }

            wynikilabel.Content += wynik.ToString();

        }
    }
}

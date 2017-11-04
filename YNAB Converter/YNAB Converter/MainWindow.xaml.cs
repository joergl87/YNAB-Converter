using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YNAB_Converter
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cb_Bank.Items.Add("Postbank");
            cb_Bank.Items.Add("Commerzbank");
        }

        private void btn_Konvertieren_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "csv files (*.ccsv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != null)
                {
                    if (cb_Bank.SelectedItem.ToString() == "Commerzbank")
                    {
                        Konverterklassen.Commerzbank Test = new Konverterklassen.Commerzbank(openFileDialog1.FileName, saveFileDialog1.FileName);
                    }
                    else if (cb_Bank.SelectedItem.ToString() == "Postbank")
                    {
                        Konverterklassen.Postbank Test = new Konverterklassen.Postbank(openFileDialog1.FileName, saveFileDialog1.FileName);
                    }
                }
            }
        }
    }
}

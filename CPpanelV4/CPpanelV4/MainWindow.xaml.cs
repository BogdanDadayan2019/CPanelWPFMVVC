using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Media;

namespace CPpanelV4
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        { 

            InitializeComponent();
            this.DataContext = new ApplicationViewModel();
            if (coinsList.SelectedItem == null) return;

        }

     
        
        Coin coin = new Coin();
        SummaryPrice summaryPrice = new SummaryPrice();
        

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // allDifff.Foreground = Brushes.Red;
            float tmp = float.Parse(summaryPrice.AllDiff, CultureInfo.InvariantCulture.NumberFormat);
            

            if (tmp < 0)
            {
                allDiffColor.Foreground = Brushes.Red;
            }
            else if (tmp > 0)
            {
                allDiffColor.Foreground = Brushes.Green;
            }


        }
    }
}
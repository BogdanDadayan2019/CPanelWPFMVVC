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
    }
}
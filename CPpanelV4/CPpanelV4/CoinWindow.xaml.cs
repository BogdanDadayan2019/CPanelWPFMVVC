using System.Windows;

namespace CPpanelV4
{
    public partial class CoinWindow : Window
    {
        public Coin Coin { get; private set; }

        public CoinWindow(Coin c)
        {
            InitializeComponent();
            Coin = c;
            this.DataContext = Coin;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace CPpanelV4
{
    public class SummaryPrice : INotifyPropertyChanged
    {
        

        private string sumPrice = "";
        private string allDiff = "1";
        private Brush bdColor;
        public string SumPrice
        {
            get { return sumPrice; }
            set
            {
                sumPrice = value;
                OnPropertyChanged("SumPrice");
            }
        }

        public string AllDiff
        {
            get { return allDiff; }
            set
            {
               
                allDiff = value;
                
                OnPropertyChanged("AllDiff");
            }
        }

        public Brush BdColor
        {
            get { return bdColor; }
            set
            {
                bdColor = value;
                OnPropertyChanged("BdColor");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

       

    }
}

/*

       IEnumerable<Coin> coins;

       private string sumPrice;

       public string SumPrice
       {
           get { return sumPrice; }
           set
           {
               sumPrice = value;
               OnPropertyChanged("SumPrice");
           }
       }


       public void allPrice()
       {
           foreach (object o in coins)
           {
               Coin coin = new Coin();
               sumPrice += coin.Price;
           }
       }

       public SummaryPrices() { sumPrice = "Неизвестно"; }




       public event PropertyChangedEventHandler PropertyChanged;
       public void OnPropertyChanged([CallerMemberName]string prop = "")
       {
           if (PropertyChanged != null)
               PropertyChanged(this, new PropertyChangedEventArgs(prop));
       }

       public IEnumerable<Coin> Coins
       {
           get { return coins; }
           set
           {
               coins = value;
               OnPropertyChanged("Coins");

           }
       }

       internal object AllPrice()
       {
           Coin coin = new Coin();
           foreach (object o in coins)
           {

               sumPrice += coin.Price;
           }
           return sumPrice;
       }
   }

   */

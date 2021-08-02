using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CPpanelV4
{
    public class Coin : INotifyPropertyChanged
    {
        private string title;
        private int count;
        private int price;
        private string factPrice;
        private string diffPrice;

        public int Id { get; set; }


        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public string FactPrice
        {
            get { return factPrice; }
            set
            {

                factPrice = value;
                OnPropertyChanged("FactPrice");
            }
        }

        public string DiffPrice
        {
            get { return diffPrice; }
            set
            {

                diffPrice = value;
                OnPropertyChanged("DiffPrice");
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
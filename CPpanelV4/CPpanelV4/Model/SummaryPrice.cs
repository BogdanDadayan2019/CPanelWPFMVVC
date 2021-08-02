using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace CPpanelV4
{
    public class SummaryPrice : INotifyPropertyChanged
    {
        
        private string sumPrice = "";
        private string allDiff = "";
        private Brush bdColor;
        private Brush bdColorTwo;

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

        public Brush BdColorTwo
        {
            get { return bdColorTwo; }
            set
            {
                bdColorTwo = value;
                OnPropertyChanged("BdColorTwo");
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

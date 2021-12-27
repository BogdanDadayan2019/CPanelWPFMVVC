using CPpanelV4.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Media;

namespace CPpanelV4
{

    public class ApplicationViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        public Data data { get; set; }

        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;
        RelayCommand viewCommand;
        RelayCommand fullPriceCommand;
        
        IEnumerable<Coin> coins;
        
        private SummaryPrice summaryPrice;
        private SummaryPrice allDiff;
       
        private Coin factPrice;
        System.Timers.Timer bgTimer;


        public ApplicationViewModel()
        {
            db = new ApplicationContext();
            db.Coins.Load();
            Coins = db.Coins.Local.ToBindingList();
            summaryPrice = new SummaryPrice();
            allDiff = new SummaryPrice();
            factPrice = new Coin();

            bgTimer = new System.Timers.Timer();
            bgTimer.Elapsed += BgTimer_Elapsed;
            bgTimer.Interval = 1000;
            bgTimer.Start();
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

        public SummaryPrice SummaryPrice
        {
            get { return summaryPrice; }
            set
            {
                summaryPrice = value;
                OnPropertyChanged("SummaryPrice");
            }
        }

        public SummaryPrice AllDiff
        {
            get { return allDiff; }
            set
            {
                allDiff = value;
                OnPropertyChanged("AllDiff");
            }
        }

        private void BgTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            BdJson();
            CalculateSummaryTotal();
        }

        public RelayCommand FullPriceCommand
        {
            get
            {
                return fullPriceCommand ??
                    (fullPriceCommand = new RelayCommand((o) =>
                    {
                        BdJson();
                    }));
            }
        } // УДАЛИТЬ

        // обновление полного баланса
        public RelayCommand ViewCommand
        {
            get
            {
                return viewCommand ??
                    (viewCommand = new RelayCommand((o) =>
                    {

                      //  CalculateSummaryTotal();


                    }));
            }
        } // УДАЛИТЬ

        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                (addCommand = new RelayCommand((o) =>
                {

                    CoinWindow coinWindow = new CoinWindow(new Coin());
                    if (coinWindow.ShowDialog() == true)
                    {
                        Coin coin = coinWindow.Coin;
                        db.Coins.Add(coin);
                        db.SaveChanges();
                    }
                }));
            }
        }

        // команда редактирования
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                (editCommand = new RelayCommand((selectedItem) =>
                {
                    if (selectedItem == null) return;
                    // получаем выделенный объект
                    Coin coin = selectedItem as Coin;

                    Coin vm = new Coin()
                    {
                        Id = coin.Id,
                        Count = coin.Count,
                        Price = coin.Price,
                        Title = coin.Title
                    };
                    CoinWindow coinWindow = new CoinWindow(vm);

                    if (coinWindow.ShowDialog() == true)
                    {
                        // получаем измененный объект
                        coin = db.Coins.Find(coinWindow.Coin.Id);
                        if (coin != null)
                        {
                            coin.Count = coinWindow.Coin.Count;
                            coin.Title = coinWindow.Coin.Title;
                            coin.Price = coinWindow.Coin.Price;


                            db.Entry(coin).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }));
            }
        }

        // команда удаления
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                (deleteCommand = new RelayCommand((selectedItem) =>
                {
                    if (selectedItem == null) return;
                    // получаем выделенный объект
                    Coin coin = selectedItem as Coin;
                    db.Coins.Remove(coin);
                    db.SaveChanges();
                }));
            }
        }

        public void BdJson()
        {
            try
            {
                string url = "http://api.coincap.io/v2/assets";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string response;
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
                DeCoin deCoin = JsonConvert.DeserializeObject<DeCoin>(response);

                foreach (var i1 in coins)
                {
                    foreach (var i2 in deCoin.data)
                    {
                        if (i2.name == i1.Title)
                        {
                            float tmp = float.Parse(i2.priceUsd, CultureInfo.InvariantCulture.NumberFormat);
                            i1.FactPrice = (tmp * i1.Count).ToString();

                            float tmp2 = float.Parse(i1.FactPrice.ToString());
                            i1.DiffPrice = ((((tmp2 - i1.Price) / i1.Price) * 100)).ToString();

                            if (tmp2 < tmp)
                            {
                                summaryPrice.BdColorTwo = Brushes.Red;
                            }
                            else
                            {
                                summaryPrice.BdColorTwo = Brushes.Green;
                            }

                            break;
                        }
                    }
                }
            }
            catch
            {

            }
          

        }

        private void CalculateSummaryTotal()
        {
            float total = 0;
            float totalDiff = 0;

            foreach (Coin c in coins)
            {

                float tmp2 = float.Parse(c.DiffPrice);
                totalDiff += tmp2;

                float tmp = float.Parse(c.FactPrice);
                total += tmp;

            };

            summaryPrice.SumPrice = total.ToString();
            summaryPrice.AllDiff = totalDiff.ToString();

            if (totalDiff < 0)
            {
               summaryPrice.BdColor = Brushes.Red;               
            }
            else
            {
                summaryPrice.BdColor = Brushes.Green;          
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
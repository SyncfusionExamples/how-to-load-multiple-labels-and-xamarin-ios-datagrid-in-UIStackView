using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MultipleLabelAndGrid
{
    public class OrderInfoRepository
        {
            ObservableCollection<OrdersInfo> orderDetails;
            public OrderInfoRepository()
            {
                orderDetails = new ObservableCollection<OrdersInfo>();
            }

            #region private variables

            private Random random = new Random();

            #endregion

            #region GetOrderDetails

            public ObservableCollection<OrdersInfo> GetOrderDetails(int count)
            {



                for (int i = 1; i <= count; i++)
                {

                    var ord = new OrdersInfo()
                    {
                        OrderID = i.ToString(),
                        CustomerID = CustomerID[random.Next(15)],
                        EmployeeID = random.Next(1700, 1800).ToString(),
                        FirstName = FirstNames[random.Next(15)],
                        LastName = LastNames[random.Next(15)],
                        Gender = Genders[random.Next(5)],
                        IsClosed = ((i % random.Next(1, 10) > 5) ? true : false).ToString(),
                    };
                    orderDetails.Add(ord);
                }
                return orderDetails;
            }

            internal OrdersInfo RefreshItemsource(int i)
            {
                var order = new OrdersInfo()
                {
                    OrderID = i.ToString(),
                    CustomerID = CustomerID[random.Next(15)],
                    EmployeeID = random.Next(1700, 1800).ToString(),
                    FirstName = FirstNames[random.Next(15)],
                    LastName = LastNames[random.Next(15)],
                    Gender = Genders[random.Next(5)],
                    IsClosed = ((i % random.Next(1, 10) > 5) ? true : false).ToString(),
                };
                return order;
            }

            internal ObservableCollection<OrdersInfo> GenerateOrders(int count)
            {
                int id = orderDetails.Count;
                for (int i = id; i <= id + count; i++)
                {
                    var ord = new OrdersInfo()
                    {
                        OrderID = i.ToString(),
                        CustomerID = CustomerID[random.Next(15)],
                        EmployeeID = random.Next(1700, 1800).ToString(),
                        FirstName = FirstNames[random.Next(15)],
                        LastName = LastNames[random.Next(15)],
                        Gender = Genders[random.Next(5)],
                        IsClosed = ((i % random.Next(1, 10) > 5) ? true : false).ToString(),
                    };
                    orderDetails.Insert(0, ord);
                }
                return orderDetails;
            }

            #endregion

            #region MainGrid DataSource

            string[] Genders = new string[] {
            "Male",
            "Female",
            "Female",
            "Female",
            "Male",
            "Male",
            "Male",
            "Male",
            "Male",
            "Male",
            "Male",
            "Male",
            "Female",
            "Female",
            "Female",
            "Male",
            "Male",
            "Male",
            "Female",
            "Female",
            "Female",
            "Male",
            "Male",
            "Male",
            "Male"
        };

            string[] FirstNames = new string[] {
            "Kyle",
            "Gina",
            "Irene",
            "Katie",
            "Michael",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Brenda",
            "Danielle",
            "Fiona",
            "Howard",
            "Jack",
            "Larry",
            "Holly",
            "Jennifer",
            "Liz",
            "Pete",
            "Steve",
            "Vince",
            "Zeke"
        };

            string[] LastNames = new string[] {
            "Adams",
            "Crowley",
            "Ellis",
            "Gable",
            "Irvine",
            "Keefe",
            "Mendoza",
            "Owens",
            "Rooney",
            "Waddell",
            "Thomas",
            "Betts",
            "Doran",
            "Fitzgerald",
            "Holmes",
            "Jefferson",
            "Landry",
            "Newberry",
            "Perez",
            "Spencer",
            "Vargas",
            "Grimes",
            "Edwards",
            "Stark",
            "Cruise",
            "Fitz",
            "Chief",
            "Blanc",
            "Perry",
            "Stone",
            "Williams",
            "Lane",
            "Jobs"
        };

            string[] CustomerID = new string[] {
            "Alfki",
            "Frans",
            "Merep",
            "Folko",
            "Simob",
            "Warth",
            "Vaffe",
            "Furib",
            "Seves",
            "Linod",
            "Riscu",
            "Picco",
            "Blonp",
            "Welli",
            "Folig"
        };

            #endregion
        }
        public class ViewModel : NotificationObject
        {
            OrderInfoRepository order;
            public ViewModel()
            {
                order = new OrderInfoRepository();
                SetRowstoGenerate(100);
            }

            public void LoadMoreItems()
            {
                ordersInfo = order.GenerateOrders(2);
            }

            #region ItemsSource

            private ObservableCollection<OrdersInfo> ordersInfo;

            public ObservableCollection<OrdersInfo> OrdersInfo
            {
                get { return ordersInfo; }
                set
                {
                    this.ordersInfo = value;
                    RaisePropertyChanged("OrdersInfo");
                }
            }

            #endregion

            #region ItemSource Generator

            public void SetRowstoGenerate(int count)
            {

                ordersInfo = order.GetOrderDetails(50);
            }

            #endregion
        }

        public class NotificationObject : INotifyPropertyChanged
        {
            public void RaisePropertyChanged(string propName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }
    
}

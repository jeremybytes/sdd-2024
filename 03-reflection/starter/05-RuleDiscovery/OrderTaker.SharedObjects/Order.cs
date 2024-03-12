using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace OrderTaker.SharedObjects
{
    public class Order : INotifyPropertyChanged
    {
        #region Fields

        private Person customer;
        private ObservableCollection<OrderItem> orderItems;
        private int orderDiscount;

        #endregion

        public Person Customer
        {
            get { return customer; }
            set
            {
                if (customer == value)
                    return;
                customer = value;
                RaisePropertyChanged("Customer");
            }
        }

        public ObservableCollection<OrderItem> OrderItems
        {
            get { return orderItems; }
            set
            {
                if (orderItems == value)
                    return;
                orderItems = value;
                RaisePropertyChanged("OrderItems");
            }
        }

        public int OrderDiscount
        {
            get { return orderDiscount; }
            set
            {
                if (orderDiscount == value)
                    return;
                orderDiscount = value;
                RaisePropertyChanged("OrderDiscount");
                RaisePropertyChanged("TotalPrice");
            }
        }

        public decimal TotalPrice
        {
            get
            {
                var total = orderItems.Sum(p => p.ItemTotal);
                if (OrderDiscount >= 0)
                    return total - (total * OrderDiscount / 100);
                return total;
            }
        }

        public Order()
        {
            OrderItems = new ObservableCollection<OrderItem>();
            OrderItems.CollectionChanged += OrderItems_CollectionChanged;
        }

        void OrderItems_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("TotalPrice");
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

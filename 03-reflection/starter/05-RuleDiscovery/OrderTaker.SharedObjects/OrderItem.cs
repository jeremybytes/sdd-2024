using System.ComponentModel;

namespace OrderTaker.SharedObjects
{
    public class OrderItem : INotifyPropertyChanged
    {
        private Product productItem;
        private int quantity;

        public Product ProductItem
        {
            get { return productItem; }
            set
            {
                if (productItem == value)
                    return;
                productItem = value;
                RaisePropertyChanged("ProductItem");
                RaisePropertyChanged("ItemTotal");
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity == value)
                    return;
                quantity = value;
                RaisePropertyChanged("Quantity");
                RaisePropertyChanged("ItemTotal");
            }
        }
        public decimal ItemTotal
        {
            get
            {
                return ProductItem.Price * Quantity;
            }
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

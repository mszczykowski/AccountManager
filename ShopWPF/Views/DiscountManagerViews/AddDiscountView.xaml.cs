using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ShopWPF.Enums;

namespace ShopWPF.Views.DiscountManagerViews
{
    /// <summary>
    /// Interaction logic for AddDiscountView.xaml
    /// </summary>
    public partial class AddDiscountView : UserControl
    {
        public AddDiscountView()
        {
            InitializeComponent();

            
        }

        private void DiscountTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DiscountTypes selected;
            
            var comboBoxItem = (sender as ComboBox).SelectedItem;

            if (comboBoxItem != null)
            {
                selected = (DiscountTypes)comboBoxItem;
            }
            else selected = DiscountTypes.Total_price_discount;

            TotalPricePanel.Visibility = Visibility.Hidden;
            CategoryPanel.Visibility = Visibility.Hidden;
            ProductPanel.Visibility = Visibility.Hidden;

            switch (selected)
            {
                case (DiscountTypes.Total_price_discount):
                    TotalPricePanel.Visibility = Visibility.Visible;
                    break;
                case (DiscountTypes.Category_discount):
                    CategoryPanel.Visibility = Visibility.Visible;
                    break;
                case (DiscountTypes.Product_discount):
                    ProductPanel.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}

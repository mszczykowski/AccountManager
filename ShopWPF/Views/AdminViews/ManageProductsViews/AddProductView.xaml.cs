using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ShopWPF.Views.ManageProductsViews
{
    /// <summary>
    /// Interaction logic for AddProductView.xaml
    /// </summary>
    public partial class AddProductView : UserControl
    {
        public AddProductView()
        {
            InitializeComponent();

            DataObject.AddPastingHandler(quantityTextBox, PasteHandler);
        }

        private bool IsNumeric(string s)
        {
            Regex r = new Regex("[^0-9]");

            return !r.IsMatch(s);
        }

        private bool HasTwoDecimalPoints(string s)
        {
            //todo
            
            //Regex r = new Regex("[^0-9.]+");

            //return !r.IsMatch(s);

            return true;
        }

        private void QuantityTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Prohibit non-numeric
            if (!IsNumeric(e.Text))
                e.Handled = true;
        }

        private void PriceTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Prohibit non-numeric
            if (!HasTwoDecimalPoints(e.Text))
                e.Handled = true;
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Prohibit space
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void PasteHandler(object sender, DataObjectPastingEventArgs e)
        {
            TextBox tb = sender as TextBox;
            bool textOK = false;

            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                // Allow pasting only alphabetic
                string pasteText = e.DataObject.GetData(typeof(string)) as string;
                if (IsNumeric(pasteText))
                    textOK = true;
            }

            if (!textOK)
                e.CancelCommand();
        }
    }
}

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

namespace AquaWPF2_4_prak_
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private AquaEntities  Orders = new AquaEntities();
        public Page2()
        {
            InitializeComponent();
            Aqua2.ItemsSource = Orders.Orders.ToList();
            spisok.ItemsSource = Orders.Orders.ToList();
            spisok.DisplayMemberPath = "Quantity";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Aqua2.ItemsSource = Orders.Orders.ToList().Where(item => item.Quantity.Contains(SearchTxt.Text));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Aqua2.ItemsSource = Orders.Orders.ToList();
        }

        private void spisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (spisok.SelectedItem != null)
            {
                var selected = spisok.SelectedItem as Orders;
                Aqua2.ItemsSource = Orders.Orders.ToList().Where(item => item.Quantity == selected.Quantity);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private AquaEntities Customers = new AquaEntities();
        public Page1()
        {
            InitializeComponent();
            Aqua1.ItemsSource = Customers.Customers.ToList();
            spisok.ItemsSource = Customers.Customers.ToList();
            spisok.DisplayMemberPath = "Name1";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Aqua1.ItemsSource = Customers.Customers.ToList().Where(item => item.Name1.Contains(SearchTxt.Text));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Aqua1.ItemsSource = Customers.Customers.ToList();
        }

        private void spisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (spisok.SelectedItem != null)
            {
                var selected = spisok.SelectedItem as Customers;
                Aqua1.ItemsSource = Customers.Customers.ToList().Where(item => item.Name1 == selected.Name1);
            }
        }
    }
}

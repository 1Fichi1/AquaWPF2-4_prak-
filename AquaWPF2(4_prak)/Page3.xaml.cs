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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        private AquaEntities Products = new AquaEntities();
        public Page3()
        {
            InitializeComponent();
            Aqua3.ItemsSource = Products.Products.ToList();
            spisok.ItemsSource = Products.Products.ToList();
            spisok.DisplayMemberPath = "Name1";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Aqua3.ItemsSource = Products.Products.ToList().Where(item => item.Name1.Contains(SearchTxt.Text));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Aqua3.ItemsSource = Products.Products.ToList();
        }

        private void spisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (spisok.SelectedItem != null)
            {
                var selected = spisok.SelectedItem as Products;
                Aqua3.ItemsSource = Products.Products.ToList().Where(item => item.Name1 == selected.Name1);
            }
        }
    }
}

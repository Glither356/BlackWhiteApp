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

namespace BlackWhiteApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnToProfile_Click(object sender, RoutedEventArgs e)
        {
            NextPage.Content = new Profile();
        }

        private void btnToCheck_Click(object sender, RoutedEventArgs e)
        {
            NextPage.Content = new Check();
        }

        private void btnToMarket_Click(object sender, RoutedEventArgs e)
        {
            NextPage.Content = new market();
        }
    }
}

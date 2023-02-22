using BlackWhiteApp.Cods;
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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private static string _name;

        public static string name
        {
            get
            {
                return _name;
            }
        }
        
        public RegisterPage()
        {
            InitializeComponent();

            connect();
        }

        private async void connect()
        {
            await Server.ConnectAsync();
        }

        private async void regBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _name = EnterName.Text;
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                return;
            }

            bool reg = await Server.getRegiser(_name);

            while (!reg) continue;

            NextPage.Content = new Profile();
        }
    }
}

using BlackWhiteApp.Cods;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static string name;
        
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void regBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                name = EnterName.Text;
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                return;
            }

            bool reg = await Server.getRegiser(name);

            if (!reg)
                return;

            File.WriteAllText("name.txt", name);

            NextPage.Content = new Profile();
        }
    }
}

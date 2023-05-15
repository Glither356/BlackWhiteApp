using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BlackWhiteApp.Cods;

namespace BlackWhiteApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Check.xaml
    /// </summary>
    public partial class Check : Page
    {

        public Check()
        {
            InitializeComponent();

            rebootCountOfAP();

            ErrorAnim();
        }

        public async Task rebootCountOfAP()
        {
            int dore = await Server.getDiamondOre(Server.Nick);

            countOfAP.Text = dore.ToString();

            await Task.Delay(10000);

            await rebootCountOfAP();
        }

        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            NextPage.Content = new Menu();
        }

        private void Button_Send_AP_Click(object sender, RoutedEventArgs e)
        {
            SendAPtoPlayer.Visibility = SendAPtoPlayer.Visibility ==
                Visibility.Hidden ?
                Visibility.Visible :
                Visibility.Hidden;
        }

        private async void Button_Accept_Send_AP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string _name = name.Text;
                int _countOfAp = int.Parse(numOFAP.Text);

                bool yes = await Server.sendOfAP(File.ReadAllText("name.txt"),
                    _name, _countOfAp);

                if (!yes)
                {
                    ErrorAnim();
                    return;
                } else if (yes)
                {
                    return;
                }

                SendAPtoPlayer.Visibility = Visibility.Hidden;

                return;
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                ErrorAnim();
            }
        }


        private void ErrorAnim()
        {
            Error.Visibility = Error.Visibility ==
                    Visibility.Hidden ?
                    Visibility.Visible :
                    Visibility.Hidden;

            /*var AnimOfERROR = new DoubleAnimation();
            Error.Visibility = Visibility.Visible;

            AnimOfERROR.From = 0;
            AnimOfERROR.To = 100;

            AnimOfERROR.Duration = TimeSpan.FromSeconds(1);
            Error.BeginAnimation(Grid.WidthProperty, AnimOfERROR);*/
        }

        private void CloseError_Click(object sender, RoutedEventArgs e)
        {
            Error.Visibility = Error.Visibility ==
                    Visibility.Hidden ?
                    Visibility.Visible :
                    Visibility.Hidden;
        }
    }
}

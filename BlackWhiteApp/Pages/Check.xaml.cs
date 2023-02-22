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
using BlackWhiteApp.Cods;

namespace BlackWhiteApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Check.xaml
    /// </summary>
    public partial class Check : Page
    {
        int diomandOreOfCountFromServer;

        public Check()
        {
            InitializeComponent();

            rebootCountOfAP();
        }

        public async void rebootCountOfAP()
        {
        reboting:

            int dore = await Server.getDiamondOre(RegisterPage.name);

            await Task.Delay(500);

            diomandOreOfCountFromServer = dore;

            countOfAP.Text = diomandOreOfCountFromServer.ToString();

            await Task.Delay(10000);
            goto reboting;
        }

        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            NextPage.Content = new Menu();
        }
    }
}

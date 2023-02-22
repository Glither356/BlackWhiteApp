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
using System.Windows.Media.Animation;

namespace BlackWhiteApp.Pages
{
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
            NameInProfile.Text = Server.Nick;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            NextPage.Content = new Menu();
        }

        private void ApplyForChangeTitleUI_Click(object sender, RoutedEventArgs e)
        {
            string title;

            try
            {
                title = TitleForUserText.Text;

            } catch (Exception)
            {
                title = "None";
                return;
            }

            ChangeTitleUI.Visibility = Visibility.Hidden;

            if (title == "")
                title = "Empty";

            TitleForProfile.Text = title;
        }

        private void TitleForProfile_Click(object sender, RoutedEventArgs e)
        {
            var dbAnim = new DoubleAnimation();
            dbAnim.From = 0;
            dbAnim.To = 700;
            dbAnim.Duration = TimeSpan.FromSeconds(1);

            ChangeTitleUI.BeginAnimation(Grid.HeightProperty, dbAnim);

            ChangeTitleUI.Visibility = ChangeTitleUI.Visibility == 
                Visibility.Hidden ?
                Visibility.Visible :
                Visibility.Hidden;
        }

        private void ButtonForChangeIcon_Click(object sender, RoutedEventArgs e)
        {
            var dbAnim = new DoubleAnimation();
            dbAnim.From = 0;
            dbAnim.To = 700;
            dbAnim.Duration = TimeSpan.FromSeconds(1);

            ChangeAVA.BeginAnimation(Grid.HeightProperty, dbAnim);

            ChangeAVA.Visibility = ChangeAVA.Visibility ==
                Visibility.Hidden ?
                Visibility.Visible :
                Visibility.Hidden;
        }

        private void Button_For_Apply_AVA_Click(object sender, RoutedEventArgs e)
        {
            AVATARKA.Visibility = Visibility.Visible;

            try
            {
                AVATARKA.Source = new BitmapImage(new Uri(EnterURLforAVA.Text, UriKind.Absolute));
            }
            catch (Exception)
            {
                AVATARKA.Source = new BitmapImage(new Uri(@"https://s0.rbk.ru/v6_top_pics/media/img/9/16/756619467602169.jpg"
                                                  , UriKind.Absolute));
                AVATARKA.Visibility = Visibility.Visible;
            }

            ChangeAVA.Visibility = Visibility.Hidden;
        }
    }
}

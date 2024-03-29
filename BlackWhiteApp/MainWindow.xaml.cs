﻿using System;
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
using System.Net.Sockets;
using BlackWhiteApp.Cods;
using BlackWhiteApp.Pages;
using System.IO;
using System.Threading;

namespace BlackWhiteApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Start();
        }

        private async void Start()
        {
            string name;
            string myExeDir = "name.txt";

            await Server.ConnectAsync();

            if (File.Exists(myExeDir))
            {
                name = File.ReadAllText(myExeDir);

                bool yes = await Server.getLogin(name);

                if (yes)
                {
                    File.WriteAllText(myExeDir, name);

                    NextPage.Content = new Profile();
                }
                else
                {
                    NextPage.Content = new RegisterPage();
                }
            }
            else
                NextPage.Content = new RegisterPage();
        }
    }
}

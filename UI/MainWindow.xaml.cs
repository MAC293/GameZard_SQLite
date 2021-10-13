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
using BLL;

namespace UI
{
    public partial class MainWindow : Window
    {
        Platform platform = new Platform();
        public MainWindow()
        {
            InitializeComponent();

            Checking();
        }

        public void Checking()
        {
            if (platform.Connecting())
            {
                MessageBox.Show("Connected");
            }
            else
            {
                MessageBox.Show("Couldn't Connect");
            }
        }


    }
}

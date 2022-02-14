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
using BLL;

namespace UI
{
    public partial class Selector : Window
    {
        Platform emulator = new Platform();
        public Selector()
        {
            InitializeComponent();

            //Checking();
        }

        private void btnPC_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new PC().Show();
        }

        private void btnEmulator_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Emulator().Show();
        }





        //public void Checking()
        //{
        //    if (emulator.Connecting())
        //    {
        //        MessageBox.Show("Connected");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Couldn't Connect");
        //    }
        //}


    }
}

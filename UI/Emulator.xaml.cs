using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI
{

    public partial class Emulator : Window
    {
        public Emulator()
        {
            InitializeComponent();
        }

        private void btnWiiU_Click(object sender, RoutedEventArgs e)
        {
            #region Load Image to Image Control, Script
            //imgEmulator.Source = "//Assets//Icons//Cemu.ico";
            //imgEmulator.Source = new BitmapImage(new Uri(@"/Assets/Images/Cemu.png", UriKind.Relative));
            //imgEmulator.Source = new BitmapImage(new Uri(@"\Assets\Images\Cemu.png", UriKind.Relative));
            //imgEmulator.Source = new BitmapImage(new Uri(@"\\Assets\Images\Cemu.png", UriKind.Relative));
            //imgEmulator.Source = new BitmapImage(new Uri(@"/UI;component/Assets/Icons/Cemu.ico", UriKind.Relative));
            //imgEmulator.Source = new BitmapImage(new Uri(@"/UI;component/Assets/Images/Cemu.png", UriKind.Relative));
            //var uri = new Uri("pack://application:,,,/Assets/Images/Cemu.png");
            //var bitmap = new BitmapImage(uri);
            //imgEmulator.Source = bitmap;
            //BitmapImage image = new BitmapImage(new Uri("/UI;component/Assets/Images/Cemu.png", UriKind.Relative));
            //imgEmulator.Source = image;
            //imgEmulator.Source = new BitmapImage(new Uri(@"\Assets\Images\Cemu.png"));
            //BitmapImage image = new BitmapImage(new Uri("/MyProject;component/Images/down.png", UriKind.Relative));
            //lblEmulator.Content = "Cemu";
            //imgEmulator.Source = new BitmapImage(new Uri(@"/UI;component/Assets/Icons/Cemu.ico", UriKind.Relative));
            //imgEmulator.Source = new BitmapImage(new Uri(@"/UI;component/Assets/Images/Cemu.png", UriKind.Relative));
            //BitmapImage image = new BitmapImage(new Uri("/UI;component/Assets/Icons/Cemu.ico", UriKind.Relative));
            //imgEmulator.Source = image;
            //imgEmulator.Source = new BitmapImage(new Uri("/UI;component/Assets/Icons/Cemu.ico", UriKind.Relative));
            //string currentAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string currentAssemblyParentPath = Path.GetDirectoryName(currentAssemblyPath);
            //imgEmulator.Source = new BitmapImage(new Uri(String.Format("file:///{0}/MyImages/myim.jpg", currentAssemblyParentPath)));
            //imgEmulator.Source = new BitmapImage(new Uri("pack://application:,,,/UI/Assets/Icons/Cemu.png", UriKind.Relative));
            //imgEmulator.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Assets\\Images\\Cemu.png", UriKind.Absolute));
            //imgEmulator.Source = new BitmapImage(new Uri(@"/Assets/Images/Cemu.png", UriKind.Relative));
            //imgEmulator.Source = new BitmapImage(new Uri(@"..\Assets\Icons\Cemu.ico", UriKind.Relative));
            //imgEmulator.Source = new BitmapImage(new Uri(@"\Assets\Images\Cemu.png", UriKind.RelativeOrAbsolute));imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/FooApplication;component/Images/cat.png"));
            //imgEmulator.Source = new BitmapImage(new Uri(@"pack://application:,,,/GameZard;component/Assets/Images/Cemu.png"));
            //imgEmulator.Source = new BitmapImage(new Uri("/UI;component/Assets/Images/Cemu.png", UriKind.Relative));
            //BitmapImage img = new BitmapImage();
            //img.BeginInit();
            //img.UriSource = new Uri(@"pack://application:,,,/GameZard;component/Assets/Images/Cemu.png");
            //img.EndInit();
            //imgEmulator.Source = img;
            #endregion
            lblEmulator.Content = "Cemu";

            imgEmulator.Source = new BitmapImage(new Uri("/Assets/Icons/Cemu.ico", UriKind.Relative));



        }

        private void btnPSP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPS2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPSX_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnWii_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGameCube_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn3DS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGBA_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSNES_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSwitch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFromPath_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnToPath_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

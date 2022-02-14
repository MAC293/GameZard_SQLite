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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLL;

namespace UI
{

    public partial class Emulator : Window
    {
        private SavedataPlatform _SaveData;
        public Emulator()
        {
            InitializeComponent();

            SaveData = new SavedataPlatform();
        }

        public SavedataPlatform SaveData
        {
            get { return _SaveData; }
            set { _SaveData = value; }
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

            DisplayBackUp();

            SaveData.LoadFrom(lblEmulator.Content.ToString());
            txtFrom.Text = SaveData.FromPath;

            SaveData.LoadTo(lblEmulator.Content.ToString());
            txtTo.Text = SaveData.ToPath;
        }

        private void btnPSP_Click(object sender, RoutedEventArgs e)
        {
            lblEmulator.Content = "PPSSPP";

            imgEmulator.Source = new BitmapImage(new Uri("/Assets/Icons/PPSSPP.ico", UriKind.Relative));

            DisplayBackUp();

            SaveData.LoadFrom(lblEmulator.Content.ToString());
            txtFrom.Text = SaveData.FromPath;

            SaveData.LoadTo(lblEmulator.Content.ToString());
            txtTo.Text = SaveData.ToPath;
        }

        private void btnPS2_Click(object sender, RoutedEventArgs e)
        {
            lblEmulator.Content = "PCSX2";

            imgEmulator.Source = new BitmapImage(new Uri("/Assets/Icons/PCSX2.ico", UriKind.Relative));

            DisplayBackUp();

            SaveData.LoadFrom(lblEmulator.Content.ToString());
            txtFrom.Text = SaveData.FromPath;

            SaveData.LoadTo(lblEmulator.Content.ToString());
            txtTo.Text = SaveData.ToPath;
        }

        private void btnPSX_Click(object sender, RoutedEventArgs e)
        {
            lblEmulator.Content = "ePSXe";

            imgEmulator.Source = new BitmapImage(new Uri("/Assets/Icons/ePSXe.ico", UriKind.Relative));

            DisplayBackUp();

            SaveData.LoadFrom(lblEmulator.Content.ToString());
            txtFrom.Text = SaveData.FromPath;

            SaveData.LoadTo(lblEmulator.Content.ToString());
            txtTo.Text = SaveData.ToPath;
        }

        private void btnWii_Click(object sender, RoutedEventArgs e)
        {
            lblEmulator.Content = "Dolphin(Wii)";

            imgEmulator.Source = new BitmapImage(new Uri("/Assets/Icons/Dolphin.ico", UriKind.Relative));

            DisplayBackUp();

            SaveData.LoadFrom(lblEmulator.Content.ToString());
            txtFrom.Text = SaveData.FromPath;

            SaveData.LoadTo(lblEmulator.Content.ToString());
            txtTo.Text = SaveData.ToPath;
        }

        private void btnGameCube_Click(object sender, RoutedEventArgs e)
        {
            lblEmulator.Content = "Dolphin(GameCube)";

            imgEmulator.Source = new BitmapImage(new Uri("/Assets/Icons/Dolphin.ico", UriKind.Relative));

            DisplayBackUp();

            SaveData.LoadFrom(lblEmulator.Content.ToString());
            txtFrom.Text = SaveData.FromPath;

            SaveData.LoadTo(lblEmulator.Content.ToString());
            txtTo.Text = SaveData.ToPath;
        }

        private void btn3DS_Click(object sender, RoutedEventArgs e)
        {
            lblEmulator.Content = "Citra";

            imgEmulator.Source = new BitmapImage(new Uri("/Assets/Icons/Citra.ico", UriKind.Relative));

            DisplayBackUp();

            SaveData.LoadFrom(lblEmulator.Content.ToString());
            txtFrom.Text = SaveData.FromPath;

            SaveData.LoadTo(lblEmulator.Content.ToString());
            txtTo.Text = SaveData.ToPath;
        }

        private void btnGBA_Click(object sender, RoutedEventArgs e)
        {
            lblEmulator.Content = "Visual Boy Advance";

            imgEmulator.Source = new BitmapImage(new Uri("/Assets/Icons/VisualBoyAdvance.ico", UriKind.Relative));

            DisplayBackUp();

            SaveData.LoadFrom(lblEmulator.Content.ToString());
            txtFrom.Text = SaveData.FromPath;

            SaveData.LoadTo(lblEmulator.Content.ToString());
            txtTo.Text = SaveData.ToPath;
        }

        private void btnSNES_Click(object sender, RoutedEventArgs e)
        {
            lblEmulator.Content = "SNES9x";

            imgEmulator.Source = new BitmapImage(new Uri("/Assets/Icons/SNES9x.ico", UriKind.Relative));

            DisplayBackUp();

            SaveData.LoadFrom(lblEmulator.Content.ToString());
            txtFrom.Text = SaveData.FromPath;

            SaveData.LoadTo(lblEmulator.Content.ToString());
            txtTo.Text = SaveData.ToPath;
        }

        private void btnSwitch_Click(object sender, RoutedEventArgs e)
        {
            lblEmulator.Content = "YUZU";

            imgEmulator.Source = new BitmapImage(new Uri("/Assets/Icons/YUZU.ico", UriKind.Relative));

            DisplayBackUp();

            SaveData.LoadFrom(lblEmulator.Content.ToString());
            txtFrom.Text = SaveData.FromPath;

            SaveData.LoadTo(lblEmulator.Content.ToString());
            txtTo.Text = SaveData.ToPath;
        }

        private void btnFromPath_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fromPath = new FolderBrowserDialog();

            //fromPath.Description = "Select Savedata Source Path";
            fromPath.ShowNewFolderButton = false;
            fromPath.RootFolder = Environment.SpecialFolder.MyComputer;

            DialogResult result = fromPath.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                String path = fromPath.SelectedPath;
                txtFrom.Text = path;

                SaveData.FromPath = path;
                SaveData.SaveFrom(lblEmulator.Content.ToString());


            }
        }

        private void btnToPath_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog toPath = new FolderBrowserDialog();

            //toPath.Description = "Select Savedata Destination Path";
            toPath.ShowNewFolderButton = false;
            toPath.RootFolder = Environment.SpecialFolder.MyComputer;

            DialogResult result = toPath.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                String path = toPath.SelectedPath;
                txtTo.Text = path;

                SaveData.ToPath = path;
                SaveData.SaveTo(lblEmulator.Content.ToString());
            }
        }

        private void rbManually_Checked(object sender, RoutedEventArgs e)
        {
            if (rbManually.IsChecked == true)
            {
                SaveData.BackUpMode = "Manually";
                SaveData.SaveBackUp(lblEmulator.Content.ToString());
            }
        }

        private void rbAutomatically_Checked(object sender, RoutedEventArgs e)
        {
            if (rbAutomatically.IsChecked == true)
            {
                SaveData.BackUpMode = "Automatically";
                SaveData.SaveBackUp(lblEmulator.Content.ToString());
            }
        }

        public void DisplayBackUp()
        {
            SaveData.LoadBackUp(lblEmulator.Content.ToString());

            if (SaveData.BackUpMode == "Manually")
            {
                rbManually.IsChecked = true;
            }
            else if (SaveData.BackUpMode == "Automatically")
            {
                rbAutomatically.IsChecked = true;
            }
            else
            {
                rbManually.IsChecked = false;
                rbAutomatically.IsChecked = false;
            }
        }

        private void btnSelector_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Selector().Show();
        }
    }
}

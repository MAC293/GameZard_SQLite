using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using FolderBrowserDialog = System.Windows.Forms.FolderBrowserDialog;
//using System.IO;
using Path = System.IO.Path;
//using System.Drawing;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLL;
using ListBox = System.Windows.Controls.ListBox;
//using System.Drawing.Image
using MessageBox = System.Windows.MessageBox;
//using System.Drawing.Image;

namespace UI
{
    /// <summary>
    /// Interaction logic for PC.xaml
    /// </summary>
    public partial class PC : Window
    {
        private Game _Game;
        private List<String> _Games;
        public PC()
        {
            InitializeComponent();

            Game = new Game();
            Games = new List<String>();
            //lbGames.Items.Add(Game.Games);
            Game.RetrieveGames(Games);

            DisplayGames(Game);

            Start();

            //MessageBox.Show(lbGames.SelectedItem.ToString());

            //if (Game.Games != null)
            //{
            //    if (Game.Games.Count > 0)
            //    {
            //        foreach (var game in Game.Games)
            //        {
            //            lbGames.Items.Add(game);
            //        }
            //    }
            //}

        }

        public void DisplayGames(Game videogame)
        {
            if (Games != null)
            {
                if (Games.Count > 0)
                {
                    foreach (var game in Games)
                    {
                        lbGames.Items.Add(game);
                    }

                    //lbGames.ItemsSource = Game.Games;
                }
            }
        }

        public void Start()
        {
            lbGames.SelectedIndex = 0;

            //Game.Name = lbGames.SelectedIndex.ToString();
        }

        public Game Game
        {
            get { return _Game; }
            set { _Game = value; }
        }

        public List<String> Games
        {
            get { return _Games; }
            set { _Games = value; }
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            IconHelper.RemoveIcon(this);
        }

        private void btnAddGame_Click(object sender, RoutedEventArgs e)
        {
            if (txtAddRemoveGame.Text == String.Empty)
            {
                MessageBox.Show("Field can't be empty!");
            }
            else
            {
                //Game newGame = new Game();

                Game = new Game();

                Game.Name = txtAddRemoveGame.Text;

                //Boolean flag = false;

                //do
                //{
                //    if (Game.Create(GenerateID()))
                //    {
                //        flag = true;
                //    }

                //} while (!flag);

                Boolean flag = false;

                do
                {

                    if (Game.CheckGame(GenerateID()))
                    {
                        flag = true;
                    }

                } while (!flag);

                lbGames.Items.Add(Game.Name);

                Game.Savedata.ID = Game.ID;
                Game.Savedata.FromPath = String.Empty;
                Game.Savedata.ToPath = String.Empty;
                Game.Savedata.BackUpMode = String.Empty;
                Game.Savedata.LastSaved = String.Empty;

                Game.Create();
                Game.Savedata.Create();


                txtAddRemoveGame.Text = String.Empty;
            }
        }

        public String GenerateID()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[3];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        private void btnRemoveGame_Click(object sender, RoutedEventArgs e)
        {
            String delete = lbGames.SelectedItem.ToString();
            lbGames.Items.Remove(lbGames.Items[lbGames.SelectedIndex]);


            String saveDelete = Game.SendID(delete);

            Game.Savedata.Delete(saveDelete);

            Game.Delete(delete);

            //lbGames.Items.Remove(lbGames.SelectedItem);
            //lbGames.Items.Remove(lbGames.Items[lbGames.SelectedIndex]);
        }

        private void lbGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbGames.SelectedItem != null)
            {
                lblGameName.Content = lbGames.SelectedItem.ToString();

                ShowCover();

                Game.Savedata.LoadFrom(Game.SendID(lbGames.SelectedItem.ToString()));
                txtFrom.Text = Game.Savedata.FromPath;

                Game.Savedata.LoadTo(Game.SendID(lbGames.SelectedItem.ToString()));
                txtTo.Text = Game.Savedata.ToPath;


            }
            else
            {
                lblGameName.Content = String.Empty;
                //lbGames.UnselectAll();
            }


        }

        public void ShowCover()
        {
            if (Game.DisplayCover(lbGames.SelectedItem.ToString()))
            {
                imgGameCover.Source = LoadImage(Game.Cover);
            }
            else
            {
                imgGameCover.Source = null;
            }

        }

        private BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;

            var image = new BitmapImage();

            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }

            image.Freeze();

            return image;
        }

        private void btnChangeCover_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openedFile = new OpenFileDialog();

            openedFile.Filter = "Image Files(*.jpg; *.png;)|*.jpg; *.png;";
            openedFile.Title = "Select Cover Image";

            if (openedFile.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            else
            {
                imgGameCover.Source = new BitmapImage(new Uri(openedFile.FileName));

                byte[] buffer = File.ReadAllBytes(openedFile.FileName);

                Game.Cover = buffer;

                //if (Game.Cover != null)
                //{
                //    MessageBox.Show("Game.Cover != null");
                //}

                Game.AddCover(lbGames.SelectedItem.ToString());
                //MessageBox.Show(lbGames.SelectedItem.ToString());



                //if (Game.Cover != null)
                //{
                //    MessageBox.Show("Game.Cover != null");
                //}

            }
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

                String id = Game.SendID(lbGames.SelectedItem.ToString());
                Game.Savedata.FromPath = path;
                Game.Savedata.SaveFrom(id);

                
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

                String id = Game.SendID(lbGames.SelectedItem.ToString());
                Game.Savedata.ToPath = path;
                Game.Savedata.SaveTo(id);
            }
        }


        //private void rbManually_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (rbAutomatically.IsChecked == true)
        //    {

        //    }
        //    else if (rbManually.IsChecked == true)
        //    {

        //    }
        //}

        private void rbManually_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void rbAutomatically_Checked(object sender, RoutedEventArgs e)
        {

        }




        //private byte[] ImageToByte(System.Drawing.Image imageIn)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        imageIn.Save(ms, imageIn.RawFormat);

        //        return ms.ToArray();
        //    }
        //}
    }
}

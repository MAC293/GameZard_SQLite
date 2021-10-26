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
//using System.IO;
//using System.Drawing;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLL;
//using System.Drawing.Image
using MessageBox = System.Windows.MessageBox;

namespace UI
{
    /// <summary>
    /// Interaction logic for PC.xaml
    /// </summary>
    public partial class PC : Window
    {
        private Game _Game;
        public PC()
        {
            InitializeComponent();

            Game = new Game();
            //lbGames.Items.Add(Game.Games);
            Game.RetrieveGames();

            DisplayGames(Game);

            lbGames.SelectedIndex = 0;




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
            if (videogame.Games != null)
            {
                if (videogame.Games.Count > 0)
                {
                    foreach (var game in Game.Games)
                    {
                        lbGames.Items.Add(game);
                    }

                    //lbGames.ItemsSource = Game.Games;
                }
            }
        }

        public Game Game
        {
            get { return _Game; }
            set { _Game = value; }
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
                Game newGame = new Game();

                newGame.Name = txtAddRemoveGame.Text;

                Boolean flag = false;

                do
                {
                    if (newGame.Create(GenerateID()))
                    {
                        flag = true;
                    }

                } while (!flag);

                lbGames.Items.Add(newGame.Name);

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

            Game.Delete(delete);

            //lbGames.Items.Remove(lbGames.SelectedItem);
            //lbGames.Items.Remove(lbGames.Items[lbGames.SelectedIndex]);
        }

        private void lbGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblGameName.Content = lbGames.SelectedItem.ToString();


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


                if (Game.Cover != null)
                {
                    MessageBox.Show("Game.Cover != null");
                }

            }
        }

        private byte[] ImageToByte(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                
                return ms.ToArray();
            }
        }
    }
}

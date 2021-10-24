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
using System.Windows.Shapes;
using BLL;

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
            //lbGames.DataContext = this;
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

        }
    }
}

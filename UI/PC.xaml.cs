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
        public PC()
        {
            InitializeComponent();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            IconHelper.RemoveIcon(this);
        }

        private void btnAddGame_Click(object sender, RoutedEventArgs e)
        {
            Game newGame = new Game();

            newGame.Name = txtAddRemoveGame.Text;

            do
            {
                newGame.Create(GenerateID());

            } while (!newGame.Create(GenerateID()));

            lbGames.Items.Add(newGame.Name);

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
    }
}

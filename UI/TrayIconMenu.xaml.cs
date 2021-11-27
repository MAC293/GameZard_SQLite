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
    /// Interaction logic for TrayIconMenu.xaml
    /// </summary>
    public partial class TrayIconMenu : Window
    {
        private List<String> _Games;
        public TrayIconMenu()
        {
            InitializeComponent();

            Games = new List<String>();

            TrayMenu.DisplayGames(Games);

            FillList();

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

        public void FillList()
        {
            if (Games != null)
            {
                if (Games.Count > 0)
                {
                    foreach (var game in Games)
                    {
                        cmbGames.Items.Add(game);
                    }

                    //lbGames.ItemsSource = Game.Games;
                }
            }
        }

        
    }
}

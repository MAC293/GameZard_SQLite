using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using BLL;

namespace UI
{
    /// <summary>
    /// Interaction logic for TrayIconMenu.xaml
    /// </summary>
    public partial class TrayIconMenu : Window
    {
        private List<string> _Games;

        //private WorkerHelper _Worker;
        private Game _Game;
        private Platform _Platform;

        public TrayIconMenu()
        {
            InitializeComponent();

            Games = new List<string>();

            TrayMenu.DisplayGames(Games);

            FillList();

            //pbPC.Value = Worker.Progress;
        }

        //private bool isLoaded;
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if (isLoaded)
        //        return;
        //    isLoaded = true;
        //    MessageBox.Show("gdsfgd");

        //}

        //public void InitWorker()
        //{
        //    Worker = new WorkerHelper();
        //}

        public List<string> Games
        {
            get => _Games;
            set => _Games = value;
        }

        public Game Game
        {
            get => _Game;
            set => _Game = value;
        }

        public Platform Platform
        {
            get => _Platform;
            set => _Platform = value;
        }

        //public WorkerHelper Worker
        //{
        //    get { return _Worker; }
        //    set { _Worker = value; }
        //}

        protected override void OnSourceInitialized(EventArgs e)
        {
            IconHelper.RemoveIcon(this);
        }

        public void FillList()
        {
            if (Games != null)
                if (Games.Count > 0)
                    foreach (var game in Games)
                        cmbGames.Items.Add(game);

                //lbGames.ItemsSource = Game.Games;
        }

        private void btnPCBU_Click(object sender, RoutedEventArgs e)
        {
            if (cmbGames.SelectedItem == null)
            {
                MessageBox.Show("Not Game Selected!");
            }
            else
            {
                var gameName = cmbGames.SelectedValue.ToString();

                Game = new Game();

                var gameID = Game.SendID(gameName);

                Game.Savedata.LoadFrom(gameID);

                //From Path
                var fromPath = Game.Savedata.FromPath;

                Game.Savedata.LoadTo(gameID);

                //To Path
                var toPath = Game.Savedata.ToPath;

                //WorkerHelper1 pcWorker = new WorkerHelper1();
                WorkerHelper pcWorker = new WorkerHelper();

                pcWorker.From = fromPath;
                pcWorker.To = toPath;

                pcWorker.ProgressBar = "PC";

                DataContext = pcWorker;

                pcWorker.ExecuteWorker();
            }
        }

        private void btnVBABU_Click(object sender, RoutedEventArgs e)
        {
            Platform = new Platform();

            Platform.Savedata.LoadFrom("Visual Boy Advance");
            Platform.Savedata.LoadTo("Visual Boy Advance");

            //WorkerHelper1 vbaWorker = new WorkerHelper1();
            WorkerHelper vbaWorker = new WorkerHelper();

            vbaWorker.From = Platform.Savedata.FromPath;
            vbaWorker.To = Platform.Savedata.ToPath;

            vbaWorker.ProgressBar = "VBA";

            DataContext = vbaWorker;

            vbaWorker.ExecuteWorker();
        }

        #region Unused CopyFolder

        public void CopyFolder1(string source, string target)
        {
            var fsin = new FileStream(source, FileMode.Open);
            var fsout = new FileStream(target, FileMode.Create);

            var buffer = new byte[10000000]; //10 GB

            int readBytes;

            while ((readBytes = fsin.Read(buffer, 0, buffer.Length)) > 0)
                fsout.Write(buffer, 0, readBytes);
            //Worker.ReportProgress((int)(fsin.Position * 100 / fsin.Length));

            fsin.Close();
            fsout.Close();
        }

        #endregion
    }
}
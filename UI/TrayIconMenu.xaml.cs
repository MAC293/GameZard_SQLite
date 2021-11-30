using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
        private BackgroundWorker _Worker;
        private Game _Game;

        public TrayIconMenu()
        {
            InitializeComponent();

            Games = new List<String>();

            TrayMenu.DisplayGames(Games);

            FillList();

            InitWorker();


            

        }

        public void InitWorker()
        {
            Worker = new BackgroundWorker();

            Worker.WorkerSupportsCancellation = true;
            Worker.WorkerReportsProgress = true;
            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            Worker.ProgressChanged += Worker_ProgressChanged;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbPC.Value = e.ProgressPercentage;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //XtraMessageBox.Show("Operation is Aborted!");

                MessageBox.Show("Operation is Aborted!");
            }
            else
            {
                //MessageBox.Show("Operation is Completed!");
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            CopyFolder(Game.Savedata.FromPath, Game.Savedata.ToPath);
        }

        public List<String> Games
        {
            get { return _Games; }
            set { _Games = value; }
        }

        public Game Game
        {
            get { return _Game; }
            set { _Game = value; }
        }

        public BackgroundWorker Worker
        {
            get { return _Worker; }
            set { _Worker = value; }
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

        private void btnPCBU_Click(object sender, RoutedEventArgs e)
        {
            String gameName = cmbGames.SelectedValue.ToString();

            //Game gameBU = new Game();

            Game = new Game();

            String gameID = Game.SendID(gameName);

            Game.Savedata.LoadFrom(gameID);

            //From Path
            String fromPath = Game.Savedata.FromPath;

            //MessageBox.Show(fromPath);

            Game.Savedata.LoadTo(gameID);

            //To Path
            String toPath = Game.Savedata.ToPath;

            //MessageBox.Show(toPath);

            //CopyFolder(Game.Savedata.FromPath, Game.Savedata.ToPath);




        }



        public void CopyFolder(String source, String target)
        {
            FileStream fsout = new FileStream(target, FileMode.Create);
            FileStream fsin = new FileStream(source, FileMode.Open);

            byte[] buffer = new Byte[10000000000]; //10 GB

            int readBytes;

            while ((readBytes = fsin.Read(buffer, 0, buffer.Length)) > 0)
            {
                fsout.Write(buffer, 0, readBytes);
                Worker.ReportProgress((int)(fsin.Position * 100 / fsin.Length));
            }

            fsin.Close();
            fsout.Close();
        }
    }
}

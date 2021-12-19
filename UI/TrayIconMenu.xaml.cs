using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            InitWorker();

            Games = new List<String>();

            TrayMenu.DisplayGames(Games);

            FillList();

        }

        public void InitWorker()
        {
            Worker = new BackgroundWorker();

            Worker.WorkerSupportsCancellation = true;
            Worker.WorkerReportsProgress = true;
            Worker.ProgressChanged += Worker_ProgressChanged;
            Worker.DoWork += Worker_DoWork;

            //Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbPC.Value = e.ProgressPercentage;
        }

        //private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (e.Cancelled)
        //    {
        //        //XtraMessageBox.Show("Operation is Aborted!");

        //        MessageBox.Show("Operation is Aborted!");
        //    }
        //    else
        //    {
        //        //MessageBox.Show("Operation is Completed!");
        //    }
        //}

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            //MessageBox.Show("Operation is Aborted!");
            for (int i = 0; i <= 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);

                //Wait 2 seconds
                Thread.Sleep(2000);

                Worker.ReportProgress(i);
            }

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
            if (cmbGames.SelectedItem == null)
            {
                MessageBox.Show("Not Game Selected!");
            }
            else
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

                //CopyFolder(fromPath, toPath);

                Worker.RunWorkerAsync();
            }


        }

        public void CopyFolder(String sourcePath, String targetPath)
        {
            //Now Create all of the directories
            foreach (String dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (String newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        public void CopyFolder1(String source, String target)
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

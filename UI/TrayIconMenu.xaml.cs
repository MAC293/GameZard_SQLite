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
        private List<String> _Games;
        private BackgroundWorker _Worker;
        private BackgroundWorker _Worker1;
        private Game _Game;
        private Platform _Platform;

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

            Worker1 = new BackgroundWorker();

            Worker1.WorkerSupportsCancellation = true;
            Worker1.WorkerReportsProgress = true;
            Worker1.ProgressChanged += Worker1_ProgressChanged;
            Worker1.DoWork += Worker1_DoWork;

            //Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

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

        public Platform Platform
        {
            get { return _Platform; }
            set { _Platform = value; }
        }
        public BackgroundWorker Worker
        {
            get { return _Worker; }
            set { _Worker = value; }
        }

        public BackgroundWorker Worker1
        {
            get { return _Worker1; }
            set { _Worker1 = value; }
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

                Game = new Game();

                String gameID = Game.SendID(gameName);

                Game.Savedata.LoadFrom(gameID);

                //From Path
                String fromPath = Game.Savedata.FromPath;

                Game.Savedata.LoadTo(gameID);

                //To Path
                String toPath = Game.Savedata.ToPath;

                Worker.RunWorkerAsync();
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            CopyFolder(Game.Savedata.FromPath, Game.Savedata.ToPath);
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Change the value of the ProgressBar
            pbPC.Value = e.ProgressPercentage;
        }

        private void btnVBABU_Click(object sender, RoutedEventArgs e)
        {
            Platform = new Platform();

            Platform.Savedata.LoadFrom("Visual Boy Advance");
            Platform.Savedata.LoadTo("Visual Boy Advance");

            Worker1.RunWorkerAsync();

        }

        private void Worker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CopyFolder(Platform.Savedata.FromPath, Platform.Savedata.ToPath);
        }

        private void Worker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                pbVBA.Value = e.ProgressPercentage;
            }));
            //pbVBA.Value = e.ProgressPercentage;

        }

        public void CopyFolder(String sourcePath, String targetPath)
        {
            //Source top folder quantity
            var sourceQTY = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);

            //Target top folder quantity
            var targetQTY = Directory.GetFiles(targetPath, "*.*", SearchOption.AllDirectories);


            //Creates all of the directories
            foreach (String dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            int counter = 0;
            //Copy all the files replacing any current file with the same name
            foreach (String newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);

                counter += 1;
                int percentage = 100 * counter / sourceQTY.Length;
                Worker.ReportProgress(percentage);
                Worker1.ReportProgress(percentage);
            }
        }

        #region Unused CopyFolder
        public void CopyFolder1(String source, String target)
        {
            FileStream fsin = new FileStream(source, FileMode.Open);
            FileStream fsout = new FileStream(target, FileMode.Create);

            byte[] buffer = new Byte[10000000]; //10 GB

            int readBytes;

            while ((readBytes = fsin.Read(buffer, 0, buffer.Length)) > 0)
            {
                fsout.Write(buffer, 0, readBytes);
                Worker.ReportProgress((int)(fsin.Position * 100 / fsin.Length));
            }

            fsin.Close();
            fsout.Close();
        }
        #endregion


    }
}

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
            //Change the value of the ProgressBar
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

            //Task.Run(() => CopyFolder(Game.Savedata.FromPath, Game.Savedata.ToPath));
            //MessageBox.Show("Operation is Aborted!");

            //Task.Run(() => {

            //    for (int i = 0; i <= 10; i++)
            //    {
            //        MessageBox.Show("Worker: " + i.ToString());

            //    }
            //});

            //for (int i = 0; i <= 100; i++)
            //{
            //    //(sender as BackgroundWorker).ReportProgress(i);
            //    Worker.ReportProgress(i);

            //    //Wait 1 seconds
            //    Thread.Sleep(100);

            //    //Report progress
            //    //Worker.ReportProgress(i);
            //}

            //for (int i = 0; i < 17; i++)
            //{
            //    //17, files qty
            //    int percentage = (i + 1) * 100 / 17;
            //    int PercentageDone = 100 * SizeOfFilesAlreadyCopied/TotalSizeOfAllFiles;
            //    Worker.ReportProgress(percentage/PercentageDone);
            //}

            CopyFolder4(Game.Savedata.FromPath, Game.Savedata.ToPath);
            //CopyFolder1(Game.Savedata.FromPath, Game.Savedata.ToPath);
            //CopyFolder2(Game.Savedata.FromPath, Game.Savedata.ToPath);
            //for (int i = 0; i < 100; i++)
            //{
            //    int percentage = (i + 1) * 100 / 60000000;
            //    Worker.ReportProgress(percentage);
            //}

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

                //Start the BackgroundWorker
                //Task.Run(() => CopyFolder(Game.Savedata.FromPath, Game.Savedata.ToPath));

                //CopyFolder(Game.Savedata.FromPath, Game.Savedata.ToPath));

                //Task.Run(() =>
                //{

                //    for (int i = 0; i <= 10; i++)
                //    {
                //        MessageBox.Show("UI Thread (Task.Run): " + i.ToString());


                //    }
                //});

                //for (int i = 0; i < filesCount; i++)
                //{
                //    ParseSingleFile(); // pass filename here
                //    int percentage = (i + 1) * 100 / filesCount;
                //    myBGWorker.ReportProgress(percentage);
                //}

                //for (int i = 0; i <= 10; i++)
                //{
                //    MessageBox.Show("UI Thread: " + i.ToString());

                //}

                //Task.Run(() => {

                //    for (int i = 0; i <= 10; i++)
                //    {
                //        MessageBox.Show("UI Thread: " + i.ToString());

                //    }
                //});

                //CopyFolder2(Game.Savedata.FromPath, Game.Savedata.ToPath);

                //var fruits = new[] { "apple", "cherry", "pineapple", "plum" };

                //var result = new string[fruits.Length];

                //for (int i = 0; i < fruits.Length; i++)
                //{
                //    result[i] = fruits[i];
                //}


                //foreach (var fruit in result)
                //{
                //    MessageBox.Show(fruit);
                //}


                Worker.RunWorkerAsync();
                //CopyFolder(Game.Savedata.FromPath, Game.Savedata.ToPath);


            }


        }

        public void CopyFolder(String source, String target)
        {
            String finalTarget = target;
            Boolean same = false;

            if (finalTarget != null)
            {
                same = true;
            }

            //DirectoryInfo dir = new DirectoryInfo(source);
            //int count = dir.GetFiles().Length;

            var files = Directory.GetFiles(source, "*.*", SearchOption.AllDirectories);
            
            MessageBox.Show("Target: " + files.Length);

            MessageBox.Show("Source: " + source);
            MessageBox.Show("Target: " + target);

            foreach (var directory in Directory.GetDirectories(source))
            {
                MessageBox.Show("Source: " + source);
                string dirName = System.IO.Path.GetFileName(directory);

                if (!Directory.Exists(System.IO.Path.Combine(target, dirName)))
                {
                    MessageBox.Show("Target: " + target);
                    Directory.CreateDirectory(System.IO.Path.Combine(target, dirName));
                    MessageBox.Show("Target: " + target);
                }

                CopyFolder(directory, System.IO.Path.Combine(target, dirName));
                MessageBox.Show("Target: " + target);
                MessageBox.Show("dirName: " + dirName);
            }

            foreach (var file in Directory.GetFiles(source))
            {
                MessageBox.Show("Source: " + source);
                File.Copy(file, System.IO.Path.Combine(target, System.IO.Path.GetFileName(file)));
                MessageBox.Show("Target: " + target);

                //DirectoryInfo dir = new DirectoryInfo(target);
                //int count = dir.GetFiles().Length;
                
                //MessageBox.Show("File: " + count);

                //Worker.ReportProgress(count);


                //MessageBox.Show("Target: " + target);
                //MessageBox.Show("dir 2: " + count);
            }
        }

        public void CopyFolder4(String sourcePath, String targetPath)
        {
            //int PercentageDone = 100 * SizeOfFilesAlreadyCopied / TotalSizeOfAllFiles;
            var sourceQTY = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);

            var targetQTY = Directory.GetFiles(targetPath, "*.*", SearchOption.AllDirectories);


            //Now Create all of the directories
            foreach (String dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (String newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
                int percentage = 100 * targetQTY.Length / sourceQTY.Length;
                Worker.ReportProgress(percentage);

            }
        }

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

        public void CopyFolder2(String sourcePath, String targetPath)
        {

            int bufferSize = 1024 * 512;
            using (FileStream inStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (FileStream fileStream = new FileStream(targetPath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                int bytesRead = -1;
                var totalReads = 0;
                var totalBytes = inStream.Length;
                byte[] bytes = new byte[bufferSize];
                int prevPercent = 0;

                while ((bytesRead = inStream.Read(bytes, 0, bufferSize)) > 0)
                {
                    fileStream.Write(bytes, 0, bytesRead);
                    totalReads += bytesRead;
                    int percent = System.Convert.ToInt32(((decimal)totalReads / (decimal)totalBytes) * 100);
                    if (percent != prevPercent)
                    {
                        Worker.ReportProgress(percent);
                        prevPercent = percent;
                    }
                }
            }
        }

       
    }
}

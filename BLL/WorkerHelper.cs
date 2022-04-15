using System;
using System.Collections.Generic;
//BackgroundWorker
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BLL
{
    public class WorkerHelper : INotifyPropertyChanged, IBars
    {
        private String _From;
        private String _To;
        private BackgroundWorker _Worker;
        private String _ProgressBar;
        public int PCBar { get; set; }
        public int VBABar { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public WorkerHelper()
        {
            //Worker = new BackgroundWorker();
            //Worker.WorkerSupportsCancellation = true;
            //Worker.WorkerReportsProgress = true;
            //Worker.ProgressChanged += Worker_ProgressChanged;
            //Worker.DoWork += Worker_DoWork;
        }

        public String From
        {
            get { return _From; }
            set { _From = value; }
        }

        public String To
        {
            get { return _To; }
            set { _To = value; }
        }

        public BackgroundWorker Worker
        {
            get { return _Worker; }
            set { _Worker = value; }
        }

        public String ProgressBar
        {
            get { return _ProgressBar; }
            set { _ProgressBar = value; }
        }

        public void CreateWorker()
        {
            Worker = new BackgroundWorker();
            Worker.WorkerSupportsCancellation = true;
            Worker.WorkerReportsProgress = true;
            Worker.ProgressChanged += Worker_ProgressChanged;
            Worker.DoWork += Worker_DoWork;
        }

        public void CopyFolder(String sourcePath, String targetPath)
        {
            //MessageBox.Show("Source Path: " + sourcePath);
            //MessageBox.Show("Target Path: " + targetPath);

            var sourceQTY = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);

            foreach (String dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            int counter = 0;

            foreach (String newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);

                counter += 1;
                int percentageW = 100 * counter / sourceQTY.Length;

                Worker.ReportProgress(percentageW);
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            CopyFolder(From, To);
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (ProgressBar == "PC")
            {
                PCBar = e.ProgressPercentage;

                if (PCBar > 0)
                {
                    OnPropertyChanged(nameof(PCBar));
                }
            }

            if (ProgressBar == "VBA")
            {
                VBABar = e.ProgressPercentage;

                if (VBABar > 0)
                {
                    OnPropertyChanged(nameof(VBABar));
                }
            }
        }

        public void ExecuteWorker()
        {
            if (ProgressBar == "PC")
            {
                Worker.RunWorkerAsync();
            }

            if (ProgressBar == "VBA")
            {
                Worker.RunWorkerAsync();
            }
        }

        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
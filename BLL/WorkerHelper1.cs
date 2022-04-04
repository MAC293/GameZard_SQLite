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
    public class WorkerHelper1 : INotifyPropertyChanged
    {
        private String _From;
        private String _To;
        private BackgroundWorker _Worker;
        private int _Progress;
        //private Observer _Observer;

        public event PropertyChangedEventHandler PropertyChanged;

        public WorkerHelper1()
        {

            //Observer = new Observer();
            Worker = new BackgroundWorker();
            Worker.WorkerSupportsCancellation = true;
            Worker.WorkerReportsProgress = true;
            Worker.ProgressChanged += Worker_ProgressChanged;
            Worker.DoWork += Worker_DoWork;

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

        public int Progress
        {
            get { return _Progress; }
            set { _Progress = value; }
        }
        //public Observer Observer
        //{
        //    get { return _Observer; }
        //    set { _Observer = value; }
        //}

        public void CopyFolder(String sourcePath, String targetPath)
        {
            var sourceQTY = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);

            //Target top folder quantity
            //var targetQTY = Directory.GetFiles(targetPath, "*.*", SearchOption.AllDirectories);

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

            Progress = e.ProgressPercentage;

            if (Progress > 0)
            {
                OnPropertyChanged(nameof(Progress));


            }
        }

        public void ExecuteWorker()
        {
            Worker.RunWorkerAsync();
        }

        public void OnPropertyChanged(String propertyName)
        {

            if (PropertyChanged != null)
            {
                //PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}


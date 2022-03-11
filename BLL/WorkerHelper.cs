﻿using System;
using System.Collections.Generic;
//BackgroundWorker
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WorkerHelper
    {
        private String _From;
        private String _To;
        private BackgroundWorker _Worker;

        public WorkerHelper()
        {
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
            
            //pbPC.Value = e.ProgressPercentage;

            
        }

        public void ExecuteWorker()
        {
            Worker.RunWorkerAsync();
        }
    }
}
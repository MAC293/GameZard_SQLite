﻿using System;
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
        private WorkerHelper _Worker;
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
            Worker = new WorkerHelper();
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

        public Platform Platform
        {
            get { return _Platform; }
            set { _Platform = value; }
        }
        public WorkerHelper Worker
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

                Game = new Game();

                String gameID = Game.SendID(gameName);

                Game.Savedata.LoadFrom(gameID);

                //From Path
                String fromPath = Game.Savedata.FromPath;

                Game.Savedata.LoadTo(gameID);

                //To Path
                String toPath = Game.Savedata.ToPath;

                Worker.From = fromPath;
                Worker.To = toPath;

                Worker.ExecuteWorker();
            }
        }

       

        private void btnVBABU_Click(object sender, RoutedEventArgs e)
        {
            Platform = new Platform();

            Platform.Savedata.LoadFrom("Visual Boy Advance");
            Platform.Savedata.LoadTo("Visual Boy Advance");
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
                //Worker.ReportProgress((int)(fsin.Position * 100 / fsin.Length));
            }

            fsin.Close();
            fsout.Close();
        }
        #endregion

    }
}

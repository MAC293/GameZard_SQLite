using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DAL.Models;

namespace BLL
{
    public class SavedataGame
    {
        private String _ID;
        private String _FromPath;
        private String _ToPath;
        private String _BackUpMode;
        private String _LastSaved;
        //private String _Game;

        public SavedataGame()
        {

        }

        public String ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public String FromPath
        {
            get { return _FromPath; }
            set { _FromPath = value; }
        }

        public String ToPath
        {
            get { return _ToPath; }
            set { _ToPath = value; }
        }

        public String BackUpMode
        {
            get { return _BackUpMode; }
            set { _BackUpMode = value; }
        }

        public String LastSaved
        {
            get { return _LastSaved; }
            set { _LastSaved = value; }
        }

        //public String Game
        //{
        //    get { return _Game; }
        //    set { _Game = value; }
        //}

        public Boolean Create()
        {
            try
            {
                using (GameZardContext context = new GameZardContext())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {

                        var saveDAL = context.SavedataPcs.FirstOrDefault(save =>
                            save.Id == ID);

                        //MessageBox.Show("ID, Game Class: " + id);

                        if (saveDAL == null)
                        {
                            saveDAL = new SavedataPc();

                            saveDAL.Id = ID;
                            saveDAL.FromPath = FromPath;
                            saveDAL.ToPath = ToPath;
                            saveDAL.BackUpMode = BackUpMode;
                            saveDAL.LastSaved = LastSaved;

                            context.SavedataPcs.Add(saveDAL);

                            context.SaveChanges();
                            dbContextTransaction.Commit();

                            return true;
                        }

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }

            return false;
        }

        public void Delete(String gameID)
        {
            try
            {
                using (GameZardContext context = new GameZardContext())
                {
                    {
                        var saveDAL = context.SavedataPcs.FirstOrDefault(save => save.Id == gameID);

                        context.Remove(saveDAL);

                        context.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }
        }

        public void SaveFrom(String gameID)
        {
            try
            {
                using (GameZardContext context = new GameZardContext())
                {
                    var saveDAL = context.SavedataPcs.FirstOrDefault(save =>
                            save.Id == gameID);

                    if (saveDAL != null)
                    {
                        saveDAL.FromPath = FromPath;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }
        }

        public void SaveTo(String gameID)
        {
            try
            {
                using (GameZardContext context = new GameZardContext())
                {
                    var saveDAL = context.SavedataPcs.FirstOrDefault(save =>
                            save.Id == gameID);

                    if (saveDAL != null)
                    {
                        saveDAL.ToPath = ToPath;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }
        }

        //public String GenerateID()
        //{
        //    var chars = "0123456789";
        //    var stringChars = new char[3];
        //    var random = new Random();

        //    for (int i = 0; i < stringChars.Length; i++)
        //    {
        //        stringChars[i] = chars[random.Next(chars.Length)];
        //    }

        //    var finalString = new String(stringChars);

        //    return finalString;
        //}

    }
}

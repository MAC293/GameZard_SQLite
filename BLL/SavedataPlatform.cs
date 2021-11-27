using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DAL.Models;

namespace BLL
{
    public class SavedataPlatform
    {
        private String _ID;
        private String _FromPath;
        private String _ToPath;
        private String _BackUpMode;
        private String _LastSaved;

        public SavedataPlatform()
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

        public void SaveBackUp(String emulatorName)
        {
            try
            {
                using (GameZardContext context = new GameZardContext())
                {
                    var saveDAL = context.SavedataEmulators.FirstOrDefault(save =>
                            save.Id == emulatorName);

                    if (saveDAL != null)
                    {
                        saveDAL.BackUpMode = BackUpMode;
                        context.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }
        }

        public void LoadBackUp(String emulatorName)
        {
            try
            {
                using (GameZardContext context = new GameZardContext())
                {
                    var saveDAL = context.SavedataEmulators.FirstOrDefault(save =>
                            save.Id == emulatorName);

                    if (saveDAL != null)
                    {
                        if (saveDAL.BackUpMode == null)
                        {
                            BackUpMode = String.Empty;
                        }
                        else
                        {
                            BackUpMode = saveDAL.BackUpMode;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }
        }


    }
}

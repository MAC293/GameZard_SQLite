using System;
using System.Linq;
using System.Windows;
using DAL.Models;

namespace BLL
{
    public class Platform
    {
        private String _Name;
        private String _Console;
        private SavedataPlatform _Savedata;
        public Platform()
        {
            Savedata = new SavedataPlatform();
        }

        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public String Console
        {
            get { return _Console; }
            set { _Console = value; }
        }

        public SavedataPlatform Savedata
        {
            get { return _Savedata; }
            set { _Savedata = value; }
        }



        //public Boolean Connecting()
        //{
        //    try
        //    {
        //        using (GameZardContext context = new GameZardContext())
        //        {

        //            //var emulatorDAL = context.Emulators.Find("");
        //            var emulatorDAL = context.Emulators.FirstOrDefault(emu => emu.Name == "" &&
        //                                                                    emu.Console == "");
                    
        //            if (emulatorDAL == null)
        //            {
        //                return true;
        //            }

        //            //if (emulatorDAL.Name == "Test" && emulatorDAL.Console == "Test")
        //            //{
        //            //    return true;
        //            //}

        //            return false;

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        //MessageBox.Show("Exception: " + ex.InnerException.Source);
        //        MessageBox.Show("Exception: " + ex);
        //    }

        //    return false;
        //}
    }
}

using System;
using System.Linq;
using System.Windows;
using DAL.Models;

namespace BLL
{
    public class Platform
    {
        public Platform()
        {

        }

        public Boolean Connecting()
        {
            try
            {
                using (GameZardContext context = new GameZardContext())
                {

                    //var emulatorDAL = context.Emulators.Find("");
                    var emulatorDAL = context.Emulators.FirstOrDefault(emu => emu.Name == "" &&
                                                                            emu.Console == "");

                    
                    if (emulatorDAL == null)
                    {
                        //emulatorDAL = new Emulator();

                        //emulatorDAL.Name = "Test";
                        //emulatorDAL.Console = "Test";

                        //context.Emulators.Add(emulatorDAL);

                        //context.SaveChanges();

                        return true;

                    }

                    //if (emulatorDAL.Name == "Test" && emulatorDAL.Console == "Test")
                    //{
                    //    return true;
                    //}

                    return false;

                }
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Exception: " + ex.InnerException.Source);
                MessageBox.Show("Exception: " + ex);
            }

            return false;
        }
    }
}

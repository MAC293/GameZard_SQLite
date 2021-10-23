using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DAL.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace BLL
{
    public class Game
    {
        private String _ID;
        private String _Name;
        private Byte[] _Cover;

        public Game()
        {

        }

        public String ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public Byte[] Cover
        {
            get { return _Cover; }
            set { _Cover = value; }
        }

        public Boolean Create(String id)
        {
            try
            {
                using (GameZardContext context = new GameZardContext())
                {
                    var videogameDAL = context.Videogames.FirstOrDefault(game =>
                        game.Id == id);

                    if (videogameDAL == null)
                    {
                        videogameDAL = new Videogame();

                        videogameDAL.Id = id;
                        videogameDAL.Name = Name;

                        context.Videogames.Add(videogameDAL);

                        context.SaveChanges();

                        return true;
                    }

                    return false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }

            return false;
        }

        public String GenerateID()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[3];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        public Boolean CheckID(String id)
        {
            try
            {
                using (GameZardContext context = new GameZardContext())
                {
                    var gameIDDAL = context.Videogames.FirstOrDefault(game => game.Id == id);

                    if (gameIDDAL == null)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return false;
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
                        emulatorDAL = new Emulator();

                        emulatorDAL.Name = "Test";
                        emulatorDAL.Console = "Test";

                        context.Emulators.Add(emulatorDAL);

                        context.SaveChanges();

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

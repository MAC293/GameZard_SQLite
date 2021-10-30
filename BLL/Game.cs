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
        //private List<String> _Games;
        private SavedataGame _Savedata;

        public Game()
        {
            Savedata = new SavedataGame();
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

        //public List<String> Games
        //{
        //    get { return _Games; }
        //    set { _Games = value; }
        //}

        public SavedataGame Savedata
        {
            get { return _Savedata; }
            set { _Savedata = value; }
        }

        public void Create()
        {
            try
            {
                using (GameZardContext context = new GameZardContext())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {

                        var videogameDAL = context.Videogames.FirstOrDefault(game =>
                            game.Id == ID);

                        //MessageBox.Show("ID, Game Class: " + id);

                        if (videogameDAL == null)
                        {
                            //Savedata.ID = id;

                            videogameDAL = new Videogame();

                            videogameDAL.Id = ID;
                            videogameDAL.Name = Name;

                            context.Videogames.Add(videogameDAL);

                            context.SaveChanges();
                            dbContextTransaction.Commit();

                            //return true;
                        }

                        //return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }

            //return false;

        }

        public Boolean CheckGame(String checkID)
        {
            try
            {
                using (GameZardContext context = new GameZardContext())
                {
                    var videogameDAL = context.Videogames.FirstOrDefault(game =>
                           game.Id == checkID);

                    if (videogameDAL == null)
                    {
                        ID = checkID;
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

        public void Delete(String name)
        {
            try
            {
                using (GameZardContext context = new GameZardContext())
                {
                    {
                        var gameDAL = context.Videogames.FirstOrDefault(game => game.Name == name);

                        context.Remove(gameDAL);

                        context.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }
        }

        public String GenerateID()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var stringChars = new char[3];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        public void RetrieveGames(List<String> games)
        {
            try
            {
                using (GameZardContext context = new GameZardContext())
                {
                    if (!IsEmpty())
                    {
                        var gameDAL = context.Videogames.Select((game =>
                            new { game.Id, game.Name, game.Cover })).ToList();

                        for (int i = 0; i < gameDAL.Count(); i++)
                        {
                            String name = gameDAL.ElementAt(i).Name;
                            games.Add(name);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public Boolean IsEmpty()
        {
            try
            {
                using (GameZardContext context = new GameZardContext())
                {
                    if (context.Videogames.Any())
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return true;
        }

        public String SendID(String name)
        {
            String id = String.Empty;

            try
            {
                using (GameZardContext context = new GameZardContext())
                {
                    var gameDAL = context.Videogames.FirstOrDefault(game => game.Name == name);

                    if (gameDAL != null)
                    {
                        id = gameDAL.Id;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }

            return id;
        }

        //public Boolean CheckID(String id)
        //{
        //    try
        //    {
        //        using (GamZardContext context = new GameZardContext())
        //        {
        //            var gameIDDAL = context.Videogames.FirstOrDefault(game => game.Id == id);

        //            if (gameIDDAL == null)
        //            {
        //                return true;
        //            }

        //            return false;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }

        //    return false;
        //}

        //public Boolean Connecting()
        //{
        //    try
        //    {
        //        using (GameZardContext context = new GameZardContext())
        //        {

        //            //var emulatorDAL = context.Emulators.Find("");
        //            var emulatorDAL = context.Emulators.FirstOrDefault(emu => emu.Name == "" &&
        //                                                                      emu.Console == "");

        //            if (emulatorDAL == null)
        //            {
        //                emulatorDAL = new Emulator();

        //                emulatorDAL.Name = "Test";
        //                emulatorDAL.Console = "Test";

        //                context.Emulators.Add(emulatorDAL);

        //                context.SaveChanges();

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

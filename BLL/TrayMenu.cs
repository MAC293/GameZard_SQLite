using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DAL.Models;

namespace BLL
{
    public static class TrayMenu
    {
        //private static List<String> _Games;

        public static void DisplayGames(List<String> games)
        {
            try
            {
                using (GameZardContext context = new GameZardContext())
                {
                    if (!IsEmpty())
                    {
                        var gameDAL = context.Videogames.Select((game =>
                            new { game.Name})).ToList();

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

        public static Boolean IsEmpty()
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

    }
}

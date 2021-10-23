using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SavedataGame
    {
        private String _ID;
        private String _FromPath;
        private String _ToPath;
        private String _BackUpMode;
        private String _LastSaved;
        private String _Game;

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

        public String Game
        {
            get { return _Game; }
            set { _Game = value; }
        }
    }
}

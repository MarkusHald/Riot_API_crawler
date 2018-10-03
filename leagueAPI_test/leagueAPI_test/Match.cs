using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leagueAPI_test
{
    class Match
    {
        private string _lane;
        private double _gameID;
        private int _champion;
        private string _platformID;
        private long _timestamp;
        private int _queue;
        private string _role;
        private int _season;
        private List<int> _bans;
        private List<Player> _players;

        private List<string> tempList = new List<string>();

        public string getLane { get { return _lane; } }
        public double getGameID { get { return _gameID; } }
        public int getChampion { get { return _champion; } }
        public string getRole { get { return _role; } }
        public List<int> Bans
        {
            get
            {
                return _bans;
            }

            set
            {
                _bans = value;
            }
        }
        public List<Player> Players
        {
            get
            {
                return _players;
            }

            set
            {
                _players = value;
            }
        }

        public Match(JToken token)
        {        
            foreach (var entry in token)
            {               
                tempList.Add(entry.ToString().Split(':')[1]);
            }

            _platformID = tempList[0];
            double.TryParse(tempList[1], out _gameID);
            Int32.TryParse(tempList[2], out _champion);
            Int32.TryParse(tempList[3], out _queue);
            Int32.TryParse(tempList[4], out _season);
            long.TryParse(tempList[5], out _timestamp);
            _role = tempList[6];
            _lane = tempList[7];
        }

        public override bool Equals(Object obj)
        {
            return this._gameID == (obj as Match).getGameID;
        }
    }
}

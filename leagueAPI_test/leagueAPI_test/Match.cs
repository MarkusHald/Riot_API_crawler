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
        private List<Player> _players = new List<Player>();
        private static int banIDcounter;
        private static int playerIDcounter;
        private static int playersIDcounter;

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
            _role = tempList[6].Remove(0,2);
            _role = _role.Remove(_role.Length - 1, 1);
            //_lane = tempList[7];

            _platformID = tempList[0].Remove(0, 2);
            _platformID = _platformID.Remove(_platformID.Length - 1, 1);

            _lane = tempList[7].Remove(0, 2);
            _lane = _lane.Remove(_lane.Length - 1, 1);
        }

        public override bool Equals(Object obj)
        {
            return this._gameID == (obj as Match).getGameID;
        }

        public void toSQL(Database db)
        {
            string sql = String.Format("INSERT INTO match2 VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');",
                _lane, _gameID, _champion, _platformID, _timestamp, _queue, _role, _season, banIDcounter, playerIDcounter);



            string bans = "INSERT INTO bans2 VALUES (" + banIDcounter.ToString();
            foreach (int championID in _bans)
            {
                bans += ", " + championID.ToString();
            }
            bans += ");";
            banIDcounter++;
                        
            foreach (Player player in _players)
            {
                player.toSQL(db, playerIDcounter);
                playerIDcounter++;
            }

            string playerssql = String.Format("INSERT INTO players2 VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');",
                                              playersIDcounter, _players[0].ID, _players[1].ID, _players[2].ID, _players[3].ID, _players[4].ID,
                                              _players[5].ID, _players[6].ID, _players[7].ID, _players[8].ID, _players[9].ID);
            playersIDcounter++;


            db.SQLStatement(playerssql);
            db.SQLStatement(sql);
            db.SQLStatement(bans);
        }
    }
}

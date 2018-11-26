using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leagueAPI_test
{
    class Player
    {

        private int _teamID;
        private int _champion;
        private int _summonerSpellOne;
        private int _summonerSpellTwo;
        private string _rank;
        private PlayerStats _playerStats;
        private static int _playerStatsIDcounter = 0;

        public int TeamID
        {
            get
            {
                return _teamID;
            }

            set
            {
                _teamID = value;
            }
        }
        public int Champion
        {
            get
            {
                return _champion;
            }

            set
            {
                _champion = value;
            }
        }
        public int SummonerSpellOne
        {
            get
            {
                return _summonerSpellOne;
            }

            set
            {
                _summonerSpellOne = value;
            }
        }
        public int SummonerSpellTwo
        {
            get
            {
                return _summonerSpellTwo;
            }

            set
            {
                _summonerSpellTwo = value;
            }
        }
        public string Rank
        {
            get
            {
                return _rank;
            }

            set
            {
                _rank = value;
            }
        }
        public int ID;


        public Player(int teamID, int champion, int summonerSpellOne, int summonerSpellTwo, string rank, PlayerStats playerStats)
        {
            _teamID = teamID;
            _champion = champion;
            _summonerSpellOne = summonerSpellOne;
            _summonerSpellTwo = SummonerSpellTwo;
            _rank = rank.Remove(0, 30);
            _rank = _rank.Remove(_rank.Length - 1, 1);
            _playerStats = playerStats;
        }

        public void toSQL(Database db, int id)
        {
            string sql = String.Format("INSERT INTO player2 VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');", id, _teamID, _champion, _summonerSpellOne, _summonerSpellTwo, _rank, _playerStatsIDcounter);
            ID = id;
            db.SQLStatement(sql);
            _playerStats.toSQL(db, _playerStatsIDcounter);
            _playerStatsIDcounter++;
        }


    }
}

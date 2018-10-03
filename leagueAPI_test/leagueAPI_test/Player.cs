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

        public int TeamID
        {
            get
            {
                return TeamID;
            }

            set
            {
                TeamID = value;
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


        public Player(int teamID, int champion, int summonerSpellOne, int summonerSpellTwo, string rank, PlayerStats playerStats)
        {
            _teamID = teamID;
            _champion = champion;
            _summonerSpellOne = summonerSpellOne;
            _summonerSpellTwo = SummonerSpellTwo;
            _rank = rank;
            _playerStats = playerStats;
        }

    }
}

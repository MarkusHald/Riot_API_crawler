using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leagueAPI_test
{
    class TeamStats
    {

        private int _teamID;
        private bool _win;
        private bool _firstBlood;
        private bool _firstTower;
        private bool _firstInhib;
        private bool _firstBaron;
        private bool _firstDragon;
        private bool _firstRiftHerald;
        private int _towersKilled;
        private int _inhibsKilled;
        private int _baronsKilled;
        private int _dragonsKilled;
        private List<int> _bans = new List<int>();
        private static int banIDcounter;

        public TeamStats(int teamID, bool win, bool firstblood, bool firstTower, bool firstInhib, bool firstBaron, bool firstDragon, bool firstRiftHerald, int towersKilled, int inhibsKilled, int baronsKilled, int dragonsKilled, List<int> bans)
        {
            _teamID = teamID;
            _win = win;
            _firstBlood = firstblood;
            _firstTower = firstTower;
            _firstInhib = firstInhib;
            _firstBaron = firstBaron;
            _firstDragon = firstDragon;
            _firstRiftHerald = firstRiftHerald;
            _towersKilled = towersKilled;
            _inhibsKilled = inhibsKilled;
            _baronsKilled = baronsKilled;
            _dragonsKilled = dragonsKilled;
            _bans = bans;


        }


        public void toSQL(Database db) //Needs to be updated if this class will be used
        {
            string sql = String.Format("INSERT INTO teamstats VALUES ({0}, {1}, {2}, {3}, {4}, {5} {6} {7} {8}, {9}, {10), {11}, {12});", 
                _teamID, _win, _firstBlood, _firstTower, _firstInhib, _firstBaron, _firstDragon, _firstRiftHerald, 
                _towersKilled, _inhibsKilled, _baronsKilled, _dragonsKilled, banIDcounter);


            string bans = "INSERT INTO bans VALUES (" + banIDcounter.ToString();
            foreach (int championID in _bans)
            {
                bans += ", " + championID.ToString();
            }
            bans += ");";
            banIDcounter++;

            db.SQLStatement(sql);
            db.SQLStatement(bans);

        }


    }
}

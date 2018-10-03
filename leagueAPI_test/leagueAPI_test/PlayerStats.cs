using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leagueAPI_test
{
    class PlayerStats
    {
        #region variabler
        private bool _win;
        private int _itemZero;
        private int _itemOne;
        private int _itemTwo;
        private int _itemThree;
        private int _itemFour;
        private int _itemFive;
        private int _itemSix;
        private int _kills;
        private int _deaths;
        private int _assists;
        private int _totalDamageDealt;
        private int _MagicDamageDealt;
        private int _physicalDamageDealt;
        private int _trueDamageDealt;   

        private int _totalDamageDealtToChampions;
        private int _MagicDamageDealtToChampions;
        private int _physicalDamageDealtToChampions;
        private int _trueDamageDealtToChampions;

        private int _totalHealing;
        private int _damageSelfMitigated;
        private int _damageDealtToObjectives;
        private int _DamageDealtToTurrets;
        private int _timeCCingOthers;

        private int _totalDamageTaken;
        private int _MagicDamageTaken;
        private int _physicalDamageTaken;
        private int _trueDamageTaken;
        private int _goldEarned;
        private int _goldSpent;
        private int _turretkilled;
        private int _inhibkilled;
        private int _totalMinionsKilled;
        private int _neutralMinionKilled;
        private int _neutralMinnionKilledTeamJungle;
        private int _neutralMinnionKilledEnemyJungle;
        private int _totalTimeCCdealt;
        private bool _firstblood;
        private bool _firstbloodAssist;
        private bool _firstTowerKill;
        private bool _firstTowerAssist;

        private List<double> _csPerMin = new List<double>();
        private List<double> _xpPerMin = new List<double>();
        private List<double> _goldPerMin = new List<double>();
        private List<double> _damageTakenPerMin = new List<double>();
        
        private string _role;
        private string _lane;
        #endregion

        /*#region properties
        public bool Win
        {
            get
            {
                return _win;
            }

            set
            {
                _win = value;
            }
        }

        public int ItemOne
        {
            get
            {
                return _itemOne;
            }

            set
            {
                _itemOne = value;
            }
        }

        public int ItemTwo
        {
            get
            {
                return _itemTwo;
            }

            set
            {
                _itemTwo = value;
            }
        }

        public int ItemThree
        {
            get
            {
                return _itemThree;
            }

            set
            {
                _itemThree = value;
            }
        }

        public int ItemFour
        {
            get
            {
                return _itemFour;
            }

            set
            {
                _itemFour = value;
            }
        }

        public int ItemFive
        {
            get
            {
                return _itemFive;
            }

            set
            {
                _itemFive = value;
            }
        }

        public int ItemSix
        {
            get
            {
                return _itemSix;
            }

            set
            {
                _itemSix = value;
            }
        }

        public int Kills
        {
            get
            {
                return _kills;
            }

            set
            {
                _kills = value;
            }
        }

        public int Deaths
        {
            get
            {
                return _deaths;
            }

            set
            {
                _deaths = value;
            }
        }

        public int Assists
        {
            get
            {
                return _assists;
            }

            set
            {
                _assists = value;
            }
        }

        public int TotalDamageDealt
        {
            get
            {
                return _totalDamageDealt;
            }

            set
            {
                _totalDamageDealt = value;
            }
        }

        public int MagicDamageDealt
        {
            get
            {
                return _MagicDamageDealt;
            }

            set
            {
                _MagicDamageDealt = value;
            }
        }

        public int PhysicalDamageDealt
        {
            get
            {
                return _physicalDamageDealt;
            }

            set
            {
                _physicalDamageDealt = value;
            }
        }

        public int TrueDamageDealt
        {
            get
            {
                return _trueDamageDealt;
            }

            set
            {
                _trueDamageDealt = value;
            }
        }

        public int TotalDamageDealtToChampions
        {
            get
            {
                return _totalDamageDealtToChampions;
            }

            set
            {
                _totalDamageDealtToChampions = value;
            }
        }

        public int MagicDamageDealtToChampions
        {
            get
            {
                return _MagicDamageDealtToChampions;
            }

            set
            {
                _MagicDamageDealtToChampions = value;
            }
        }

        public int PhysicalDamageDealtToChampions
        {
            get
            {
                return _physicalDamageDealtToChampions;
            }

            set
            {
                _physicalDamageDealtToChampions = value;
            }
        }

        public int TrueDamageDealtToChampions
        {
            get
            {
                return _trueDamageDealtToChampions;
            }

            set
            {
                _trueDamageDealtToChampions = value;
            }
        }

        public int TotalHealing
        {
            get
            {
                return _totalHealing;
            }

            set
            {
                _totalHealing = value;
            }
        }

        public int DamageSelfMitigated
        {
            get
            {
                return _damageSelfMitigated;
            }

            set
            {
                _damageSelfMitigated = value;
            }
        }

        public int DamageDealtToObjectives
        {
            get
            {
                return _damageDealtToObjectives;
            }

            set
            {
                _damageDealtToObjectives = value;
            }
        }

        public int DamageDealtToTurrets
        {
            get
            {
                return _DamageDealtToTurrets;
            }

            set
            {
                _DamageDealtToTurrets = value;
            }
        }

        public int TimeCCingOthers
        {
            get
            {
                return _timeCCingOthers;
            }

            set
            {
                _timeCCingOthers = value;
            }
        }

        public int TotalDamageTaken
        {
            get
            {
                return _totalDamageTaken;
            }

            set
            {
                _totalDamageTaken = value;
            }
        }

        public int MagicDamageTaken
        {
            get
            {
                return _MagicDamageTaken;
            }

            set
            {
                _MagicDamageTaken = value;
            }
        }

        public int PhysicalDamageTaken
        {
            get
            {
                return _physicalDamageTaken;
            }

            set
            {
                _physicalDamageTaken = value;
            }
        }

        public int TrueDamageTaken
        {
            get
            {
                return _trueDamageTaken;
            }

            set
            {
                _trueDamageTaken = value;
            }
        }

        public int GoldEarned
        {
            get
            {
                return _goldEarned;
            }

            set
            {
                _goldEarned = value;
            }
        }

        public int GoldSpent
        {
            get
            {
                return _goldSpent;
            }

            set
            {
                _goldSpent = value;
            }
        }

        public int Turretkilled
        {
            get
            {
                return _turretkilled;
            }

            set
            {
                _turretkilled = value;
            }
        }

        public int Inhibkilled
        {
            get
            {
                return _inhibkilled;
            }

            set
            {
                _inhibkilled = value;
            }
        }

        public int TotalMinionsKilled
        {
            get
            {
                return _totalMinionsKilled;
            }

            set
            {
                _totalMinionsKilled = value;
            }
        }

        public int NeutralMinionKilled
        {
            get
            {
                return _neutralMinionKilled;
            }

            set
            {
                _neutralMinionKilled = value;
            }
        }

        public int NeutralMinnionKilledTeamJungle
        {
            get
            {
                return _neutralMinnionKilledTeamJungle;
            }

            set
            {
                _neutralMinnionKilledTeamJungle = value;
            }
        }

        public int NeutralMinnionKilledEnemyJungle
        {
            get
            {
                return _neutralMinnionKilledEnemyJungle;
            }

            set
            {
                _neutralMinnionKilledEnemyJungle = value;
            }
        }

        public int TotalTimeCCdealt
        {
            get
            {
                return _totalTimeCCdealt;
            }

            set
            {
                _totalTimeCCdealt = value;
            }
        }

        public bool Firstblood
        {
            get
            {
                return _firstblood;
            }

            set
            {
                _firstblood = value;
            }
        }

        public bool FirstbloodAssist
        {
            get
            {
                return _firstbloodAssist;
            }

            set
            {
                _firstbloodAssist = value;
            }
        }

        public bool FirstTowerKill
        {
            get
            {
                return _firstTowerKill;
            }

            set
            {
                _firstTowerKill = value;
            }
        }

        public bool FirstTowerAssist
        {
            get
            {
                return _firstTowerAssist;
            }

            set
            {
                _firstTowerAssist = value;
            }
        }

        public List<double> CsPerMin
        {
            get
            {
                return _csPerMin;
            }

            set
            {
                _csPerMin = value;
            }
        }

        public List<double> XpPerMin
        {
            get
            {
                return _xpPerMin;
            }

            set
            {
                _xpPerMin = value;
            }
        }

        public List<double> GoldPerMin
        {
            get
            {
                return _goldPerMin;
            }

            set
            {
                _goldPerMin = value;
            }
        }

        public List<double> CsDiffPerMin
        {
            get
            {
                return _csDiffPerMin;
            }

            set
            {
                _csDiffPerMin = value;
            }
        }

        public List<double> XpDiffPerMin
        {
            get
            {
                return _xpDiffPerMin;
            }

            set
            {
                _xpDiffPerMin = value;
            }
        }

        public List<double> DamageTakenPerMin
        {
            get
            {
                return _damageTakenPerMin;
            }

            set
            {
                _damageTakenPerMin = value;
            }
        }

        public List<double> DamageTakenDiffPerMin
        {
            get
            {
                return _damageTakenDiffPerMin;
            }

            set
            {
                _damageTakenDiffPerMin = value;
            }
        }

        public string Role
        {
            get
            {
                return _role;
            }

            set
            {
                _role = value;
            }
        }

        public string Lane
        {
            get
            {
                return _lane;
            }

            set
            {
                _lane = value;
            }
        }
        #endregion
    */
        public PlayerStats(bool win, int itemZero, int itemOne, int itemTwo, int itemThree, int itemFour, int itemfive, int itemSix, int kills, int deaths, int assists, int totalDamageDealt, int magicDamageDealt,
        int physicalDamageDealt, int trueDamageDealt, int totalDamageDealtToChampions, int magicDamageDealtToChampions, int physicalDamageDealtToChampions, int trueDamageDeadToChampions,
        int totalHealing, int damageSelfMitigated, int damageDealtToObjectives, int damageDealtToTurrets, int timeCCingOthers, int totalDamageTaken, int magicDamageTaken, int physicalDamageTaken,
        int trueDamageTaken, int goldEarned, int goldSpent, int turretKilled, int inhibKilled, int totalMinionsKilled, int neutralMinionsKilled, int neutralMinnionkilledTeamJungle, int neutralMinnionKilledEnemyJungle,
        int totalTimeCCDealt, bool firstblood, bool firstbloodAssist, bool firstTowerKill, bool firstTowerAssist, string role, string lane, List<double> csPerMin, List<double> xpPerMin, List<double> goldPerMin, 
        List<double> damageTakenPerMin)
        {
            _win = win;
            _itemZero = itemZero;
            _itemOne = itemOne;
            _itemTwo = itemTwo;
            _itemThree = itemThree;
            _itemFour = itemFour;
            _itemFive = itemfive;
            _itemSix = itemSix;
            _kills = kills;
            _deaths = deaths;
            _assists = assists;
            _totalDamageDealt = totalDamageDealt;
            _MagicDamageDealt = magicDamageDealt;
            _physicalDamageDealt = physicalDamageDealt;
            _trueDamageDealt = trueDamageDealt;

            _totalDamageDealtToChampions = totalDamageDealtToChampions;
            _MagicDamageDealtToChampions = magicDamageDealtToChampions;
            _physicalDamageDealtToChampions = physicalDamageDealtToChampions;
            _trueDamageDealtToChampions = trueDamageDeadToChampions;

            _totalHealing = totalHealing;
            _damageSelfMitigated = damageSelfMitigated;
            _damageDealtToObjectives = damageDealtToObjectives;
            _DamageDealtToTurrets = damageDealtToTurrets;
            _timeCCingOthers = timeCCingOthers;

            _totalDamageTaken = totalDamageTaken;
            _MagicDamageTaken = magicDamageTaken;
            _physicalDamageTaken = physicalDamageTaken;
            _trueDamageTaken = trueDamageTaken;
            _goldEarned = goldEarned;
            _goldSpent = goldSpent;
            _turretkilled = turretKilled;
            _inhibkilled = inhibKilled;
            _totalMinionsKilled = totalMinionsKilled;
            _neutralMinionKilled = neutralMinionsKilled;
            _neutralMinnionKilledTeamJungle = neutralMinnionkilledTeamJungle;
            _neutralMinnionKilledEnemyJungle = neutralMinnionKilledEnemyJungle;
            _totalTimeCCdealt = totalTimeCCDealt;
            _firstblood = firstblood;
            _firstbloodAssist = firstbloodAssist;
            _firstTowerKill = firstTowerKill;
            _firstTowerAssist = firstTowerAssist;

            _csPerMin = csPerMin;
            _xpPerMin = xpPerMin;
            _goldPerMin = goldPerMin;
            _damageTakenPerMin = damageTakenPerMin;

            _role = role;
            _lane = lane;

        }
    }
}

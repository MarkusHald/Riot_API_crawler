using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace leagueAPI_test
{
    class crawler
    {
        //https://developer.riotgames.com/game-constants.html id'er til queues   

        static string NAurl = "https://na1.api.riotgames.com";
        static string EUurl = "https://euw1.api.riotgames.com";
        string url = "https://euw1.api.riotgames.com";
        string apiKey = "?api_key=RGAPI-d0178390-b74a-4577-b576-a77594bc1992";
        private long _currentPatchTime = 1542754800000;
        List<string> tempList = new List<string>();
        private JToken[] tempParticipantsArray = new JToken[8];
        private JToken[] tempStatsArray = new JToken[104];
        private JToken[] tempTimelineArray = new JToken [10];
        List<double> visitedAccounts = new List<double>();
        List<double> matchIDs = new List<double>();
        public Queue<double> EUqueue = new Queue<double>();
        public Queue<double> NAqueue = new Queue<double>();
        public List<Match> completedMatches = new List<Match>();
        public Database database = new Database();

        static string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    string errorText = reader.ReadToEnd();
                }
                throw;
            }
        }

        public int getAccIDFromName(string sumName, bool isEU)
        {
            if (isEU)
            {
                url = EUurl;
            }
            else
            {
                url = NAurl;
            }
            string summonerFromNameURL = url + "/lol/summoner/v3/summoners/by-name/" + sumName + apiKey;
            int accID = 0;
            Int32.TryParse(GET(summonerFromNameURL).Split(',')[1].Remove(0, 12), out accID);
                       
            return accID;
        }
                        
        public List<Match> crawlMatches(double accID, bool isEU)
        {
            if (isEU)
            {
                url = EUurl;
            }
            else
            {
                url = NAurl;
            }
            string matchHistoryURL = url + "/lol/match/v3/matchlists/by-account/" + accID + apiKey + "&queue=420&season=11&beginTime=" + _currentPatchTime;
            string jsonObj = GET(matchHistoryURL);
            
            JObject jObject = JObject.Parse(jsonObj);
            JToken jMatches = jObject["matches"];
            
            List <Match> mList = new List<Match>();
            foreach (var item in jMatches)
            {
                if (!matchIDs.Contains(Convert.ToDouble((item.ElementAt(1).First()))))
                {
                    mList.Add(new Match(item));
                    matchIDs.Add(mList.Last().getGameID);
                }       
            }          
            return mList;
        }

        public void crawlMatchTimeline(Match m, bool isEU)
        {
            if (isEU)
            {
                url = EUurl;
            }
            else
            {
                url = NAurl;
            }
            string matchTimelineURL = url + "/lol/match/v3/matches/" + m.getGameID + apiKey;
            string jsonObj = GET(matchTimelineURL);
            List<Player> players = new List<Player>();
            
            JObject jObject = JObject.Parse(jsonObj);

            JToken jParticipants = jObject["participants"];
            JToken jStats = jObject["stats"];
            JToken jTimeline = jObject["timeline"];

            foreach (var participant in jParticipants)
            {                
                int t = 0;
                int s = 0;
                int h = 0;
                List<double> a1 = new List<double>();
                List<double> a2 = new List<double>();
                List<double> a3 = new List<double>();
                List<double> a4 = new List<double>();


                foreach (var entry in participant)
                {                
                    tempParticipantsArray[t] = entry;
                    t++;
                }
  
                JToken stats = JObject.Parse(tempParticipantsArray[6].First().ToString());
  
                foreach (var entry in stats)
                {
                    tempStatsArray[s] = entry;
                    s++;
                }

                JToken timeline = JObject.Parse(tempParticipantsArray[7].First().ToString());
                
                foreach (var entry in timeline)
                {
                    tempTimelineArray[h] = entry;
                    h++;
                }
                string role = tempTimelineArray[5].ToString();
                string lane = tempTimelineArray[6].ToString();
        
                JToken creepsPerMinDeltas = JObject.Parse(tempTimelineArray[1].First().ToString());
                foreach (var item in creepsPerMinDeltas)
                {
                    a1.Add(Convert.ToDouble(item.First()));
                }

                JToken xpPerMinDeltas = JObject.Parse(tempTimelineArray[2].First().ToString());
                foreach (var item in xpPerMinDeltas)
                {
                    a2.Add(Convert.ToDouble(item.First()));
                }

                JToken goldPerMinDeltas = JObject.Parse(tempTimelineArray[3].First().ToString());
                foreach (var item in goldPerMinDeltas)
                {
                    a3.Add(Convert.ToDouble(item.First()));
                }

                JToken damageTakenPerMinDeltas = JObject.Parse(tempTimelineArray[4].First().ToString());
                foreach (var item in damageTakenPerMinDeltas)
                {
                    a4.Add(Convert.ToDouble(item.First()));
                }

                PlayerStats ps = new PlayerStats(Convert.ToBoolean(tempStatsArray[1].First()), Convert.ToInt32(tempStatsArray[2].First()), Convert.ToInt32(tempStatsArray[3].First()), Convert.ToInt32(tempStatsArray[4].First()), 
                    Convert.ToInt32(tempStatsArray[5].First()), Convert.ToInt32(tempStatsArray[6].First()), Convert.ToInt32(tempStatsArray[7].First()), Convert.ToInt32(tempStatsArray[8].First()), 
                    Convert.ToInt32(tempStatsArray[9].First()), Convert.ToInt32(tempStatsArray[10].First()), Convert.ToInt32(tempStatsArray[11].First()), Convert.ToInt32(tempStatsArray[21].First()), 
                    Convert.ToInt32(tempStatsArray[22].First()), Convert.ToInt32(tempStatsArray[23].First()), Convert.ToInt32(tempStatsArray[24].First()), Convert.ToInt32(tempStatsArray[26].First()), 
                    Convert.ToInt32(tempStatsArray[27].First()), Convert.ToInt32(tempStatsArray[28].First()), Convert.ToInt32(tempStatsArray[29].First()), Convert.ToInt32(tempStatsArray[30].First()),
                    Convert.ToInt32(tempStatsArray[32].First()), Convert.ToInt32(tempStatsArray[33].First()), Convert.ToInt32(tempStatsArray[34].First()), Convert.ToInt32(tempStatsArray[36].First()), 
                    Convert.ToInt32(tempStatsArray[37].First()), Convert.ToInt32(tempStatsArray[38].First()), Convert.ToInt32(tempStatsArray[39].First()), Convert.ToInt32(tempStatsArray[40].First()), 
                    Convert.ToInt32(tempStatsArray[41].First()), Convert.ToInt32(tempStatsArray[42].First()), Convert.ToInt32(tempStatsArray[43].First()), Convert.ToInt32(tempStatsArray[44].First()), 
                    Convert.ToInt32(tempStatsArray[45].First()), Convert.ToInt32(tempStatsArray[46].First()), Convert.ToInt32(tempStatsArray[47].First()), Convert.ToInt32(tempStatsArray[48].First()), 
                    Convert.ToInt32(tempStatsArray[49].First()), Convert.ToBoolean(tempStatsArray[55].First()), Convert.ToBoolean(tempStatsArray[56].First()), Convert.ToBoolean(tempStatsArray[57].First()),
                    Convert.ToBoolean(tempStatsArray[58].First()), role, lane, a1, a2, a3, a4);

                Player p = new Player(Convert.ToInt32(tempParticipantsArray[1].First()), Convert.ToInt32(tempParticipantsArray[2].First()), Convert.ToInt32(tempParticipantsArray[3].First()), Convert.ToInt32(tempParticipantsArray[4].First()), tempParticipantsArray[5].ToString(), ps);
                
                players.Add(p);
            }

            List<int> banList = new List<int>();

            JToken jTeam = jObject["teams"];

            foreach (var entry in jTeam)
            {
                foreach (var item in entry.Last().First())
                {
                    banList.Add(Convert.ToInt32(item.First().First()));
                }
            }

            m.Bans = banList;
            m.Players = players;
            completedMatches.Add(m);
            m.toSQL(database);

            JToken jparticipantIdentities = jObject["participantIdentities"];
            
            foreach (var entry in jparticipantIdentities)
            {
                double accID = Convert.ToDouble(entry.Last().First().ElementAt(1).First());
                string platformID = entry.Last().First().First().First().ToString();

                if (!visitedAccounts.Contains(accID) && platformID == "EUW1")
                {
                    visitedAccounts.Add(accID);
                    EUqueue.Enqueue(accID);
                }
                else if (!visitedAccounts.Contains(accID) && platformID == "NA1")
                {
                    visitedAccounts.Add(accID);
                    NAqueue.Enqueue(accID);
                }
            }
        }

        public void crawl(double EUAccID, double NAAccID)
        {
            List<Match> EUmatches = new List<Match>();
            List<Match> NAmatches = new List<Match>();

            EUmatches = crawlMatches(EUAccID, true);
            NAmatches = crawlMatches(NAAccID, false);

            int EU = EUmatches.Count;
            int NA = NAmatches.Count;
            int max = 0;

            if(EU < NA)
            {
                max = NA;
            }
            else
            {
                max = EU;
            }

            for (int i = 0; i < max; i++)
            {
                if (EU < i)
                {
                    crawlMatchTimeline(EUmatches[i], true);
                }
                if (NA < i)
                {
                    crawlMatchTimeline(NAmatches[i], false);
                }
                System.Threading.Thread.Sleep(1300);
            }



            /*
            foreach (var match in matches)
            {
                crawlMatchTimeline(match, isEU);
                System.Threading.Thread.Sleep(1300);
            }
            */
        }
    }
}

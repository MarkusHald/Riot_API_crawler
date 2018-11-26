using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json.Linq;
using Npgsql;
using System.Data;
using System.Threading;

namespace leagueAPI_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            //db.fixplayers();

            //db.fixchamps();

            //db.fixchampidPlayer();






            /*
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM player LIMIT 20", db.conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            Console.WriteLine();





            













            /*db.SQLStatement("CREATE TABLE champions(" +
                "name text," +
                "id integer," +
                "corrected_id integer," +
                "tags text," +
                "path_to_img text);");
                */
            /*
        Newtonsoft.Json.Linq.JObject champs;
        List<champion> champions = new List<champion>();
        using (StreamReader r = new StreamReader("C:/Users/M0107/Desktop/champion.json"))
        {
            string json = r.ReadToEnd();
            //List<champion> 
            champs = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(json);
        }

        foreach (var item in champs.Last.First)
        {
            JToken jt = item.First["tags"];

            List<string> te = new List<string>();

            foreach (var tok in jt)
            {
                te.Add(tok.ToString());
            }


            champions.Add(new champion(item.First["id"].ToString(), Convert.ToInt32(item.First["key"].ToString()), te));
        }

        champions.Add(new champion("Kayn", 141, new List<string>{"Assassin", "Skirmisher"}));
        champions.Add(new champion("Kai'sa", 145, new List<string> { "Marksman" }));
        champions.Add(new champion("Xayah", 498, new List<string> { "Marksman" }));
        champions.Add(new champion("Pyke", 555, new List<string> { "Assassin", "Support" }));
        champions.Add(new champion("Zoe", 142, new List<string> { "Mage", "Assassin" }));
        champions.Add(new champion("Ornn", 526, new List<string> { "Tank" }));
        champions.Add(new champion("Rakan", 497, new List<string> { "Support" }));


        champion ww = new champion("Kaisa", 145, new List<string> { "Marksman" });
        ww.toSQL(db);*/


            /*

            List<object> champs = new List<object>();
            using (StreamReader r = new StreamReader("C:/Users/M0107/Desktop/champion.json"))
            {
                using (Newtonsoft.Json.JsonReader jr = new Newtonsoft.Json.JsonTextReader(r))
                {
                    while (jr.Read())
                    {
                        champs.Add(jr.Path);
                    }
                    Console.WriteLine();
                }
                //string json = r.ReadToEnd();
                //JObject json = new JObject();



            }



                //db.ClearTables();
                //db.closeConnection();
            */
            List<Match> m = new List<Match>();

            crawler c = new crawler();
            double euaccid = c.getAccIDFromName("DrDragmaciek", true);
            double naaccid = c.getAccIDFromName("Zedtime Story", false);

            m = (c.crawlMatches(euaccid, true));
            foreach (Match match in m)
            {
                c.crawlMatchTimeline(match, true);
                System.Threading.Thread.Sleep(1300);
            }
            m = (c.crawlMatches(naaccid, false));
            foreach (Match match in m)
            {
                c.crawlMatchTimeline(match, false);
                System.Threading.Thread.Sleep(1300);
            }

            while (c.completedMatches.Count < 10)
            {
                try
                {
                    c.crawl(euaccid, naaccid);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(c.completedMatches.Count());
            /*
            c.database.closeConnection();
            
            Database database = new Database();
            string sql = "CREATE TABLE player("+
                            "playerID integer PRIMARY KEY,"+
                            "teamid integer,"+
                            "champion integer,"+
                            "summonerspell1 integer,"+
                            "summonerspell2 integer,"+
                            "rank text);";
            //PlayerStats aaa = new PlayerStats(true, 0, 1, 2, 3, 4, 5, 6, 22, 33, 44, 1000, 2121, 3131, 1111, 321, 234, 432, 123, 3200, 10, 20000, 3213, 3, 3133, 123, 3321, 323, 12000, 10020, 3, 1, 2, 1, 1, 0, 3, true, true, false, false, "adc", "bot", new List<double>(), new List<double>(), new List<double>(), new List<double>());

            //aaa.toSQL(database, 1);
            */
            //Database database = new Database();
            //database.ClearTables();
            //database.CreateTables();

            //database.SQLStatement(sql);

            //database.closeConnection();
            db.closeConnection();

            Console.WriteLine(2);
            Console.ReadLine();
        }        
    }
}

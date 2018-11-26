using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Npgsql;

namespace leagueAPI_test
{
    class Database
    {
        private string _username = "sw703";
        private string _password = "sw703aoe";
        private string _host = "sw703db.cgukp5oibqte.eu-central-1.rds.amazonaws.com";
        private string _port = "5432";
        private string _dbName = "SW703DB";
        public NpgsqlConnection conn;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        public Database()
        {
            conn = CreateConnection();
        }

        public void closeConnection()
        {
            conn.Close();
        }

        public void fixplayers()
        {

            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT playersid, banid FROM match limit 20", conn);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.SQLStatement("UPDATE match SET playersid = banid WHERE playersid = banid*10");
                }


                //Console.WriteLine(dt.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            /*

            using (var cmd = new NpgsqlCommand("SELECT playersid FROM match", conn))
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    this.SQLStatement("UPDATE match SET playersid = playersid/10 WHERE ");
                }*/
        }

        public void fixchamps()
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT corrected_id, damage, toughness, difficulty, utility, control, mobility FROM champions", conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            //Aatrox - 0
            //this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 0");
            //this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 0");
            //this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 0");
            //this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 0");
            //this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 0");
            //this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 0");
            //Ahri - 1
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 1");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 1");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 1");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 1");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 1");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 1");

            //Akali - 2
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 2");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 2");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 2");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 2");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 2");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 2");

            //Alistar - 3
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 3");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 3");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 3");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 3");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 3");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 3");

            //Amumu - 4
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 4");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 4");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 4");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 4");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 4");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 4");

            //Anivia - 5
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 5");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 5");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 5");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 5");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 5");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 5");

            //Annie - 6
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 6");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 6");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 6");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 6");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 6");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 6");

            //Ashe - 7
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 7");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 7");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 7");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 7");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 7");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 7");

            //AurelionSol - 8
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 8");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 8");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 8");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 8");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 8");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 8");

            //Azir - 9
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 9");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 9");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 9");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 9");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 9");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 9");

            //Bard - 10
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 10");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 10");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 10");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 10");
            this.SQLStatement("UPDATE champions SET utility = 3 WHERE corrected_id = 10");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 10");

            //Blitzcrank - 11
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 11");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 11");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 11");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 11");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 11");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 11");

            //Brand - 12
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 12");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 12");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 12");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 12");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 12");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 12");

            //Braum - 13
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 13");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 13");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 13");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 13");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 13");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 13");

            //Caitlyn - 14
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 14");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 14");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 14");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 14");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 14");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 14");

            //Camile - 15
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 15");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 15");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 15");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 15");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 15");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 15");

            //Casseiopeia - 16
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 16");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 16");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 16");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 16");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 16");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 16");

            //Chogath - 17
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 17");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 17");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 17");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 17");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 17");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 17");

            //Corki - 18
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 18");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 18");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 18");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 18");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 18");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 18");

            //Darius - 19
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 19");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 19");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 19");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 19");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 19");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 19");

            //Diana - 20
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 20");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 20");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 20");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 20");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 20");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 20");

            //Draven - 21
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 21");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 21");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 21");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 21");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 21");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 21");

            //DrMundo - 22
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 22");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 22");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 22");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 22");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 22");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 22");

            //Ekko - 23
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 23");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 23");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 23");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 23");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 23");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 23");

            //Elise - 24
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 24");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 24");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 24");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 24");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 24");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 24");

            //Evelynn - 25
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 25");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 25");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 25");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 25");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 25");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 25");

            //Ezreal - 26
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 26");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 26");
            this.SQLStatement("UPDATE champions SET control = 0 WHERE corrected_id = 26");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 26");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 26");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 26");

            //Fiddlesticks - 27
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 27");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 27");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 27");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 27");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 27");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 27");

            //Fiora - 28
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 28");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 28");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 28");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 28");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 28");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 28");

            //Fizz - 29
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 29");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 29");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 29");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 29");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 29");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 29");

            //Galio - 30
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 30");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 30");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 30");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 30");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 30");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 30");

            //Gangplank - 31
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 31");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 31");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 31");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 31");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 31");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 31");

            //Garen - 32
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 32");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 32");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 32");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 32");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 32");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 32");

            //Gnar - 33
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 33");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 33");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 33");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 33");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 33");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 33");

            //Gragas - 34
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 34");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 34");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 34");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 34");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 34");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 34");

            //Graves - 35
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 35");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 35");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 35");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 35");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 35");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 35");

            //Hecarim - 36
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 36");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 36");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 36");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 36");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 36");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 36");

            //Heimerdinger - 37
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 37");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 37");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 37");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 37");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 37");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 37");

            //Illaoi - 38
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 38");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 38");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 38");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 38");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 38");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 38");

            //Irelia - 39
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 39");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 39");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 39");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 39");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 39");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 39");

            //Ivern - 40
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 40");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 40");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 40");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 40");
            this.SQLStatement("UPDATE champions SET utility = 3 WHERE corrected_id = 40");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 40");

            //Janna - 41
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 41");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 41");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 41");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 41");
            this.SQLStatement("UPDATE champions SET utility = 3 WHERE corrected_id = 41");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 41");

            //JarvanIV - 42
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 42");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 42");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 42");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 42");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 42");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 42");

            //Jax - 43
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 43");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 43");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 43");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 43");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 43");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 43");

            //Jayce - 44
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 44");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 44");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 44");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 44");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 44");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 44");

            //Jhin - 45
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 45");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 45");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 45");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 45");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 45");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 45");

            //Jinx - 46
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 46");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 46");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 46");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 46");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 46");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 46");

            //Kalista - 47
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 47");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 47");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 47");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 47");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 47");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 47");

            //Karma - 48
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 48");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 48");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 48");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 48");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 48");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 48");

            //Karthus - 49
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 49");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 49");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 49");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 49");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 49");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 49");

            //Kassadin - 50
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 50");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 50");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 50");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 50");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 50");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 50");

            //Katarina - 51
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 51");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 51");
            this.SQLStatement("UPDATE champions SET control = 0 WHERE corrected_id = 51");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 51");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 51");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 51");

            //Kayle - 52
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 52");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 52");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 52");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 52");
            this.SQLStatement("UPDATE champions SET utility = 3 WHERE corrected_id = 52");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 52");

            //Kennen - 53
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 53");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 53");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 53");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 53");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 53");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 53");

            //Khazix - 54
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 54");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 54");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 54");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 54");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 54");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 54");

            //Kindred - 55
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 55");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 55");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 55");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 55");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 55");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 55");

            //Kled - 56
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 56");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 56");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 56");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 56");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 56");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 56");

            //Kogmaw - 57
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 57");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 57");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 57");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 57");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 57");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 57");

            //leblanc - 58
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 58");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 58");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 58");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 58");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 58");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 58");

            //LeeSin - 59
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 59");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 59");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 59");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 59");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 59");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 59");

            //Leona - 60
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 60");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 60");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 60");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 60");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 60");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 60");

            //Lissandra - 61
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 61");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 61");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 61");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 61");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 61");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 61");

            //Lucian - 62
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 62");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 62");
            this.SQLStatement("UPDATE champions SET control = 0 WHERE corrected_id = 62");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 62");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 62");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 62");

            //Lulu - 63
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 63");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 63");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 63");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 63");
            this.SQLStatement("UPDATE champions SET utility = 3 WHERE corrected_id = 63");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 63");

            //Lux - 64
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 64");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 64");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 64");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 64");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 64");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 64");

            //Malphite - 65
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 65");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 65");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 65");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 65");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 65");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 65");

            //Malzahar - 66
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 66");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 66");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 66");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 66");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 66");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 66");

            //Maokai - 67
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 67");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 67");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 67");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 67");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 67");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 67");

            //MasterYi - 68
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 68");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 68");
            this.SQLStatement("UPDATE champions SET control = 0 WHERE corrected_id = 68");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 68");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 68");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 68");

            //MissFortune - 69
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 69");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 69");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 69");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 69");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 69");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 69");

            //MonkeyKing (Wukong)- 70
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 70");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 70");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 70");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 70");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 70");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 70");

            //Mordekaiser - 71
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 71");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 71");
            this.SQLStatement("UPDATE champions SET control = 0 WHERE corrected_id = 71");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 71");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 71");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 71");

            //Morgana - 72
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 72");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 72");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 72");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 72");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 72");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 72");

            //Nami - 73
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 73");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 73");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 73");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 73");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 73");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 73");

            //Nasus - 74
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 74");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 74");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 74");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 74");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 74");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 74");

            //Nautilus - 75
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 75");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 75");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 75");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 75");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 75");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 75");

            //Nidalee - 76
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 76");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 76");
            this.SQLStatement("UPDATE champions SET control = 0 WHERE corrected_id = 76");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 76");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 76");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 76");

            //Nocturne - 77
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 77");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 77");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 77");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 77");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 77");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 77");

            //Nunu - 78
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 78");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 78");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 78");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 78");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 78");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 78");

            //Olaf - 79
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 79");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 79");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 79");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 79");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 79");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 79");

            //Orianna - 80
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 80");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 80");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 80");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 80");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 80");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 80");

            //Pantheon - 81
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 81");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 81");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 81");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 81");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 81");
            this.SQLStatement("UPDATE champions SET difficulty = 0 WHERE corrected_id = 81");

            //Poppy - 82
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 82");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 82");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 82");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 82");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 82");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 82");

            //Quinn 83
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 83");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 83");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 83");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 83");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 83");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 83");

            //Rammus - 84
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 84");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 84");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 84");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 84");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 84");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 84");

            //RekSai - 85
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 85");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 85");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 85");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 85");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 85");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 85");

            //Renekton - 86
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 86");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 86");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 86");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 86");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 86");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 86");

            //Rengar - 87
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 87");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 87");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 87");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 87");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 87");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 87");

            //Riven - 88
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 88");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 88");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 88");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 88");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 88");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 88");

            //Rumble - 89
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 89");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 89");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 89");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 89");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 89");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 89");

            //Ryze - 90
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 90");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 90");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 90");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 90");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 90");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 90");

            //Sejuani - 91
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 91");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 91");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 91");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 91");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 91");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 91");

            //Shaco - 92
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 92");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 92");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 92");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 92");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 92");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 92");

            //Shen - 93
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 93");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 93");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 93");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 93");
            this.SQLStatement("UPDATE champions SET utility = 3 WHERE corrected_id = 93");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 93");

            //Shyvanna - 94
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 94");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 94");
            this.SQLStatement("UPDATE champions SET control = 0 WHERE corrected_id = 94");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 94");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 94");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 94");

            //Singed - 95
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 95");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 95");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 95");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 95");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 95");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 95");

            //Sion - 96
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 96");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 96");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 96");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 96");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 96");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 96");

            //Sivir - 97
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 97");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 97");
            this.SQLStatement("UPDATE champions SET control = 0 WHERE corrected_id = 97");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 97");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 97");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 97");

            //Skarner - 98
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 98");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 98");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 98");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 98");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 98");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 98");

            //Sona - 99
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 99");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 99");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 99");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 99");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 99");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 99");

            //Soraka - 100
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 100");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 100");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 100");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 100");
            this.SQLStatement("UPDATE champions SET utility = 3 WHERE corrected_id = 100");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 100");

            //Swain - 101
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 101");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 101");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 101");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 101");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 101");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 101");

            //Syndra - 102
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 102");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 102");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 102");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 102");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 102");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 102");

            //TahmKench - 103
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 103");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 103");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 103");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 103");
            this.SQLStatement("UPDATE champions SET utility = 3 WHERE corrected_id = 103");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 103");

            //Taliyah - 104
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 104");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 104");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 104");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 104");
            this.SQLStatement("UPDATE champions SET utility = 3 WHERE corrected_id = 104");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 104");

            //Talon - 105
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 105");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 105");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 105");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 105");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 105");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 105");

            //Taric - 106
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 106");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 106");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 106");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 106");
            this.SQLStatement("UPDATE champions SET utility = 3 WHERE corrected_id = 106");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 106");

            //Teemo - 107
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 107");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 107");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 107");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 107");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 107");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 107");

            //Thresh - 108
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 108");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 108");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 108");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 108");
            this.SQLStatement("UPDATE champions SET utility = 3 WHERE corrected_id = 108");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 108");

            //Tristana - 109
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 109");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 109");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 109");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 109");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 109");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 109");

            //Trundle - 110
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 110");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 110");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 110");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 110");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 110");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 110");

            //Tryndamere - 111
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 111");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 111");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 111");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 111");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 111");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 111");

            //Twisted fate - 112
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 112");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 112");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 112");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 112");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 112");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 112");

            //Twitch - 113
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 113");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 113");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 113");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 113");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 113");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 113");

            //Udyr - 114
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 114");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 114");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 114");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 114");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 114");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 114");

            //Urgot - 115
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 115");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 115");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 115");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 115");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 115");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 115");

            //Varus - 116
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 116");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 116");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 116");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 116");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 116");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 116");

            //Vayne - 117
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 117");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 117");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 117");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 117");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 117");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 117");

            //Veigar - 118
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 118");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 118");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 118");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 118");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 118");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 118");

            //Velkoz - 119
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 119");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 119");
            this.SQLStatement("UPDATE champions SET control = 0 WHERE corrected_id = 119");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 119");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 119");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 119");

            //Vi - 120
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 120");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 120");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 120");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 120");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 120");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 120");

            //Viktor - 121
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 121");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 121");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 121");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 121");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 121");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 121");

            //Vladimir - 122
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 122");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 122");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 122");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 122");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 122");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 122");

            //Volibear - 123
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 123");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 123");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 123");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 123");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 123");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 123");

            //Warwick - 124
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 124");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 124");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 124");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 124");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 124");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 124");

            //Xerath - 125
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 125");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 125");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 125");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 125");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 125");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 125");

            //XinZhao - 126
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 126");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 126");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 126");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 126");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 126");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 126");

            //Yasuo - 127
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 127");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 127");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 127");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 127");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 127");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 127");

            //Yorick - 128
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 128");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 128");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 128");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 128");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 128");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 128");

            //Zac - 129
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 129");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 129");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 129");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 129");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 129");
            this.SQLStatement("UPDATE champions SET difficulty = 1 WHERE corrected_id = 129");

            //Zed - 130
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 130");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 130");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 130");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 130");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 130");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 130");

            //Ziggs - 131
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 131");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 131");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 131");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 131");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 131");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 131");

            //Zilean - 132
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 132");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 132");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 132");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 132");
            this.SQLStatement("UPDATE champions SET utility = 3 WHERE corrected_id = 132");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 132");

            //Zyra - 133
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 133");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 133");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 133");
            this.SQLStatement("UPDATE champions SET mobility = 0 WHERE corrected_id = 133");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 133");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 133");

            //Kayn - 134
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 134");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 134");
            this.SQLStatement("UPDATE champions SET control = 1 WHERE corrected_id = 134");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 134");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 134");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 134");

            //Kaisa - 135
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 135");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 135");
            this.SQLStatement("UPDATE champions SET control = 0 WHERE corrected_id = 135");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 135");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 135");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 135");

            //Xayah - 136
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 136");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 136");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 136");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 136");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 136");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 136");

            //Pyke - 137
            this.SQLStatement("UPDATE champions SET damage = 2 WHERE corrected_id = 137");
            this.SQLStatement("UPDATE champions SET toughness = 0 WHERE corrected_id = 137");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 137");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 137");
            this.SQLStatement("UPDATE champions SET utility = 0 WHERE corrected_id = 137");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 137");

            //Zoe - 138
            this.SQLStatement("UPDATE champions SET damage = 3 WHERE corrected_id = 138");
            this.SQLStatement("UPDATE champions SET toughness = 1 WHERE corrected_id = 138");
            this.SQLStatement("UPDATE champions SET control = 2 WHERE corrected_id = 138");
            this.SQLStatement("UPDATE champions SET mobility = 2 WHERE corrected_id = 138");
            this.SQLStatement("UPDATE champions SET utility = 1 WHERE corrected_id = 138");
            this.SQLStatement("UPDATE champions SET difficulty = 3 WHERE corrected_id = 138");

            //Ornn - 139
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 139");
            this.SQLStatement("UPDATE champions SET toughness = 3 WHERE corrected_id = 139");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 139");
            this.SQLStatement("UPDATE champions SET mobility = 1 WHERE corrected_id = 139");
            this.SQLStatement("UPDATE champions SET utility = 2 WHERE corrected_id = 139");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 139");

            //Rakan - 140
            this.SQLStatement("UPDATE champions SET damage = 1 WHERE corrected_id = 140");
            this.SQLStatement("UPDATE champions SET toughness = 2 WHERE corrected_id = 140");
            this.SQLStatement("UPDATE champions SET control = 3 WHERE corrected_id = 140");
            this.SQLStatement("UPDATE champions SET mobility = 3 WHERE corrected_id = 140");
            this.SQLStatement("UPDATE champions SET utility = 3 WHERE corrected_id = 140");
            this.SQLStatement("UPDATE champions SET difficulty = 2 WHERE corrected_id = 140");
            




        }

        public void fixchampidPlayer()
        {

            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT player.champion, champions.id, champions.corrected_id FROM player, champions WHERE player.champion = champions.id LIMIT 20", conn);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.SQLStatement("UPDATE player SET corrected_id = 135 WHERE corrected_id = 141");
                    Console.WriteLine("l");
                    this.SQLStatement("UPDATE champions SET corrected_id = 135 WHERE corrected_id = 141");
                    Console.WriteLine("k");
                }


                //Console.WriteLine(dt.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

            public NpgsqlConnection CreateConnection ()
        {
            string connectionstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    _host, _port, _username,
                    _password, _dbName);
            //"Server=" + _host + ";Port=" + _port + ";User Id=" + _username + ";Password=" + _password + ";Database=" + _dbName + ";";

            NpgsqlConnection conn = new NpgsqlConnection(connectionstring);

            return conn;
        }
                
        public void SQLStatement(string SQLMessage)
        {
            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(SQLMessage, conn);
                ds.Reset();
                da.Fill(ds);
                //dt = ds.Tables[0];
                //Console.WriteLine(dt);

                //Console.WriteLine("www");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ClearTables()
        {
            SQLStatement("DELETE FROM bans");
            SQLStatement("DELETE FROM cspermin");
            SQLStatement("DELETE FROM damagetakenpermin");
            SQLStatement("DELETE FROM goldpermin");
            SQLStatement("DELETE FROM match");
            SQLStatement("DELETE FROM player");
            SQLStatement("DELETE FROM players");
            SQLStatement("DELETE FROM playerstats");
            SQLStatement("DELETE FROM xppermin");

        }

        public void CreateTables()
        {
            List<string> tables = new List<string>();
            string match = "CREATE TABLE match("+
                           "lane text,"+
                           "gameID bigint,"+
                           "champion integer,"+
                           "platformID text,"+
                           "timestamp bigint,"+
                           "queue integer,"+
                           "role text,"+
                           "season integer,"+
                           "banid integer,"+
                           "playersid integer);";
            tables.Add(match);

            string players = "CREATE TABLE players("+
                             "playersid integer,"+
                             "player1 integer,"+
                             "player2 integer,"+
                             "player3 integer,"+
                             "player4 integer,"+
                             "player5 integer,"+
                             "player6 integer,"+
                             "player7 integer,"+
                             "player8 integer,"+
                             "player9 integer,"+
                             "player10 integer)";
            tables.Add(players);

            string playerstats = "CREATE TABLE playerstats("+
                                 "playerstatsID integer,"+
                                 "win boolean,"+
                                 "itemzero integer,"+
                                 "itemone integer,"+
                                 "itemtwo integer,"+
                                 "itemthree integer,"+
                                 "itemfour integer,"+
                                 "itemfive integer,"+
                                 "itemsix integer,"+
                                 "kills integer,"+
                                 "deaths integer,"+
                                 "assists integer,"+
                                 "totalDamageDealt integer,"+
                                 "magicDamageDealt integer,"+
                                 "physicalDamageDealt integer,"+
                                 "trueDamageDealt integer,"+
                                 "totalDamageDealtToChampions integer,"+
                                 "magicDamageDealtToChampions integer,"+
                                 "physicalDamageDealtToChampions integer,"+
                                 "trueDamageDealtToChampion integer,"+
                                 "totalHealing integer,"+
                                 "damageSelfMitigated integer,"+
                                 "damageDealtToObjectives integer,"+
                                 "damageDealtToTurrets integer,"+
                                 "timeCCingOthers integer,"+
                                 "totalDamageTaken integer,"+
                                 "magicDamageTaken integer,"+
                                 "physicalDamageTaken integer,"+
                                 "trueDamageTaken integer,"+
                                 "goldEarned integer,"+
                                 "goldSpent integer,"+
                                 "turretkilled integer,"+
                                 "inhibkilled integer,"+
                                 "totalMinionsKilled integer,"+
                                 "neutralMinionKilled integer,"+
                                 "neutralMinnionKilledTeamJungle integer,"+
                                 "neutralMinnionKilledEnemyJungle integer,"+
                                 "totalTimeCCdealt integer,"+
                                 "firstblood boolean,"+
                                 "firstbloodAssist boolean,"+
                                 "firstTower boolean,"+
                                 "firstTowerAssist boolean,"+
                                 "csPerMinId integer,"+
                                 "xpPerMinId integer,"+
                                 "goldPerMinId integer,"+
                                 "damageTakenPerMinId integer,"+
                                 "role text,"+
                                 "lane text);";
            tables.Add(playerstats);

            string player = "CREATE TABLE player("+
                            "playerID integer,"+
                            "teamid integer,"+
                            "champion integer,"+
                            "summonerspell1 integer,"+
                            "summonerspell2 integer,"+
                            "rank text);" +
                            "playerStatsID integer";

            tables.Add(player);

            /*
            string teamstats = "CREATE TABLE teamstats("+
                               "teamid integer,"+
                               "win boolean,"+
                               "firstblood boolean,"+
                               "firstTower boolean,"+
                               "firstInhib boolean,"+
                               "firstBaron boolean,"+
                               "firstDragon boolean,"+
                               "firstRiftHerald boolean,"+
                               "towerskilled integer,"+
                               "inhibskilled integer,"+
                               "baronskilled integer,"+
                               "dragonskilled integer,"+
                               "banid integer);";
            tables.Add(teamstats);
            */

            string bans = "CREATE TABLE bans("+
                          "banid integer,"+
                          "ban1 integer,"+
                          "ban2 integer,"+
                          "ban3 integer,"+
                          "ban4 integer,"+
                          "ban5 integer,"+
                          "ban6 integer,"+
                          "ban7 integer,"+
                          "ban8 integer,"+
                          "ban9 integer,"+
                          "ban10 integer)";
            tables.Add(bans);

            string cspermin = "CREATE TABLE csPerMin(" +
                              "csPerMinId integer," +
                              "zeroToTen decimal," +
                              "tentotwenty decimal," +
                              "twentytothirty decimal," +
                              "thirtytoforty decimal,"+
                              "fortytofifty decimal,"+
                              "fiftytosixty decimal," +
                              "sixtytoseventy decimal," +
                              "seventytoeightty decimal," +
                              "eightytoninety decimal)";
            tables.Add(cspermin);

            string xppermin = "CREATE TABLE xpPerMin("+
                              "xpPerMinId integer,"+
                              "zeroToTen decimal," +
                              "tentotwenty decimal," +
                              "twentytothirty decimal," +
                              "thirtytoforty decimal," +
                              "fortytofifty decimal," +
                              "fiftytosixty decimal," +
                              "sixtytoseventy decimal," +
                              "seventytoeightty decimal," +
                              "eightytoninety decimal)";
            tables.Add(xppermin);

            string goldpermin = "CREATE TABLE goldPerMin("+
                                "goldPerMinId integer,"+
                                "zeroToTen decimal," +
                                "tentotwenty decimal," +
                                "twentytothirty decimal," +
                                "thirtytoforty decimal," +
                                "fortytofifty decimal," +
                                "fiftytosixty decimal," +
                                "sixtytoseventy decimal," +
                                "seventytoeightty decimal," +
                                "eightytoninety decimal)";
            tables.Add(goldpermin);

            string damagetakenpermin = "CREATE TABLE damageTakenPerMin(" +
                                       "damageTakenPerMinId integer," +
                                       "zeroToTen decimal," +
                                       "tentotwenty decimal," +
                                       "twentytothirty decimal," +
                                       "thirtytoforty decimal," +
                                       "fortytofifty decimal," +
                                       "fiftytosixty decimal," +
                                       "sixtytoseventy decimal," +
                                       "seventytoeightty decimal," +
                                       "eightytoninety decimal)";
            tables.Add(damagetakenpermin);

            foreach (string table in tables)
            {
                SQLStatement(table);
            }
            closeConnection();
        }


        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leagueAPI_test
{
    class champion
    {
        private static int counter = 0;
        public champion()
        {

        }
        public champion(string name, int Key, List<string> Tags)
        {
            id = name;
            key = Key;
            tags = Tags;
            corrected_id = counter++;
        }

        public string id;
        public int key;
        public int corrected_id;
        public List<string> tags;


        public void toSQL(Database db)
        {
            string tagss = "";
            foreach (var item in tags)
            {
                tagss += item + " ";
            }

            

            string sql = String.Format("INSERT INTO champions VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", id, key, corrected_id, tagss, "");

            db.SQLStatement(sql);
        }

    }
}

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

namespace leagueAPI_test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Match> m = new List<Match>();
                     
            crawler c = new crawler();
            m = (c.crawlMatches(c.getAccIDFromName("Mcspunk")));
            foreach (Match match in m)
            {
                c.crawlMatchTimeline(match);
            }

            while (c.completedMatches.Count < 10)
            {
                try
                {
                    c.crawl(c.queue.Dequeue());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(c.completedMatches.Count());
        }       
    }
}

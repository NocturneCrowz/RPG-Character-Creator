using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RPG_Character_Creator
{
    class SearchAFeat
    {
        private string path;
        
        public void SAF(string keyword)
        {
            StreamReader file = new StreamReader(@path);
            string ln;
            Console.WriteLine("Searching in the black hole!");

            while ((ln = file.ReadLine()) != null)
            {
                if (ln.Contains(keyword + ':', StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Feat found!");
                    Console.WriteLine(ln);
                    file.Close();
                    return;
                }

            }
            Console.WriteLine("It seems like I wasn't able to find your feat. Sadly my AI is not that great, blame the developer!");
            file.Close();
        }

        public SearchAFeat(string path)
        {
            this.path = path;
        }
    }
}

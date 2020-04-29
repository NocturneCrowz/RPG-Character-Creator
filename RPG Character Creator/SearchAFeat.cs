using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RPG_Character_Creator
{
    class SearchAFeat
    {
        // Path to Feats.txt file
        private string path;
        
        // Search a feat function
        public void SAF(string keyword)
        {
            // Loading Feats.txt
            StreamReader file = new StreamReader(@path);
            string ln;
            Console.WriteLine("Searching into the void...");

            // Reading Feats.txt and comparing the feat needed with the text
            while ((ln = file.ReadLine()) != null)
            {
                // Succesful search
                if (ln.Contains(keyword + ':', StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Feat found!");
                    Console.WriteLine(ln);
                    file.Close();
                    return;
                }

            }
            // Insuccesful search
            Console.WriteLine("It seems like I wasn't able to find your feat. Sadly my AI is not that great, blame the developer!");
            file.Close();
        }

        // Public costructor to set the path

        public SearchAFeat(string path)
        {
            this.path = path;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RPG_Character_Creator
{
    class SearchAFeat
    {
        // File Feats.txt
        StreamReader file;
        string[] featLine = null;

        // Search a feat function
        public void SAF(string keyword)
        {
            // Loading Feats.txt
            string ln;
            Console.WriteLine("Searching into the void...");

            // Reading Feats.txt and comparing the feat needed with the text
            while ((ln = file.ReadLine()) != null)
            {
                // Succesful search
                if (ln.Contains(keyword + ':', StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Feat found!");
                    //Console.WriteLine(ln);
                    this.featLine = ln.Split('|');
                    file.Close();
                    return;
                }

            }
            // Insuccesful search
            Console.WriteLine("It seems like I wasn't able to find your feat. Sadly my AI is not that great, blame the developer!");
            file.Close();
        }// SAF

        public void PrintInfo()
        {
            string[] info = this.featLine[0].Split(": "); 
            Console.WriteLine("Info!");
            Console.WriteLine();
            Console.WriteLine(info[1]);
        }// PrintInfo

        public void PrintReq()
        {
            string[] req = this.featLine[1].Split(": ");  
            Console.WriteLine("Prerequisite!");
            Console.WriteLine();
            Console.WriteLine(req[1]);
        }// PrintReq

        public void PrintBonus()
        {
            string[] bonus = this.featLine[2].Split(": ");
            Console.WriteLine("Bonus!");
            Console.WriteLine();
            Console.WriteLine(bonus[1]);
        }// PrintBonus

        // Public costructor to initialize the file

        public SearchAFeat(string path)
        {
            try
            {
                this.file = new StreamReader(@path);
            }
            catch (Exception e)
            {
                Console.WriteLine("If you see this, something terrible happened while opening the file. Use CTRL + C to exit the program and start it again. Make sure to double check the path!");
            }
        }// SearcAFeat
    }// Class
}// Namespace

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace RPG_Character_Creator
{
    class SearchAFeat
    {
        // File Feats.txt
        private StreamReader file;
        private string[] featLine;
        private Dictionary<string, string> listOfFeats;

        // List of feats
        public void PrintList()
        {
            foreach (KeyValuePair<string, string> kvp in this.listOfFeats)
            {
                Console.WriteLine("[]" + kvp.Key + " ==> " + kvp.Value);
            }

        }// PrintList

        // List Creation
        private void CreateList()
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                string[] info = data[0].Split(": "); 
                this.listOfFeats.Add(info[0], info[1]);
            }
        }// CreateList

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
                if (ln.StartsWith(keyword + ':', StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Feat found!");
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
            if (this.featLine == null)
                Console.WriteLine("I can't print the info, I don't have a feat associated!");
            else
            {
                Console.WriteLine("\n----------------------------------------");
                string[] info = this.featLine[0].Split(": "); 
                Console.WriteLine("Info!");
                Console.WriteLine();
                Console.WriteLine(info[1]);
            }
            
        }// PrintInfo

        public void PrintReq()
        {
            if (this.featLine == null)
                Console.WriteLine("I can't print the prerequisite, I don't have a feat associated!");
            else
            {
                Console.WriteLine("\n----------------------------------------");
                string[] req = this.featLine[1].Split(": ");
                Console.WriteLine("Prerequisite!");
                Console.WriteLine();
                Console.WriteLine(req[1]);
            }
        }// PrintReq

        public void PrintBonus()
        {
            if (this.featLine == null)
                Console.WriteLine("I can't print the bonus, I don't have a feat associated!");
            else
            {
                Console.WriteLine("\n----------------------------------------");
                string[] bonus = this.featLine[2].Split(": ");
                Console.WriteLine("Bonus!");
                Console.WriteLine();
                Console.WriteLine(bonus[1]);
            }
        }// PrintBonus

        // Public costructor to initialize the file

        public SearchAFeat()
        {
            // File Path attributes
            var fileName = "RPG_Character_Creator.Feats.txt";
            var assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(fileName);
            // Class attributes
            this.featLine = null;
            this.listOfFeats = new Dictionary<string, string>();
            // Loading the File text
            try
            {
                this.file = new StreamReader(stream);
            }
            catch (Exception e)
            {
                Console.WriteLine("If you see this, something terrible happened while opening the file. Use CTRL + C to exit the program and start it again.");
                Console.WriteLine("This is the error.");
                Console.WriteLine(e);
            }
            // Dictionary
            CreateList();
        }// SearcAFeat
    }// Class
}// Namespace

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace RPG_Character_Creator
{
    class SkillsManager
    {
        // File Feats.txt
        private StreamReader file;
        private string[] skillLine;
        private Dictionary<string, string> listOfSkills;

        private void OpenFile()
        {
            var fileName = "RPG_Character_Creator.Skills.txt";
            var assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(fileName);
            this.file = new StreamReader(stream);
        }

        // List of skills
        public void PrintList()
        {
            foreach (KeyValuePair<string, string> kvp in this.listOfSkills)
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
                this.listOfSkills.Add(info[0], info[1]);
            }
            file.Close();
        }// CreateList

        // Search a skill function
        public void SearchSkill(string keyword)
        {
            string ln;
            Console.WriteLine("Searching into the void...");
            OpenFile();
            // Reading Feats.txt and comparing the feat needed with the text
            while ((ln = file.ReadLine()) != null)
            {
                // Succesful search
                if (ln.StartsWith(keyword + ':', StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Skill found!");
                    this.skillLine = ln.Split('|');
                    file.Close();
                    return;
                }

            }
            // Insuccesful search
            Console.WriteLine("It seems like I wasn't able to find your skill. Sadly my AI is not that great, blame the developer!");
            file.Close();
        }// SearchSkill


        public void PrintInfo()
        {
            if (this.skillLine == null)
                Console.WriteLine("I can't print the info, I don't have a skill associated!");
            else
            {
                Console.WriteLine("\n----------------------------------------");
                string[] info = this.skillLine[0].Split(": ");
                Console.WriteLine("Info!");
                Console.WriteLine();
                Console.WriteLine(info[1]);
            }

        }// PrintInfo

        public void PrintMod()
        {
            if (this.skillLine == null)
                Console.WriteLine("I can't print the modifier, I don't have a skill associated!");
            else
            {
                Console.WriteLine("\n----------------------------------------");     
                Console.WriteLine("Modifier!\n");
                Console.WriteLine(this.skillLine[1]);
            }
        }// PrintReq

        // Public costructor to initialize the file
        public SkillsManager()
        {
            // File Path attributes
            var fileName = "RPG_Character_Creator.Skills.txt";
            var assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(fileName);
            // Class attributes
            this.skillLine = null;
            this.listOfSkills = new Dictionary<string, string>();
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

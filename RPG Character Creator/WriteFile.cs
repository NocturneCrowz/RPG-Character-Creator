using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace RPG_Character_Creator
{
    static class WriteFile
    {
        public static void Create(dynamic character, CharacterInfo info, List<string> talents, Dictionary<string, int> spells)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            try
            {

                // Create a new file     
                using (System.IO.StreamWriter sw = File.CreateText(Path.Combine(desktopPath, info.Name + ".txt")))
                {
                    sw.WriteLine("New character created: {0}", DateTime.Now.ToString());
                    sw.WriteLine("");
                    sw.WriteLine("-----------------------------------------------------");
                    sw.WriteLine("Basic Info:");
                    sw.WriteLine("Class: " + character.GetBaseInfo("chosenClass"));
                    sw.WriteLine("Race: " + character.GetBaseInfo("race"));
                    sw.WriteLine("Level: " + Convert.ToInt32(character.GetBaseInfo("level")));

                    sw.WriteLine("");
                    sw.WriteLine("-----------------------------------------------------");
                    sw.WriteLine("General Info:");
                    sw.WriteLine("Name: " + info.Name);
                    sw.WriteLine("Birth Date: " + info.DateOfBirth);
                    sw.WriteLine("Birth Place: " + info.PlaceOfBirth);
                    sw.WriteLine("Sex: " + info.Sex);
                    sw.WriteLine("Age: " + info.Age);
                    sw.WriteLine("Height: " + info.Height + "cm");
                    sw.WriteLine("Weight: " + info.Weight);
                    sw.WriteLine("Size: " + info.Size);
                    sw.WriteLine("Hair: " + info.Hair);
                    sw.WriteLine("Eyes: " + info.Eyes);
                    sw.WriteLine("Skintone: " + info.SkinTone);

                    sw.WriteLine("");
                    sw.WriteLine("-----------------------------------------------------");
                    sw.WriteLine("Base Stats:");
                    sw.WriteLine("Strength: " + character.GetBaseStat("Strength"));
                    sw.WriteLine("Dexterity: " + character.GetBaseStat("Dexterity"));
                    sw.WriteLine("Constitution: " + character.GetBaseStat("Constitution"));
                    sw.WriteLine("Intelligence: " + character.GetBaseStat("Intelligence"));
                    sw.WriteLine("Wisdom: " + character.GetBaseStat("Wisdom"));
                    sw.WriteLine("Charisma: " + character.GetBaseStat("Charisma"));

                    sw.WriteLine("");
                    sw.WriteLine("-----------------------------------------------------");
                    sw.WriteLine("Combat Info:");
                    sw.WriteLine("Health Points: " + character.GetStat("hp"));
                    sw.WriteLine("Armor Class: " + character.GetStat("armorClass"));
                    sw.WriteLine("Base Attack Bonus: " + character.GetStat("bab"));
                    sw.WriteLine("Will: " + character.GetStat("will"));
                    sw.WriteLine("Reflex: " + character.GetStat("reflex"));
                    sw.WriteLine("Fortitude: " + character.GetStat("fortitude"));
                    sw.WriteLine("For unknown reasons, the Will, Reflex and Fortitude values are sometimes buggy when the random generator is used.");
                    sw.WriteLine("On the guided generator they work fine tho. I'm still working on it.");

                    sw.WriteLine("");
                    sw.WriteLine("-----------------------------------------------------");
                    sw.WriteLine("Feats Info:");
                    foreach (var item in talents)
                    {
                        sw.WriteLine(item);
                    }

                    sw.WriteLine("");
                    sw.WriteLine("-----------------------------------------------------");
                    sw.WriteLine("Spell Info:");
                    if (spells == null)
                        Console.WriteLine("This class cannot cast spells!");
                    else
                    {
                        foreach (KeyValuePair<string, int> kvp in spells)
                        {
                            sw.WriteLine("[]" + kvp.Key + "\t ==> \t" + kvp.Value);
                        }
                    }
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}

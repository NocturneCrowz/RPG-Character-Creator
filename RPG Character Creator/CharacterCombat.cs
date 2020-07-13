using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    public class CharacterCombat
    {
        private Dictionary<string, int> statistics;
        private Dictionary<string, int> castableSpells;
        private readonly string[] stats = new string[6] { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };
        private int armorClass = 0;
        private int fortitude = 0;
        private int reflex = 0;
        private int will = 0;
        private int hp = 0;
        private int bab = 0;
        private int bonusFeat = 0;
        private string chosenClass;
        private string race;
        private string level;

        public void UpdateBaseInfo(int choice, string info)
        {
            if (choice == 1)
                this.chosenClass = info;
            else if (choice == 2)
                this.race = info;
            else
                this.level = info;
        }// UpdateBaseInfo

        public string GetBaseInfo(string info)
        {
            string var = null;
            switch (info)
            {
                case "chosenClass":
                    var = this.chosenClass;
                    break;
                case "race":
                    var = this.race;
                    break;
                case "level":
                    var = this.level;
                    break;
                default:
                    Console.WriteLine("I coun't gather your info!");
                    break;
            }

            return var;
        }// GetBaseInfo

        public int GetBonusFeat()
        {
            return this.bonusFeat;
        }// GetBonusFeat
        
        public void AddBonusFeat()
        {
            this.bonusFeat++;
        }// UpdateFeat

        public void PrintStats()
        {
            foreach (KeyValuePair<string, int> kvp in this.statistics)
            {
                Console.WriteLine("[]" + kvp.Key + "\t ==> \t" + kvp.Value);
            }
        }// PrintStats

        public void UpdateStat(int n, string s)
        {
            if (s == "armorClass")
                this.armorClass += n;
            else if (s == "fortitude")
                this.fortitude += n;
            else if (s == "reflex")
                this.reflex += n;
            else if (s == "will")
                this.will += n;
            else if (s == "bab")
                this.bab += n;
            else if (s == "hp")
                this.hp = n;
            else
                Console.WriteLine("Something went wrong. Ooof.");
        }// UpdateStat

        public int GetStat(string s)
        {
            int res = 0;
            if (s == "armorClass")
                res = this.armorClass;
            else if (s == "fortitude")
                res = this.fortitude;
            else if (s == "reflex")
                res = this.reflex;
            else if (s == "will")
                res = this.will;
            else if (s == "bab")
                res = this.bab;
            else if (s == "hp")
                res = this.hp;
            else
                Console.WriteLine("Something went wrong. Ooof.");

            return res;
        }// GetStat

        public int GetModifier(string name)
        {
            int value;
            this.statistics.TryGetValue(name, out value);
            if (value >= 10)
                return (value - 10) / 2;
            else
                return (int)((((double)value - 10.0) / 2) - 0.5);
        }// GetModifier

        protected void AddSpell(int n, string s)
        {
            this.castableSpells.Add(s, n);
        }// AddSpell

        public void PrintCastableSpells()
        {
            if (this.castableSpells == null || this.castableSpells.Count == 0)
                Console.WriteLine("This class cannot cast spells!");
            else
            {
                foreach (KeyValuePair<string, int> kvp in this.castableSpells)
                {
                    Console.WriteLine("[]" + kvp.Key + "\t ==> \t" + kvp.Value);
                }
            }
        }// PrintCastableSpells

        public Dictionary<string, int> ReturnCastableSpells()
        {
            return this.castableSpells;
        }

        public void ChangeBaseStat(string s, int n)
        {
            int value;
            bool res = this.statistics.TryGetValue(s, out value);
            if (res == false)
            {
                value = 0;
                this.statistics.Add(s, n);
            }
            else
            {
                this.statistics.Remove(s);
                this.statistics.Add(s, value + n);
            }

            if (s == "Dexterity")
            {
                this.armorClass = 10 + GetModifier("Dexterity");
                this.reflex = GetModifier("Dexterity");
            }
            else if (s == "Constitution")
            {
                this.fortitude = GetModifier("Constitution");
            }
            else if (s == "Wisdom")
            {
                this.will = GetModifier("Wisdom");
            }
        }// ChangeBaseStat

        public void InsertBaseStat()
        {
            int res = 0;
            for (int i = 0; i < 6;)
            {
                do
                {
                    int value = 0;
                    Console.WriteLine($"Insert the value for {stats[i]}: ");
                    try
                    {
                        value = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("It seems like you tried to insert one or more letters instead of an integer. You can't do that!");
                        Console.WriteLine();
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("It seems like something went wrong. Try contacting the developer, but he won't know much more.");
                        Console.WriteLine();
                    }
                    finally
                    {
                        if (value < 3 || value > 18)
                        {
                            Console.WriteLine("The value is invalid, it must be between 3 and 18. Try again!");
                        }
                        else
                        {
                            this.statistics.Add(stats[i], value);
                            if (i == 1)
                            {
                                this.armorClass = 10 + GetModifier("Dexterity");
                                this.reflex = GetModifier("Dexterity");
                            }
                            else if (i == 2)
                            {
                                this.fortitude = GetModifier("Constitution");
                            }
                            else if (i == 4)
                            {
                                this.will = GetModifier("Wisdom");
                            }
                            res = 1;
                            i++;
                        }
                    }
                } while (res == 0);
            }// For cycle
        }// InsertBaseStat

        public int GetBaseStat(string s)
        {
            int value;
            this.statistics.TryGetValue(s, out value);
            return value;
        }// GetBaseStat

        public CharacterCombat()
        { 
            this.statistics = new Dictionary<string, int>();
            this.castableSpells = new Dictionary<string, int>();
        }// BaseClass
    }// Class
}// Namespace

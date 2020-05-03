using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    class CharacterCombat
    {
        private Dictionary<string, int> statistics;
        private readonly string[] stats = new string[6] { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };
        private int armorClass;
        private int fortitude;
        private int reflex;
        private int will;
        private int hp;
        private int bab;
        private Dictionary<string, int> castableSpells;
        public void PrintStats()
        {
            foreach (KeyValuePair<string, int> kvp in this.statistics)
            {
                Console.WriteLine("[]" + kvp.Key + "\t ==> \t" + kvp.Value);
            }
        }// PrintStats

        public void ChangeStat()
        {
            Console.WriteLine("It seems like you want to change one of your statistic. Choose one: ");
            Console.WriteLine("1- Armor Class");
            Console.WriteLine("2- Fortitude");
            Console.WriteLine("3- Reflex");
            Console.WriteLine("4- Will");
            int res;

            try
            {
                do
                {
                    res = Convert.ToInt32(Console.ReadLine());

                } while ((res < 1) || (res > 4));

                switch (res)
                {
                    case 1:
                        Console.WriteLine("You chose Armor Class. You current value is: " + this.armorClass + "\nWhat is the new value?");
                        this.armorClass = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("You chose Fortitude. You current value is: " + this.fortitude + "\nWhat is the new value?");
                        this.fortitude = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("You chose Reflex. You current value is: " + this.reflex + "\nWhat is the new value?");
                        this.reflex = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("You chose Will. You current value is: " + this.will + "\nWhat is the new value?");
                        this.will = Convert.ToInt32(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Something went wrong. Try again, or ask for support!");
                        break;
                }// Switch
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
            }// Try-Catch
        }// ChangeStat

        protected void UpdateStat(int n, string s)
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

        protected int GetStat(string s)
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

        protected int GetModifier(string name)
        {
            int value;
            this.statistics.TryGetValue(name, out value);
            
            return (value -10)/2;

        }// GetModifier

        protected void AddSpell(int n, string s)
        {
            this.castableSpells.Add(s, n);
        }// AddSpell

        public void PrintCastableSpells()
        {
            if (this.castableSpells == null)
                Console.WriteLine("This class cannot cast spells!");
            else
            {
                foreach (KeyValuePair<string, int> kvp in this.castableSpells)
                {
                    Console.WriteLine("[]" + kvp.Key + "\t ==> \t" + kvp.Value);
                }
            }
        }// PrintCastableSpells

        public void ChangeBaseStat(string s)
        {
            int value;
            this.statistics.TryGetValue(s, out value);
            this.statistics.Remove(s);
            this.statistics.Add(s, value+1);
            if (s == "Dexterity")
            {
                this.armorClass = 10 + Convert.ToInt32((value - 10) / 2);
                this.reflex = Convert.ToInt32((value - 10) / 2);
            }
            else if (s == "Constitution")
            {
                this.fortitude = Convert.ToInt32((value - 10) / 2);
            }
            else if (s == "Wisdom")
            {
                this.will = Convert.ToInt32((value - 10) / 2);
            }
        }// ChangeBaseStat

        public CharacterCombat()
        { 
            this.statistics = new Dictionary<string, int>();
            this.castableSpells = new Dictionary<string, int>();
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
                                this.armorClass = 10 + Convert.ToInt32((value-10) / 2);
                                this.reflex = Convert.ToInt32((value - 10) / 2);
                            }
                            else if (i == 2)
                            {
                                this.fortitude = Convert.ToInt32((value - 10) / 2);
                            }
                            else if (i == 4)
                            {
                                this.will = Convert.ToInt32((value - 10) / 2);
                            }
                            res = 1;
                            i++;
                        }
                    }
                } while (res == 0);
            }// For cycle
        }// BaseClass
    }// Class
}// Namespace

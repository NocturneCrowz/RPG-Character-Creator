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
        public void PrintStats()
        {
            foreach (KeyValuePair<string, int> kvp in this.statistics)
            {
                Console.WriteLine("[]" + kvp.Key + "\t ==> \t" + kvp.Value);
            }
        }// PrintStats

        public void PrintAStat() 
        {
            Console.WriteLine("Which one of your statistic you want to print?");
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
                    if ((res < 1) || (res > 4))
                    {
                        Console.WriteLine("That is invalid. Please try again: ");
                    }

                } while ((res < 1) || (res > 4));

                switch (res)
                {
                    case 1:
                        Console.WriteLine("You chose Armor Class. You current value is: " + this.armorClass);
                        break;
                    case 2:
                        Console.WriteLine("You chose Fortitude. You current value is: " + this.fortitude);
                        break;
                    case 3:
                        Console.WriteLine("You chose Reflex. You current value is: " + this.reflex);
                        break;
                    case 4:
                        Console.WriteLine("You chose Will. You current value is: " + this.will);
                        break;
                    default:
                        Console.WriteLine("Something went wrong. Try again, or ask for support!");
                        break;
                }// Switch case
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
        }// PrintAStat

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
            else
                Console.WriteLine("Something went wrong. Ooof.");
        }// UpdateStat

        protected int GetModifier(string name)
        {
            int value;
            this.statistics.TryGetValue(name, out value);
            
            return (value -10)/2;

        }// GetStat
        public CharacterCombat()
        { 
            this.statistics = new Dictionary<string, int>();
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

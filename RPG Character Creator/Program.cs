using System;
using System.IO;
using System.Reflection;

namespace RPG_Character_Creator
{
    class Program
    {
        static void Main(string[] args)
        {
            // dice roll, working
            /*DiceRoll rnd = new DiceRoll();
            int diceRoll = -1;
            Console.WriteLine("Choose a number:");
            do
            {
                int value = 0;
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
                    if (value == 0)
                    {
                       Console.WriteLine("I wasn't able to finish the roll, try again! Choose a number: ");
                    }
                    else
                    {
                       diceRoll = rnd.Roll(value);
                       if (diceRoll == -1)
                       {
                           Console.WriteLine("Whoops! Your dice has fallen into a blackhole, recover it and try again! Choose a number: ");
                       }
                    }
                }
            } while (diceRoll == -1);
            Console.WriteLine(diceRoll);*/

            // Talent search working
            /*
            while (true)
            {
                SearchAFeat search = new SearchAFeat();
                search.PrintList();
                Console.WriteLine("Insert a feat to search: ");
                search.SAF(Console.ReadLine());
                search.PrintInfo();
                search.PrintReq();
                search.PrintBonus();

            }
            */

            //CharacterCombat ciao = new CharacterCombat();
           /* Barbarian asd = new Barbarian(5);
            asd.ChangeStat();
            asd.PrintTalents();*/

            Monk monk = new Monk(5);
            Console.WriteLine(monk.GetBonusFeat());
            monk.PrintCastableSpells();
            monk.PrintTalents();
            monk.PrintStats();


        }
    }
}

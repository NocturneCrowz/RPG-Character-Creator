using System;
using System.IO;
using System.Reflection;

namespace RPG_Character_Creator
{
    class Program
    {
        static void Main(string[] args)
        {

            //https://www.d20srd.org/index.htm
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
            /*
           Monk monk = new Monk(5);
           Console.WriteLine(monk.GetBonusFeat());
           monk.PrintCastableSpells();
           monk.PrintTalents();
           monk.PrintStats();

           monk.ChangeBaseStat("Dexterity");
           monk.PrintStats();

           Wizard wiz = new Wizard(5);
           wiz.PrintCastableSpells();
           wiz.PrintTalents();*/

            /*SkillsManager skill = new SkillsManager();
                skill.PrintList();
                skill.SearchSkill("Ride");
                skill.PrintInfo();
                skill.PrintMod();
            Druid info = new Druid(5);
            int asd = info.GetBonusFeat();
            for (int i = 0; i < asd; i++)
                info.AddFeat(Cons/*ole.ReadLine());
            info.PrintTalents();*/
            /* FeatsManager feat = new FeatsManager();
             feat.SearchFeat("Silent spell");
             feat.PrintBonus();
             feat.PrintInfo();
             feat.PrintList();
             feat.PrintReq();*/

            /*Fighter fighter = new Fighter(5);
            fighter.HPInfo();
            fighter.PrintCastableSpells();
            fighter.PrintStats();
            fighter.PrintTalents();
            fighter.HPInfo();
            Dwarf dwarf = new Dwarf(fighter);
            fighter.HPInfo();
            fighter.PrintCastableSpells();
            fighter.PrintStats();
            fighter.PrintTalents();
            fighter.HPInfo();*/

            GuidedGenerator.Generate();
            Barbarian barb = new Barbarian(2)

        }
    }
}

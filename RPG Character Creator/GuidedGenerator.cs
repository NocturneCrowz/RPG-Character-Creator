using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    static class GuidedGenerator
    {
        public static CharacterCombat Generate()
        {
            int chosenClass = 0;
            int level = 0;
            int res = 0;
            int feat = 0;
            dynamic character = new CharacterCombat();

            //Starting by choosing the class
            Console.WriteLine("Welcome to the Guided Generation! My name is... well, I don't have a name, but it's fine anyway!");
            Console.WriteLine("Now I will walk you through che creation of a new D&D character! Now, where did i put.....");
            Console.WriteLine("...");
            Console.WriteLine("Yes, found it. First, I need to know what class you want to be. Classes are what specialize you, and we have a lot of them!.");
            Console.WriteLine("Do you want to be a mighty Paladin? We got it! A wise Wizard? Check. A sneaky Rogue? Just don't try to steal my code...");
            Console.WriteLine("Now now, let's start. We have those classes avaibles, so pick carefully:\n1- Barbarian\n2- Bard\n3- Cleric\n4- Druid\n5- Fighter\n6- Monk\n7- Paladin\n8- Ranger\n9- Rogue\n10- Sorcerer\n11- Wizard\nYour choice is: ");
            do
            {
                try
                {
                    chosenClass = Convert.ToInt32(Console.ReadLine());
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
                    if (chosenClass > 0 && chosenClass < 12)
                    {
                        res = 1;
                        Console.WriteLine("Ah, that is an amazing class! Now I will need to ask you a few more questions..");
                    }
                    else
                        Console.WriteLine("There was a problem selecting your class. Please, try again.");
                }

            } // Class 
            while (res == 0);

            // Level choice
            Console.WriteLine("\n----------------------------------------");
            res = 0;
            Console.WriteLine("Enter your character level! You can select any level from 1 to 5!");
            do
            {
                try
                {
                    level = Convert.ToInt32(Console.ReadLine());
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
                    if (level > 0 && level < 6)
                    {
                        res = 1;
                        Console.WriteLine("Nice! We will now proceed!\n");
                    }
                    else
                        Console.WriteLine("There was a problem selecting your Level. Please, try again.");
                }

            } // Level
            while (res == 0);

            //Updating the base class CharacterCombat to the proper selected class
            switch (chosenClass)
            {
                case 1:
                    character = new Barbarian(level);
                    character.UpdateBaseInfo(1, "Barbarian");
                    character.UpdateBaseInfo(3, level.ToString());
                    break;
                case 2:
                    character = new Bard(level);
                    character.UpdateBaseInfo(1, "Bard");
                    character.UpdateBaseInfo(3, level.ToString());
                    break;
                case 3:
                    character = new Cleric(level);
                    character.UpdateBaseInfo(1, "Cleric");
                    character.UpdateBaseInfo(3, level.ToString());
                    break;
                case 4:
                    character = new Druid(level);
                    character.UpdateBaseInfo(1, "Druid");
                    character.UpdateBaseInfo(3, level.ToString());
                    break;
                case 5:
                    character = new Fighter(level);
                    character.UpdateBaseInfo(1, "Fighter");
                    character.UpdateBaseInfo(3, level.ToString());
                    break;
                case 6:
                    character = new Monk(level);
                    character.UpdateBaseInfo(1, "Monk");
                    character.UpdateBaseInfo(3, level.ToString());
                    break;
                case 7:
                    character = new Paladin(level);
                    character.UpdateBaseInfo(1, "Paladin");
                    character.UpdateBaseInfo(3, level.ToString());
                    break;
                case 8:
                    character = new Ranger(level);
                    character.UpdateBaseInfo(1, "Ranger");
                    character.UpdateBaseInfo(3, level.ToString());
                    break;
                case 9:
                    character = new Rogue(level);
                    character.UpdateBaseInfo(1, "Rogue");
                    character.UpdateBaseInfo(3, level.ToString());
                    break;
                case 10:
                    character = new Sorcerer(level);
                    character.UpdateBaseInfo(1, "Sorcerer");
                    character.UpdateBaseInfo(3, level.ToString());
                    break;
                case 11:
                    character = new Wizard(level);
                    character.UpdateBaseInfo(1, "Wizard");
                    character.UpdateBaseInfo(3, level.ToString());
                    break;
                default:
                    Console.WriteLine("Seems like I've encountered a problem. Try again!");
                    break;
            }// Switch Case

            //Base Statistics Insertion
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Now I will need you to insert your statistics!\n");
            character.InsertBaseStat();

            //Race choice
            Console.WriteLine("\n----------------------------------------");
            Races.Choice(character);

            //Hp update
            Console.WriteLine("\n----------------------------------------");
            character.HPInfo();


            //Feats managing
            int featsNumber = character.GetBonusFeat();
            FeatsManager featList = new FeatsManager();

            for (int i = 0; i < character.GetBonusFeat(); i++)
            {
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine("Current Feat(s): ");
                character.PrintTalents();
                res = 0;
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine("\n" + featsNumber + " feat(s) remaining.");
                Console.WriteLine("You can now: \n1- Search your feat\n2- Insert your feat\n3- Print the feat list\nYour choice: ");
                do
                {
                    try
                    {
                        feat = Convert.ToInt32(Console.ReadLine());
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
                        if (feat > 0 && feat < 4)
                        {
                            res = 1;
                        }
                    }

                } // Feat
                while (res == 0);

                if (feat == 1)
                {
                    Console.WriteLine("Searching feat: ");
                    featList.SearchFeat(Console.ReadLine());
                    featList.PrintInfo();
                    featList.PrintReq();
                    featList.PrintBonus();
                }
                else if (feat == 2)
                {
                    Console.WriteLine("Ok, I will now let you add the feat! Be sure to write it properly, as this part of the program doesn't have a validation... yet.");
                    character.AddFeat(Console.ReadLine());
                    featsNumber--;
                }
                else
                {
                    featList.PrintList();
                }

            }// For Cycle
            Console.WriteLine("Total Feat(s)!");
            character.PrintTalents();

            // Print Spells
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Spells!");
            character.PrintCastableSpells();

            return character;
        }
    }
}

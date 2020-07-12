using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace RPG_Character_Creator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to RPG Character Creator! \nThis software was developed by Barzotti Cristian.");
            Console.WriteLine("\nDisclaimer!\nThis software is free to use and it's not intended as a substitute of the \nRoleplaying Game Core Book published by Wizards of the Coast, Inc.!");
            Console.WriteLine("The information inside this software were taken from https://www.d20srd.org/index.htm");
            Console.WriteLine("I do not own any of the informations inside this software.");

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("Ehy you, you are finally ready!\nLet me introduce you to this software.");
            Console.WriteLine("With this software, you too will be able to create your own RPG Character! \nEither randomly or guided, the AI in this software is amazing!...ly stupid. I apologize.");
            Console.WriteLine("Anyway, let's start. First of all, I will need to know how do you want to proceed. Do you want a:\n1- Randomly Created Character\n2- Create My Own Character");

            int res = 0;
            int choice = 0;
            dynamic character = null;

            do
            { 
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
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
                    if (choice > 0 && choice < 3)
                    {
                        res = 1;
                        Console.WriteLine("Amazing! Let's start!");
                    }
                    else
                        Console.WriteLine("There was a problem selecting your option. Please, try again.");
                }

            } // Choice
            while (res == 0);

            // Here we create the character
            if (choice == 1)
                character = RandomGenerator.Generate();
            else
                character = GuidedGenerator.Generate();

            // Some more info
            CharacterInfo info = new CharacterInfo();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("Your character is almost done! I need only a few more info about it.\n");
            Console.WriteLine("What is your name?");
            info.Name = Console.ReadLine();
            Console.WriteLine("When were you born? (Use xx/xx/xxxx format)");
            info.DateOfBirth = Console.ReadLine();
            Console.WriteLine("Where were you born?");
            info.PlaceOfBirth = Console.ReadLine();
            Console.WriteLine("How old you are?");
            info.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is your sex?");
            info.Sex = Console.ReadLine();
            Console.WriteLine("How tall are you in cm?");
            info.Height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How much do you weight?");
            info.Weight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is your muscolar size?");
            info.Size = Console.ReadLine();
            Console.WriteLine("And your skintone?");
            info.SkinTone = Console.ReadLine();
            Console.WriteLine("What's your hair color?");
            info.Hair = Console.ReadLine();
            Console.WriteLine("And your eyes color?");
            info.Eyes = Console.ReadLine();

            Console.WriteLine("Congrats! Your character is finally done!");
            res = 0;
            choice = 0;
            do
            {
                Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Do you want to do something else before closing the program?\n1- Print my stat\n2- Print my talents\n3- Print my spells\n4- Create the .txt file and exit.");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
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
                    if (choice == 1)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Strength: " + character.GetBaseStat("Strength"));
                        Console.WriteLine("Dexterity: " + character.GetBaseStat("Dexterity"));
                        Console.WriteLine("Constitution: " + character.GetBaseStat("Constitution"));
                        Console.WriteLine("Intelligence: " + character.GetBaseStat("Intelligence"));
                        Console.WriteLine("Wisdom: " + character.GetBaseStat("Wisdom"));
                        Console.WriteLine("Charisma: " + character.GetBaseStat("Charisma"));
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("");
                        character.PrintTalents();
                    }
                    else if (choice == 3)
                    {
                        Console.WriteLine("");
                        character.PrintCastableSpells();
                    }
                    else if (choice == 4)
                    {
                        res = 1;

                        List<string> talents = character.GetTalents();

                        Dictionary<string, int> spells = character.ReturnCastableSpells();

                        WriteFile.Create(character, info, talents, spells);
                    }
                    else
                    {
                        Console.WriteLine("Seems like that choice is invalid. Please, try again.");
                    }
                }

            } while (res == 0);

            Console.WriteLine("\nThank you for using this software! We are done!");

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            Console.WriteLine("A file has been created @:" + desktopPath + " named " + info.Name + ".txt");

            Console.WriteLine("See you next time!");

        }
    }
}

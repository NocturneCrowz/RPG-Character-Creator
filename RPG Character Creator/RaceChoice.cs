using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    public static class RaceChoice
    {
        public static void Choice(CharacterCombat character)
        {
            int res = 0;
            Console.WriteLine("Welcome in the race selector! Please, select a race. We currently have those:");
            Console.Write("\n1) Dwarf\n2) Elf\n3) Gnome\n4) Half Elf\n5) Halfling\n6) Half Orc\n7) Human\nYour choice is:");
            do
            {
                int race = 0;
                try
                {
                    race = Convert.ToInt32(Console.ReadLine());
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
                    if (race < 1 || race > 7)
                    {
                        Console.WriteLine("Seems like your choice is invalid. Please, try again.");
                    }
                    else
                    {
                        res = 1;
                        switch (race)
                        {
                            
                            case 1:
                                Console.WriteLine("Ah, so you choose Dwarf. A fine choice my friend, the programmer is very pleased.");
                                Races.Combine(character, "Dwarf");
                                break;
                            case 2:
                                Console.WriteLine("Uhm, it seems like you went for Elf. Oh well, I can't really say no, but I mean..");
                                Races.Combine(character, "Elf");
                                break;
                            case 3:
                                Console.WriteLine("Gnome. Not quite a Dwarf, but almost!");
                                Races.Combine(character, "Gnome");
                                break;
                            case 4:
                                Console.WriteLine("Half Elf. You are only half as bad as an Elf, so I can allow it.");
                                break;
                            case 5:
                                Console.WriteLine("Ehy there you cute little fellas! Halfling it is then!");
                                Races.Combine(character, "Halfling");
                                break;
                            case 6:
                                Console.WriteLine("Half the Strength of a Human, half the Intelligence of an Orc! Or was it the other way around..?");
                                Races.Combine(character, "HalfOrc");
                                break;
                            case 7:
                                Console.WriteLine("So you went for the basic, Human! Nothing bad with that, I mean they are kinda overpowered.");
                                Races.Combine(character, "Human");
                                break;
                            default:
                                Console.WriteLine("I don't know how you got there, but that should really happen.. Try again maybe?");
                                res = 0;
                                break;
                        }
                    }
                }// Try Catch
            }// Do
            while (res == 0);
        }// Race Choice
    }
}

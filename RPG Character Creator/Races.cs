using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    static class Races
    {
        private static void Combine(CharacterCombat cCombat, string race)
        {
            switch (race)
            {
                case "Dwarf":
                    cCombat.ChangeBaseStat("Constitution", 2);
                    cCombat.ChangeBaseStat("Charisma", -2);
                    cCombat.UpdateBaseInfo(2, "Dwarf");
                    break;
                case "Elf":
                    cCombat.ChangeBaseStat("Dexterity", 2);
                    cCombat.ChangeBaseStat("Constitution", -2);
                    cCombat.UpdateBaseInfo(2, "Elf");
                    break;
                case "Gnome":
                    cCombat.ChangeBaseStat("Constitution", 2);
                    cCombat.ChangeBaseStat("Strength", -2);
                    cCombat.UpdateBaseInfo(2, "Gnome");
                    break;
                case "Halfling":
                    cCombat.ChangeBaseStat("Dexterity", 2);
                    cCombat.ChangeBaseStat("Strength", -2);
                    cCombat.UpdateBaseInfo(2, "Halfling");
                    break;
                case "HalfOrc":
                    cCombat.ChangeBaseStat("Strength", 2);
                    cCombat.ChangeBaseStat("Intelligence", -2);
                    cCombat.ChangeBaseStat("Charisma", -2);
                    cCombat.UpdateBaseInfo(2, "Half Orc");
                    break;
                case "Human":
                    cCombat.AddBonusFeat();
                    cCombat.UpdateBaseInfo(2, "Human");
                    break;
                case "HalfElf":
                    cCombat.UpdateBaseInfo(2, "Half Elf");
                    break;
                default:
                    Console.WriteLine("Uhm, something went wrong. I'm not even sure of what went wrong, but we will fix it! ...or it's just a feature.");
                    break;
            }
        }// Combine

        public static void Choice(CharacterCombat character)
        {
            int res = 0;
            Console.WriteLine("Please, select a race. We currently have those:");
            Console.WriteLine("\n1- Dwarf\n2- Elf\n3- Gnome\n4- Half Elf\n5- Halfling\n6- Half Orc\n7- Human\nYour choice is: ");
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
                                Races.Combine(character, "HalfElf");
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
        }// Choice

        public static void RndChoice(CharacterCombat character, int race)
        {
            switch (race)
            {
                case 1:
                    Races.Combine(character, "Dwarf");
                    break;
                case 2:
                    Races.Combine(character, "Elf");
                    break;
                case 3:
                    Races.Combine(character, "Gnome");
                    break;
                case 4:
                    Races.Combine(character, "HalfElf"); 
                    break;
                case 5:
                    Races.Combine(character, "Halfling");
                    break;
                case 6:
                    Races.Combine(character, "HalfOrc");
                    break;
                case 7:
                    Races.Combine(character, "Human");
                    break;
                default:
                    Console.WriteLine("I don't know how you got there, but that should really happen.. Try again maybe?");
                    break;
            }
        }// RndChoice
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_Character_Creator
{
    static class RandomGenerator
    {
        public static CharacterCombat Generate()
        {
            int chosenClass;
            int level;
            int race;
            int feat;
            string[] races = {"Dwarf", "Elf", "Gnome", "Half Elf", "Halfling", "Half Orc", "Human" };
            string[] stats = {"Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };
            DiceRoll dice = new DiceRoll();
            dynamic character = null;

            Console.WriteLine("Welcome to the Random Generator option! Stand by while we let our monke.... our skilled engineer create your new class!");

            // Choosing a class randomly
            chosenClass = dice.Roll(11);

            // Choosing a level randomly
            level = dice.Roll(5);

            // Select a race randomly
            race = dice.Roll(7);

            Console.WriteLine("\n----------------------------------------");

            switch (chosenClass)
            {
                case 1:
                    character = new Barbarian(level);
                    character.UpdateBaseInfo(1, "Barbarian");
                    Console.WriteLine("You are a level " + level + " " + races.GetValue(race - 1) + " Barbarian!");
                    break;
                case 2:
                    character = new Bard(level);
                    character.UpdateBaseInfo(1, "Bard");
                    Console.WriteLine("You are a level " + level + " " + races.GetValue(race - 1) + " Bard!");
                    break;
                case 3:
                    character = new Cleric(level);
                    character.UpdateBaseInfo(1, "Cleric");
                    Console.WriteLine("You are a level " + level + " " + races.GetValue(race - 1) + " Cleric!");
                    break;
                case 4:
                    character = new Druid(level);
                    character.UpdateBaseInfo(1, "Druid");
                    Console.WriteLine("You are a level " + level + " " + races.GetValue(race - 1) + " Druid!");
                    break;
                case 5:
                    character = new Fighter(level);
                    character.UpdateBaseInfo(1, "Fighter");
                    Console.WriteLine("You are a level " + level + " " + races.GetValue(race - 1) + " Fighter!");
                    break;
                case 6:
                    character = new Monk(level);
                    character.UpdateBaseInfo(1, "Monk");
                    Console.WriteLine("You are a level " + level + " " + races.GetValue(race - 1) + " Monk!");
                    break;
                case 7:
                    character = new Paladin(level);
                    character.UpdateBaseInfo(1, "Paladin");
                    Console.WriteLine("You are a level " + level + " " + races.GetValue(race - 1) + " Paladin!");
                    break;
                case 8:
                    character = new Ranger(level);
                    character.UpdateBaseInfo(1, "Ranger");
                    Console.WriteLine("You are a level " + level + " " + races.GetValue(race - 1) + " Ranger!");
                    break;
                case 9:
                    character = new Rogue(level);
                    character.UpdateBaseInfo(1, "Rogue");
                    Console.WriteLine("You are a level " + level + " " + races.GetValue(race - 1) + " Rogue!");
                    break;
                case 10:
                    character = new Sorcerer(level);
                    character.UpdateBaseInfo(1, "Sorcerer");
                    Console.WriteLine("You are a level " + level + " " + races.GetValue(race - 1) + " Sorcerer!");
                    break;
                case 11:
                    character = new Wizard(level);
                    character.UpdateBaseInfo(1, "Wizard");
                    Console.WriteLine("You are a level " + level + " " + races.GetValue(race - 1) + " Wizard!");
                    break;
                default:
                    Console.WriteLine("Seems like I've encountered a problem. Try again!");
                    break;
            }// Switch Case

            character.UpdateBaseInfo(3, level.ToString());

            // Implementing the race 
            Races.RndChoice(character, race);

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Creating your basic stats!");

            for (int i = 0; i < stats.Length; i++)
            {
                // Rolling 4 dices
                int[] roll = new int[4];
                roll[0] = dice.Roll(6);
                roll[1] = dice.Roll(6);
                roll[2] = dice.Roll(6);
                roll[3] = dice.Roll(6);

                // Removing the lowest value
                int numToRemove = roll.Min();
                int numIndex = Array.IndexOf(roll, numToRemove);
                roll = roll.Where((val, idx) => idx != numIndex).ToArray();

                // Calculating stat value
                int value = roll.Sum();

                // Adding stat value
                Console.WriteLine("\n---------------------------------");
                Console.WriteLine("Your " + stats[i] + " is " + value + ".");
                character.ChangeBaseStat(stats[i], value); 
            }// For Cycle

            character.UpdateStat(character.GetModifier("Dexterity"), "reflex");

            // Generating HP
            Console.WriteLine("\n---------------------------------");
            character.HPrnd();

            // Managing additional feats
            feat = character.GetBonusFeat();
            FeatsManager featManager = new FeatsManager();

            for (int i = 0; i < feat; i++)
            {
                string name = featManager.RandomFeat();    
                character.AddFeat(name);
            }

            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("Those are your feats!\n");
            character.PrintTalents();

            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("Spells!");
            character.PrintCastableSpells();



            return character;
        }
    }
}

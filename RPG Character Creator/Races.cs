using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    static class Races
    {
        public static void Combine(CharacterCombat cCombat, string race)
        {
            switch (race)
            {
                case "Dwarf":
                    cCombat.ChangeBaseStat("Constitution", 2);
                    cCombat.ChangeBaseStat("Charisma", -2);
                    break;
                case "Elf":
                    cCombat.ChangeBaseStat("Dexterity", 2);
                    cCombat.ChangeBaseStat("Constitution", -2);
                    break;
                case "Gnome":
                    cCombat.ChangeBaseStat("Constitution", 2);
                    cCombat.ChangeBaseStat("Strength", -2);
                    break;
                case "Halfling":
                    cCombat.ChangeBaseStat("Dexterity", 2);
                    cCombat.ChangeBaseStat("Strength", -2);
                    break;
                case "HalfOrc":
                    cCombat.ChangeBaseStat("Strength", 2);
                    cCombat.ChangeBaseStat("Intelligence", -2);
                    cCombat.ChangeBaseStat("Charisma", -2);
                    break;
                case "Human":
                    cCombat.AddBonusFeat();
                    break;
                default:
                    Console.WriteLine("Uhm, something went wrong. I'm not even sure of what went wrong, but we will fix it! ...or it's just a feature.");
                    break;
            }
        }
    }
}

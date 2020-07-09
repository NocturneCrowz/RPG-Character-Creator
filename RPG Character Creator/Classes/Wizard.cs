using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    class Wizard : CharacterCombat
    {
        private List<string> feats = new List<string> { "Summon Familiar", "Scribe Scroll" };
        private int hitDie = 4;
        private int lvl;

        public void PrintTalents()
        {
            feats.ForEach(action: Console.WriteLine);
        }// PrintTalents
        public void HPInfo()
        {
            Console.WriteLine("You just entered the Hit Point manager! What would you do?");
            Console.WriteLine("1- Print HP.");
            Console.WriteLine("2- Generate HP randomly.");
            Console.WriteLine("3- Insert HP value.");

            int res = 0;
            do
            {
                try
                {
                    res = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Uh oh, something went wrong.");
                }

                if (res < 1 || res > 3)
                {
                    Console.WriteLine("Sadly, that is not a valid enter. Please, try again.");
                }
                else
                {
                    switch (res)
                    {
                        case 1:
                            Console.WriteLine("The value of your HP is: " + GetStat("hp"));
                            break;
                        case 2:
                            Console.WriteLine("As you prefer! Randomly generating HP value, stand by!");
                            DiceRoll dice = new DiceRoll();
                            int hpUpdate = this.hitDie + GetModifier("Constitution");
                            UpdateStat(hpUpdate, "hp");
                            for (int i = 1; i < this.lvl; i++)
                            {
                                hpUpdate += dice.Roll(this.hitDie) + GetModifier("Constitution");
                            }
                            UpdateStat(hpUpdate, "hp");
                            Console.WriteLine("Your HP is: " + GetStat("hp"));
                            break;
                        case 3:
                            Console.WriteLine("Ok, insert now the value of your total HP: ");
                            UpdateStat(Convert.ToInt32(Console.ReadLine()), "hp");
                            break;
                        default:
                            break;
                    }
                }

            } while (res < 1 || res > 3);
        }// HPInfo
        public void AddFeat(string s)
        {
            this.feats.Add(s);
        }// AddFeat
        public Wizard(int lvl)
        {
            this.lvl = lvl;
            switch (lvl)
            {
                case 1:
                    UpdateStat(0, "fortitude");
                    UpdateStat(0, "reflex");
                    UpdateStat(2, "will");
                    UpdateStat(0, "bab");
                    AddSpell(3, "Level 0");
                    AddSpell(1, "Level 1");
                    break;
                case 2:
                    UpdateStat(0, "fortitude");
                    UpdateStat(0, "reflex");
                    UpdateStat(3, "will");
                    UpdateStat(1, "bab");
                    AddSpell(4, "Level 0");
                    AddSpell(2, "Level 1");
                    break;
                case 3:
                    UpdateStat(1, "fortitude");
                    UpdateStat(1, "reflex");
                    UpdateStat(3, "will");
                    UpdateStat(1, "bab");
                    AddSpell(4, "Level 0");
                    AddSpell(2, "Level 1");
                    AddSpell(1, "Level 2");
                    AddBonusFeat();
                    break;
                case 4:
                    UpdateStat(1, "fortitude");
                    UpdateStat(1, "reflex");
                    UpdateStat(4, "will");
                    UpdateStat(2, "bab");
                    AddSpell(4, "Level 0");
                    AddSpell(3, "Level 1");
                    AddSpell(2, "Level 2");
                    AddBonusFeat();
                    break;
                case 5:
                    UpdateStat(1, "fortitude");
                    UpdateStat(1, "reflex");
                    UpdateStat(4, "will");
                    UpdateStat(2, "bab");
                    AddSpell(4, "Level 0");
                    AddSpell(3, "Level 1");
                    AddSpell(2, "Level 2");
                    AddSpell(1, "Level 3");
                    AddBonusFeat();
                    AddBonusFeat();
                    break;
                default:
                    Console.WriteLine("Whoops. Something went wrong.");
                    break;
            }// Switch Case
        }// Costructor
    }// Class
}

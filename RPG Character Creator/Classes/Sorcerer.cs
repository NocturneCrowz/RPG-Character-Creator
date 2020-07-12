using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    class Sorcerer : CharacterCombat
    {
        private List<string> feats = new List<string> { "Summon Familiar" };
        private int hitDie = 4;
        private int lvl;

        public List<string> GetTalents()
        {
            return this.feats;
        }
        public void PrintTalents()
        {
            feats.ForEach(action: Console.WriteLine);
        }// PrintTalents
        public void HPInfo()
        {
            Console.WriteLine("How do you want to manage your HP value?");
            Console.WriteLine("1- Generate HP randomly.");
            Console.WriteLine("2- Insert HP value.");

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

                if (res < 1 || res > 2)
                {
                    Console.WriteLine("Sadly, that is not a valid enter. Please, try again.");
                }
                else
                {
                    switch (res)
                    {
                        case 1:
                            Console.WriteLine("Randomly generating HP value, stand by!");
                            DiceRoll dice = new DiceRoll();
                            int hpUpdate = this.hitDie + GetModifier("Constitution");
                            UpdateStat(hpUpdate, "hp");
                            for (int i = 1; i < this.lvl; i++)
                            {
                                Console.WriteLine("Your current HP is: " + hpUpdate + ". Rolling the " + (i + 1) + " dice.");
                                hpUpdate += dice.Roll(this.hitDie) + GetModifier("Constitution");
                            }
                            UpdateStat(hpUpdate, "hp");
                            Console.WriteLine("Your total HP is: " + GetStat("hp"));
                            break;
                        case 2:
                            Console.WriteLine("Ok, insert now the value of your total HP: ");
                            UpdateStat(Convert.ToInt32(Console.ReadLine()), "hp");
                            break;
                        default:
                            Console.WriteLine("Something happened, and your HP just vanished. Try again!");
                            break;
                    }
                }

            } while (res < 1 || res > 3);

        }// HPInfo
        public void HPrnd()
        {
            Console.WriteLine("Randomly generating HP value, stand by!");
            DiceRoll dice = new DiceRoll();
            int hpUpdate = this.hitDie + GetModifier("Constitution");
            UpdateStat(hpUpdate, "hp");
            for (int i = 1; i < this.lvl; i++)
            {
                hpUpdate += dice.Roll(this.hitDie) + GetModifier("Constitution");
            }
            UpdateStat(hpUpdate, "hp");
            Console.WriteLine("Your total HP is: " + GetStat("hp"));
        }// HPrnd
        public void AddFeat(string s)
        {
            this.feats.Add(s);
        }// AddFeat
        public Sorcerer(int lvl)
        {
            this.lvl = lvl;
            switch (lvl)
            {
                case 1:
                    UpdateStat(0, "fortitude");
                    UpdateStat(0, "reflex");
                    UpdateStat(2, "will");
                    UpdateStat(0, "bab");
                    AddSpell(5, "Level 0");
                    AddSpell(3, "Level 1");
                    break;
                case 2:
                    UpdateStat(0, "fortitude");
                    UpdateStat(0, "reflex");
                    UpdateStat(3, "will");
                    UpdateStat(1, "bab");
                    AddSpell(6, "Level 0");
                    AddSpell(4, "Level 1");
                    break;
                case 3:
                    UpdateStat(1, "fortitude");
                    UpdateStat(1, "reflex");
                    UpdateStat(3, "will");
                    UpdateStat(1, "bab");
                    AddSpell(6, "Level 0");
                    AddSpell(5, "Level 1");
                    AddBonusFeat();
                    break;
                case 4:
                    UpdateStat(1, "fortitude");
                    UpdateStat(1, "reflex");
                    UpdateStat(4, "will");
                    UpdateStat(2, "bab");
                    AddSpell(6, "Level 0");
                    AddSpell(6, "Level 1");
                    AddSpell(3, "Level 2");
                    AddBonusFeat();
                    break;
                case 5:
                    UpdateStat(1, "fortitude");
                    UpdateStat(1, "reflex");
                    UpdateStat(4, "will");
                    UpdateStat(2, "bab");
                    AddSpell(6, "Level 0");
                    AddSpell(6, "Level 1");
                    AddSpell(4, "Level 2");
                    AddBonusFeat();
                    break;
                default:
                    Console.WriteLine("Whoops. Something went wrong.");
                    break;
            }// Switch Case
        }// Costructor
    }// Class
}

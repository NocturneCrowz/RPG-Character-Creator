using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    class Barbarian : CharacterCombat
    {
        private List<string> feats = new List<string> {"Fast Movement", "Illiteracy", "Rage"};
        private int hitDie = 12;
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
        public Barbarian(int lvl)
        {
            this.lvl = lvl;
            switch (lvl)
            {
                case 1:
                    UpdateStat(2, "fortitude");
                    UpdateStat(0, "reflex");
                    UpdateStat(0, "will");
                    UpdateStat(1, "bab");
                    break;
                case 2:
                    UpdateStat(3, "fortitude");
                    UpdateStat(0, "reflex");
                    UpdateStat(0, "will");
                    UpdateStat(2, "bab");
                    this.feats.Add("Uncanny Dodge");
                    break;
                case 3:
                    UpdateStat(3, "fortitude");
                    UpdateStat(1, "reflex");
                    UpdateStat(1, "will");
                    UpdateStat(3, "bab");
                    AddBonusFeat();
                    this.feats.Add("Uncanny Dodge");
                    break;
                case 4:
                    UpdateStat(4, "fortitude");
                    UpdateStat(1, "reflex");
                    UpdateStat(1, "will");
                    UpdateStat(4, "bab");
                    this.feats.Add("Uncanny Dodge");
                    AddBonusFeat();
                    break;
                case 5:
                    UpdateStat(5, "fortitude");
                    UpdateStat(1, "reflex");
                    UpdateStat(1, "will");
                    UpdateStat(5, "bab");
                    this.feats.Add("Uncanny Dodge");
                    this.feats.Add("Improved Uncanny Dodge");
                    AddBonusFeat();
                    break;
                default:
                    Console.WriteLine("Whoops. Something went wrong.");
                    break;
            }// Switch Case
        }// Costructor
    }// Class
}

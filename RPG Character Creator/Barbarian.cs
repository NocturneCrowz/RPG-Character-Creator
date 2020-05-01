using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    class Barbarian : CharacterCombat
    {
        private List<string> baseTalents = new List<string> {"Fast Movement", "Illiteracy", "Rage" };
        private int hitDie = 12;
        private int hp;
        private int lvl;
        public void PrintTalents()
        {
            baseTalents.ForEach(action: Console.WriteLine);
        }// PrintTalents
        public void UpdateHP()
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
                            Console.WriteLine("The value of your HP is: " + this.hp);
                            break;
                        case 2:
                            Console.WriteLine("As you prefer! Randomly generating HP value, stand by!");
                            DiceRoll dice = new DiceRoll();
                            this.hp = 0;
                            for (int i = 0; i < this.lvl; i++)
                            {
                                this.hp += dice.Roll(this.hitDie) + GetModifier("Constitution");
                                Console.WriteLine(GetModifier("Constitution"));
                                Console.WriteLine(this.hp);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Ok, insert now the value of your total HP: ");
                            this.hp = Convert.ToInt32(Console.ReadLine());
                            break;
                        default:
                            break;
                    }
                }

            } while (res < 1 || res > 3);




        }
        public Barbarian(int lvl)
        {
            this.lvl = lvl;
            switch (lvl)
            {
                case 1:
                    UpdateStat(2, "fortitude");
                    break;
                case 2:
                    UpdateStat(3, "fortitude");
                    this.baseTalents.Add("Uncanny Dodge");
                    break;
                case 3:
                    UpdateStat(3, "fortitude");
                    UpdateStat(1, "reflex");
                    UpdateStat(1, "will");
                    this.baseTalents.Add("Uncanny Dodge");
                    break;
                case 4:
                    UpdateStat(4, "fortitude");
                    UpdateStat(1, "reflex");
                    UpdateStat(1, "will");
                    this.baseTalents.Add("Uncanny Dodge");
                    break;
                case 5:
                    UpdateStat(5, "fortitude");
                    UpdateStat(1, "reflex");
                    UpdateStat(1, "will");
                    this.baseTalents.Add("Uncanny Dodge");
                    this.baseTalents.Add("Improved Uncanny Dodge");
                    break;
                default:
                    Console.WriteLine("Whoops. Something went wrong.");
                    break;
            }// Switch Case
        }// Costructor
    }// Class
}

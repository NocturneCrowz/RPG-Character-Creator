﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    class Barbarian : CharacterCombat
    {
        private List<string> feats = new List<string> {"Fast Movement", "Illiteracy", "Rage"};
        private int hitDie = 12;
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

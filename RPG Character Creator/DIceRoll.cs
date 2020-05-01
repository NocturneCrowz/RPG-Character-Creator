using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    class DiceRoll
    {
        // Random number
        private Random rnd = new Random();

        // Rolling a dice with the previous random number as the maximum
        public int Roll(int n)
        {
            int res;
            if (n >= 1)
            {
                res = this.rnd.Next(1, n);
            }
            else
            { 
                res = -1;
            }

            return res;    
        } //Roll

        public int RollAndPrint(int n)
        {
            int res;
            if (n >= 1)
            {
                Console.WriteLine("Rolling a d" + n + " dice!");
                res = this.rnd.Next(1, n);
            }
            else
            {
                res = -1;
            }

            return res;
        }
    } //Class
} //Namespace

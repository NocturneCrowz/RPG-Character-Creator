using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    class DiceRoll
    {
        // Random number
        private Random rnd = new Random();

        // Rolling a dice 
        public int Roll(int n)
        {
            int res;
            if (n >= 1)
            {
                res = this.rnd.Next(1, n);
            }
            else
            { 
                res = 0;
            }

            return res;    
        }// Roll
    } //Class
} //Namespace

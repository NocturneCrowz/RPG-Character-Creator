using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator.Races
{
    class Human
    {
        public Human(CharacterCombat charClass)
        {
            charClass.AddBonusFeat();
        }
    }
}

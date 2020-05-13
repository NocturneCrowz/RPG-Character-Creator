using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    class Dwarf
    {
        public Dwarf(CharacterCombat charClass)
        {
            charClass.ChangeBaseStat("Constitution", 2);
            charClass.ChangeBaseStat("Charisma", -2);
        }
    }
}

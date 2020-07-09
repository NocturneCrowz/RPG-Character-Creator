using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    static class GuidedGenerator
    {
        public static void Generate()
        {
            int value = 0;
            int res = 0;
            Console.WriteLine("Welcome to the Guided Generation! My name is... well, I don't have a name, but it's fine anyway!");
            Console.WriteLine("Now I will walk you through che creation of a new D&D character! Now, where did i put.....");
            Console.WriteLine("...");
            Console.WriteLine("Yes, found it. First, I need to know what class you want to be. Classes are what specialize you, and we have a lot of them!.");
            Console.WriteLine("Do you want to be a mighty Paladin? We got it! A wise Wizard? Check. A sneaky Rogue? Just don't try to steal my code...");
            Console.WriteLine("Now now, let's start. We have those classes avaibles, so pick carefully:\n1) Barbarian\n2) Bard\n3) Cleric\n4) Druid\n5) Fighter\n6) Monk\n7) Paladin\n8) Ranger\n9) Rogue\n10) Sorcerer\n11) Wizard");
            value = Convert.ToInt32(Console.ReadLine());
            do
            {

            }
            while (res == 0);
            switch (value)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                default:
                    break;
            }
        }
    }
}

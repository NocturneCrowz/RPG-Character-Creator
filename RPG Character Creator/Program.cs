using System;
using System.IO;
using System.Linq;

namespace RPG_Character_Creator
{
    class Program
    {
        static void Main(string[] args)
        {
            // dice roll
            /* DiceRoll rnd = new DiceRoll();
             int diceRoll = -1;
             Console.WriteLine("Choose a number:");
             do
             {
                 int value = 0;
                 try
                 {
                     value = Convert.ToInt32(Console.ReadLine());
                 }
                 catch (FormatException)
                 {
                     Console.WriteLine("It seems like you tried to insert one or more letters instead of an integer. You can't do that!");
                     Console.WriteLine();
                 }
                 catch (OverflowException)
                 {
                     Console.WriteLine("It seems like something went wrong. Try contacting the developer, but he won't know much more.");
                     Console.WriteLine();
                 }
                 finally
                 {
                     diceRoll = rnd.Roll(value);
                     if (diceRoll == -1)
                     {
                         Console.WriteLine("Whoops! Your dice has fallen into a blackhole, recover it and try again! Choose a number: ");
                     }
                 }
             } while (diceRoll == -1);

             Console.WriteLine(diceRoll);*/
            Console.WriteLine("Path");
            string path = Console.ReadLine();

            Console.WriteLine("Feat");
            SearchAFeat search = new SearchAFeat(path);
            search.SAF(Console.ReadLine());
           
            
            

        }
    }
}

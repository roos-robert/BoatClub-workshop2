using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.view
{
    class BoatView
    {
        private static void ContinueOnKeyPressed()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nTryck på en tangent för att fortsätta!\n");
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.ReadKey(true);
            Console.Clear();
            Console.CursorVisible = true;
        }

        private static int ViewBoatMenu()
        {
            int menuIndex;

            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Båtmenyn");
                Console.WriteLine("\n -------------------------------------------\n");
                Console.WriteLine(" 0: Återgå till huvudmeny");
                Console.WriteLine(" 1: Registrera ny båt");
                Console.WriteLine(" 2: Redigera båt");
                Console.WriteLine(" 3: Ta bort båt");
                Console.Write(" Ange menyval [0-3]");

                if (int.TryParse(Console.ReadLine(), out menuIndex) && menuIndex >= 0 && menuIndex <= 5)
                {
                    return menuIndex;
                }
                else
                {
                    Console.Write("\nVänligen ange ett nummer mellan 0 och 5.\n", ConsoleColor.Red);
                    ContinueOnKeyPressed();
                }
            } while (true);
        }
    }
}

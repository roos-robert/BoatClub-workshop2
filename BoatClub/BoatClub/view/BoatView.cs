using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.model;

namespace BoatClub.view
{
    class BoatView
    {
        MainMenuView mainMenuView = new MainMenuView();
        Boat boatModel = new Boat();

        private enum MenuChoice
        {
            ExitMenu = 0,
            AddBoat = 1,
            HandleBoat = 2,
            RemoveBoat = 3,
        }

        public void BoatMenu()
        {
            while(true)
            {
                int menuChoice = ViewBoatMenu();

                switch (menuChoice)
                {
                    case(int)MenuChoice.ExitMenu:
                        mainMenuView.InitMenu();
                        return;
                    case(int)MenuChoice.AddBoat:                        
                        return;
                    case(int)MenuChoice.HandleBoat:
                        return;
                    case(int)MenuChoice.RemoveBoat:
                        return;
                    default:
                        break;
                }
            }
        }
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

        public int ViewBoatMenu()
        {
            int menuIndex;

            do
            {
                Console.Clear();
                Console.WriteLine("Hantera båtar");
                Console.WriteLine("\n -------------------------------------------\n");
                Console.WriteLine(" 0: Återgå till huvudmeny");
                Console.WriteLine(" 1: Registrera ny båt");
                Console.WriteLine(" 2: Redigera båt");
                Console.WriteLine(" 3: Ta bort båt\n");
                Console.Write(" Ange menyval [0-3]: ");

                if (int.TryParse(Console.ReadLine(), out menuIndex) && menuIndex >= 0 && menuIndex <= 3)
                {
                    return menuIndex;
                }
                else
                {
                    Console.Write("\nVänligen ange ett nummer mellan 0 och 3.\n", ConsoleColor.Red);
                    ContinueOnKeyPressed();
                }
            } while (true);
        }
    }
}

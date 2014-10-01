using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.model;
using BoatClub.view;

namespace BoatClub
{
    class Program
    {
        private enum MenuChoice
        {
            ExitConsole = 0,
            AddMember = 1,
            ListMembersSimple = 2,
        }

        static void Main(string[] args)
        {
            User userModel = new User();
            Boat boatModel = new Boat();

            BoatView boatView = new BoatView();
            UserView userView = new UserView();

            while (true)
            {
                int menuChoice = ViewMainMenu();

                switch (menuChoice)
                {
                    case (int)MenuChoice.ExitConsole:
                        return;
                    case (int)MenuChoice.AddMember:
                        userView.AddUser(userModel);
                        return;
                    case (int)MenuChoice.ListMembersSimple:
                        userView.RemoveUser(userModel);
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

        private static int ViewMainMenu()
        {
            int menuIndex;

            do
            {
                Console.Clear();
                Console.WriteLine("Båtklubben sista färden");
                Console.WriteLine("\n - Arkiv -------------------------------------------\n");
                Console.WriteLine(" 0: Avslutar programmet");
                Console.WriteLine(" 1: Lägg till medlem");
                Console.WriteLine(" 2: Enkel lista över medlemmar");
                Console.WriteLine(" 3: Fullständig lista över medlemmar");                                         
                Console.Write(" Ange menyval [0-3]: ");

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

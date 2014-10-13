using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.model;

namespace BoatClub.view
{
    
    class MainMenuView
    {
        User userModel = new User();
        Boat boatModel = new Boat();

        BoatView boatView = new BoatView();
        UserView userView = new UserView();

        private enum MenuChoice
        {
            ExitConsole = 0,
            AddMember = 1,
            RemoveMember = 2,
            HandleMember = 3,
            ShowUser = 4,
            ListMembersSimple = 5,
            ListMembersFull = 6,
            HandleBoats = 7,
        }

        public void InitMenu()
        {
            while (true)
            {
                int menuChoice = ViewMainMenu();

                switch (menuChoice)
                {
                    case (int)MenuChoice.ExitConsole:
                        Environment.Exit(0);
                        return;
                    case (int)MenuChoice.AddMember:
                        userView.AddUser(userModel);
                        return;
                    case (int)MenuChoice.RemoveMember:
                        userView.RemoveUser(userModel);
                        return;
                    case (int)MenuChoice.HandleMember:
                        userView.UpdateUser(userModel);
                        return;
                    case (int)MenuChoice.ShowUser:
                        userView.ShowUser(userModel, boatModel);
                        return;
                    case (int)MenuChoice.ListMembersSimple:
                        userView.ShowUsersSimple(userModel, boatModel);
                        return;
                    case (int)MenuChoice.ListMembersFull:
                        userView.ShowUsersFull(userModel, boatModel);
                        return;
                    case (int)MenuChoice.HandleBoats:
                        boatView.BoatMenu();
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
                Console.WriteLine(" 2: Radera medlem");
                Console.WriteLine(" 3: Hantera medlem");
                Console.WriteLine(" 4: Visa medlem");
                Console.WriteLine(" 5: Enkel lista över medlemmar");
                Console.WriteLine(" 6: Fullständig lista över medlemmar");
                Console.WriteLine(" 7: Hantera båtar\n");
                Console.Write(" Ange menyval [0-6]: ");

                if (int.TryParse(Console.ReadLine(), out menuIndex) && menuIndex >= 0 && menuIndex <= 6)
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
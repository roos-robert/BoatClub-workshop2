using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.view
{
    class UserView
    {
        // Fields

        // Properties

        // Methods

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

        public void AddUser()
        {
            
            Console.WriteLine("Lägg till medlem.");
            Console.ReadKey();
        }

        public void UpdateUser()
        {

        }

        public void RemoveUser()
        {
            
        }

        public void ShowUser()
        {
            
        }

        public void ShowUsersSimple()
        {

        }

        public void ShowUsersFull()
        {

        }

        // Constructor
        public UserView()
        {
            // TOM!
        }
    }
}

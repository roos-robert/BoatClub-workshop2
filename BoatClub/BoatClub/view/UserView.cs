using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.model;

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

        public void AddUser(User userModel)
        {
            string name;
            int socialSecurity;

            Console.Clear();
            Console.WriteLine("Lägg till medlem.\n");
            Console.Write("Ange namn: ");
            name = Console.ReadLine();

            while (true)
            {
                try
                {
                    Console.Write("\nAnge personnummer: ");
                    socialSecurity = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ange ett korrekt personnummer!");
                }
            }

            try
            {
                userModel.AddUser(name, socialSecurity);
                Console.WriteLine("\nTack! Medlemmen har nu lagts till i registret!");
            }
            catch (Exception)
            {
                Console.WriteLine("\nOj! Något gick snett, försök igen.");
            }
            
            ContinueOnKeyPressed();
        }

        public void UpdateUser(User userModel)
        {
            int memberId;
            Console.Clear();
            Console.WriteLine("Hantera medlem.\n");

            while (true)
            {
                try
                {
                    Console.Write("\nAnge medlemsid: ");
                    memberId = Int32.Parse(Console.ReadLine());
                    try
                    {
                        // TODO get user
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ange en existerande medlem!");
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Ange ett korrekt medlemsid!");
                }
            }

            // TODO menu where user can choose to update info or add a boat


            ContinueOnKeyPressed();
        }

        public void RemoveUser(User userModel)
        {
            int memberId;
            Console.Clear();
            Console.WriteLine("Radera medlem.\n");

            while (true)
            {
                try
                {                    
                    Console.Write("\nAnge medlemsid: ");
                    memberId = Int32.Parse(Console.ReadLine());
                    try
                    {
                        userModel.RemoveUser(memberId);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ange en existerande medlem!");
                    }
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("Ange ett korrekt medlemsid!");
                }                
            }

            Console.WriteLine("Medlemmen har raderats ur registret!");
            ContinueOnKeyPressed();
        }

        public void ShowUser()
        {

        }

        public void ShowUsersSimple(User userModel, Boat boatModel)
        {
            Console.Clear();

            IEnumerable<User> users = userModel.ShowUsersSimple();

            foreach(var user in users)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Namn: {0}\n", user.Name);
                Console.WriteLine("ID: {0}\n", user.MemberId);
                Console.WriteLine("Personnummer: {0}\n", user.SocialSecurity);
                Console.WriteLine("Antal båtar: {0}", boatModel.NumberOfBoats(user.MemberId));
                Console.WriteLine("------------------------------\n");
            }        

            ContinueOnKeyPressed();
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

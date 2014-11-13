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
            double socialSecurity;

            Console.Clear();
            Console.WriteLine("Lägg till medlem.\n");
            Console.Write("Ange namn: ");
            name = Console.ReadLine();

            while (true)
            {
                try
                {
                    Console.Write("\nAnge personnummer (10 siffror): ");
                    socialSecurity = Double.Parse(Console.ReadLine());

                    if(socialSecurity.ToString().Length != 10)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

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
            string name;
            int socialSecurity;
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
                        userModel.GetUser(memberId);
                    }
                    catch
                    {
                        Console.WriteLine("\nAnge ett korrekt medlemsid!:");
                        ContinueOnKeyPressed();
                        return;
                    }

                    Console.Write("\nAnge namn: ");
                    name = Console.ReadLine();

                    try
                    {
                        Console.Write("\nAnge personnummer, eller lämna blankt om det inte ska ändras: ");
                        socialSecurity = Int32.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        socialSecurity = 0;
                    }
                    userModel.UpdateUser(memberId, name, socialSecurity);
                    Console.WriteLine("Medlemmen är uppdaterad!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Ange ett korrekt medlemsid!");
                }

                ContinueOnKeyPressed();
                break;
            }

            // TODO menu where user can choose to update info or add a boat
            
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
                        ContinueOnKeyPressed();
                        return;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Ange ett korrekt medlemsid!");
                    ContinueOnKeyPressed();
                    return;
                }
            }

            Console.WriteLine("Medlemmen har raderats ur registret!");
            ContinueOnKeyPressed();
        }

        public void ShowUser(User userModel, Boat boatModel)
        {
            int memberId;
            
            Console.Clear();
            Console.Write("Ange medlemsid på den medlem du vill kolla på : ");
            memberId = Int32.Parse(Console.ReadLine());

            User user = userModel.GetUser(memberId);
                        
                if(memberId == user.MemberId)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Namn: {0}, ID: {1}, Personnummer: {2}\n", user.Name, user.MemberId, user.SocialSecurity);

                    foreach (var boat in user.UserBoats)
                    {
                        Console.WriteLine("------");
                        Console.WriteLine("Båtens ID: {0}", boat.BoatId);
                        Console.WriteLine("Båttyp: {0}", boat.BoatType);
                        Console.WriteLine("Båtens längd: {0} meter", boat.Length);
                        Console.WriteLine("------");
                    }
                }
            
            ContinueOnKeyPressed();
        }

        public void ShowUsersFull(User userModel, Boat boatModel)
        {
            Console.Clear();

            IEnumerable<User> users = userModel.ShowUsersSimple();        

            foreach (var user in users)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Namn: {0}, ID: {1}, Personnummer: {2}\n", user.Name, user.MemberId, user.SocialSecurity);
                //Removed the number of boats since all boats belonging to that member will be listed anyway
                //Console.WriteLine("Antal båtar: {0}", boatModel.NumberOfBoats(user.MemberId));
                var boats = boatModel.GetAllUserBoats(user.MemberId);
                foreach (var boat in boats)
                {
                    Console.WriteLine("------");
                    Console.WriteLine("Båtens ID: {0}", boat.BoatId);
                    Console.WriteLine("Båttyp: {0}", boat.BoatType);
                    Console.WriteLine("Båtens längd: {0} meter", boat.Length);
                    Console.WriteLine("------");
                }
                Console.WriteLine("------------------------------\n");
            }

            ContinueOnKeyPressed();
        }

        public void ShowUsersSimple(User userModel, Boat boatModel)
        {
            Console.Clear();

            IEnumerable<User> users = userModel.ShowUsersSimple();

            foreach (var user in users)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Namn: {0}, ID: {1}, Antal båtar: {2}\n", user.Name, user.MemberId, user.UserBoats.Count);
                Console.WriteLine("------------------------------\n");
            }

            ContinueOnKeyPressed();
        }

        // Constructor
        public UserView()
        {
            // TOM!
        }
    }
}
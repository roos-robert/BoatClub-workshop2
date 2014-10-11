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
        static void Main(string[] args)
        {
            while(true)
            {
                MainMenuView mainMenuView = new MainMenuView();
                mainMenuView.InitMenu();
            }            
        }      
    }
}
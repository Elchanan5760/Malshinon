using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Menu;

namespace Malshinon.Menu
{
    public class MainMenu
    {
        public void ChooseMenu()
        {
            Console.WriteLine("=====Menu=====\n" +
                "1. To add or update row\n" +
                "0. Exit");
            string choose = Console.ReadLine();
            bool cond = true;
            do
            {
                switch (choose)
                {
                    case "1":
                        Operations peopleMenu = new Operations();
                        peopleMenu.Navigation();
                        break;
                    case "0":
                        cond = false;
                        break;
                    default:
                        Console.WriteLine("Your valid is not exist please try again");
                        break;
                }
            }
            while (cond);
        }
    }
}

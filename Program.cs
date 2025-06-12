using Malshinon.Dal;
using Malshinon.DAL;
using Malshinon.Menu;
using Malshinon.models;
namespace Malshinon
{
    public class Program
    {
        static public void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.ChooseMenu();
        }
    }
}
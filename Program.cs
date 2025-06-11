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
            Menu.Menu peopleMenu = new Menu.Menu();
            peopleMenu.Navigation();
            //PeopleDAL peopleDAL = new PeopleDAL();
            //peopleDAL.UpdatePeopleValueString(2, "type", "both");
            //IntelReportRow intelReportRow = new IntelReportRow();
            //intelReportRow.ConstractorReport(2, 3, "5trtje");
            //IntelReportDAL intelReportDAL = new IntelReportDAL();
            //intelReportDAL.AddRowReports(intelReportRow);
        }
    }
}
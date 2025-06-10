using Malshinon.Dal;
using Malshinon.models;
namespace Malshinon
{
    public class Program
    {
        static public void Main(string[] args)
        {
            PeopleRow peopleRow = new PeopleRow();
            
            peopleRow.FirstName = "mohamad";
            peopleRow.LastName = "hasan";
            peopleRow.SecretCode = "67ryurvcfu";
            peopleRow.Type = "reporter";
            PeopleDAL dAL = new PeopleDAL();
            //dAL.AddRowPeople(peopleRow);
            dAL.DeletePeopleRow(1);
        }
    }
}
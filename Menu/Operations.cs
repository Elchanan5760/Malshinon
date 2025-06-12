using Malshinon.Dal;
using Malshinon.DAL;
using Malshinon.models;
using Org.BouncyCastle.Asn1.X509.SigI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Menu
{
    public class Operations
    {
        PeopleDAL peopleDAL = new PeopleDAL();
        IntelReportDAL intelReportDAL = new IntelReportDAL();
        public string GetSecretCode()
        {
            Console.WriteLine("Please enter your secret code:");
            string sec = Console.ReadLine();
            return sec;
        }
        public void Navigation()
        {
            string secretCode = GetSecretCode();
            PeopleRow person = peopleDAL.FindPeopleBySecretCode(secretCode);
            if (person == null)
            {
                CreatNewPersonReporter(secretCode);
            }
            else
            {
                if (person.type == "target")
                {
                    peopleDAL.UpdatePeopleValueString(person.id, "type", "both");
                    Console.WriteLine($"{person.firstName} {person.lastName} is {person.type}");
                }
                EnterText(peopleDAL.FindPeopleBySecretCode(secretCode));
            }
        }
        public void CreatNewPersonReporter(string secretCode)
        {
            
            Console.WriteLine("Please enter your first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name");
            string lastName = Console.ReadLine();
            string type = "reporter";
            PeopleRow peopleRow = new PeopleRow();
            peopleRow.ConstractorPerson(firstName,lastName,secretCode,type);
            peopleDAL.AddRowPeople(peopleRow);
            Console.WriteLine($"New person reporter Named {firstName} {lastName} created!");
            PeopleRow achieveTheDefultValues = peopleDAL.FindPeopleBySecretCode(secretCode);
            peopleRow.ConstractorDefultValuesPerson(achieveTheDefultValues.id, achieveTheDefultValues.numReports, achieveTheDefultValues.numMentions);
            EnterText(peopleRow);
        }
        public void ChangeType(string type)
        {
            
        }
        public PeopleRow CreatNewPersonTarget(string secretCode)
        {

            Console.WriteLine("Please enter his first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter his last name");
            string lastName = Console.ReadLine();
            PeopleRow peopleRow = new PeopleRow();
            peopleRow.ConstractorPerson(firstName, lastName,secretCode , "target");
            PeopleRow people = peopleDAL.AddRowPeople(peopleRow);
            PeopleRow achieveTheDefultValues = peopleDAL.FindPeopleBySecretCode(secretCode);
            people.ConstractorDefultValuesPerson(achieveTheDefultValues.id,achieveTheDefultValues.numReports,achieveTheDefultValues.numMentions);
            Console.WriteLine($"New person target Named {firstName} {lastName} created!");
            return people;
        }
        public void ExistingPerson()
        {

        }
        public void EnterText(PeopleRow person)
        {
            IntelReportRow intelReportRow = new IntelReportRow();
            
            Console.WriteLine("Please enter his secret code:");
            string secretCode = Console.ReadLine();
            Console.WriteLine("What do you want to report:");
            string text = Console.ReadLine();
            PeopleRow targetPerson = new PeopleRow();
            if (peopleDAL.FindPeopleBySecretCode(secretCode) == null)
            {
                 targetPerson = CreatNewPersonTarget(secretCode);
            }
            else
            {
                
                targetPerson = peopleDAL.FindPeopleBySecretCode(secretCode);
                
                if (targetPerson.type == "reporter")
                {
                    peopleDAL.UpdatePeopleValueString(targetPerson.id, "type", "both");
                    Console.WriteLine($"{targetPerson.firstName} {targetPerson.lastName} is {targetPerson.type}");
                }
            }
            
            peopleDAL.UpdatePeopleValueInt(targetPerson.id, "num_mentions", targetPerson.numMentions + 1);
            peopleDAL.UpdatePeopleValueInt(person.id, "num_reports", person.numReports + 1);
            intelReportRow.ConstractorReport(person.id,targetPerson.id,text);
            intelReportDAL.AddRowReports(intelReportRow);
            if (targetPerson.numMentions >= 20)
            {
                Console.WriteLine($"{targetPerson.firstName} {targetPerson.lastName} can be dangerius!");
            }
            List<IntelReportRow> allReports = intelReportDAL.GetAllReports();
            int caont = 0;
            int sum = 0;
            foreach(IntelReportRow report in allReports)
            {
                sum += report.text.Length;
                caont++;
            }
            if (caont != 0)
            {
                if (person.numReports >= 10 && sum / caont >= 100)
                {
                    peopleDAL.UpdatePeopleValueString(person.id, "type", "potential_agent");
                    Console.WriteLine($"{person.firstName} {person.lastName} is {person.type}");
                }
            }
        }
        
    }
}

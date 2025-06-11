using Malshinon.Dal;
using Malshinon.DAL;
using Malshinon.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Menu
{
    public class Menu
    {
        PeopleDAL peopleDAL = new PeopleDAL();
        public string GetSecretCode()
        {
            Console.WriteLine("Please enter your secret code:");
            string sec = Console.ReadLine();
            return sec;
        }
        public void Navigation()
        {
            string secretCode = GetSecretCode();
            if (peopleDAL.FindPeopleBySecretCode(secretCode) == null)
            {
                CreatNewPersonReporter(secretCode);
            }
            else
            {
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
        public PeopleRow CreatNewPersonTarget(int id)
        {

            Console.WriteLine("Please enter his first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter his last name");
            string lastName = Console.ReadLine();
            PeopleRow peopleRow = new PeopleRow();
            peopleRow.ConstractorPerson(firstName, lastName,null , "target");
            PeopleRow people = peopleDAL.AddRowPeople(peopleRow);
            PeopleRow achieveTheDefultValues = peopleDAL.FindPeopleById(id);
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
            IntelReportDAL intelReportDAL = new IntelReportDAL();
            int intTargetId = 0;
            bool cond = true;
            do
            {
                Console.WriteLine("What is an id of who do you want to report about");
                string targetId = Console.ReadLine();
                
                foreach (char c in targetId)
                {
                    if (!char.IsDigit(c))
                    {
                        cond = false;
                    }
                    else
                    {
                        cond = true;
                    }
                }
                if (cond)
                {
                    intTargetId = Convert.ToInt32(targetId);
                }
                else
                {
                    Console.WriteLine("It needs to be only numbers please try again");
                }
            }
            while (!cond);
            Console.WriteLine("please enter your report");
            string report = Console.ReadLine();
           
            IntelReportRow intel = new IntelReportRow();
            intel.ConstractorReport(person.id,intTargetId,report);
            if (peopleDAL.FindPeopleById(intTargetId) == null)
            {
                var targetPerson = CreatNewPersonTarget(intTargetId);
                
                intelReportRow.ConstractorReport(person.id, targetPerson.id, report);
                peopleDAL.UpdatePeopleValueInt(targetPerson.id, "num_mentions", person.numMentions + 1);
                peopleDAL.UpdatePeopleValueInt(person.id, "num_reports", person.numReports + 1);
                if (person.type == "target")
                {
                    peopleDAL.UpdatePeopleValueString(person.id, "type", "both");
                }
                
                intelReportDAL.AddRowReports(intelReportRow);
            }
            else
            {
                var targetPerson = peopleDAL.FindPeopleById(intTargetId);
                intelReportRow.ConstractorReport(person.id, intTargetId, report);
                peopleDAL.UpdatePeopleValueInt(targetPerson.id, "num_mentions", person.numMentions + 1);
                peopleDAL.UpdatePeopleValueInt(person.id, "num_reports", person.numReports + 1);
                if (person.type == "reporter")
                {
                    peopleDAL.UpdatePeopleValueString(person.id, "type", "both");
                }
                else if (targetPerson.type == "target")
                {
                    peopleDAL.UpdatePeopleValueString(targetPerson.id, "type", "both");
                }
                intelReportDAL.AddRowReports(intelReportRow);
            }
        }
    }
}

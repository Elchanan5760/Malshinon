using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.models
{
    public class PeopleRow
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SecretCode { get; set; }

        public string Type { get; set; }

        public int NumReports { set; get; }

        public int NumMentions { set; get; }

        //public (string,string) GetTableNmaeAndValue()
        //{
        //    return ("people", firstName);
        //}
        //public (string, int) GetIdAndValue()
        //{
        //    return ("id", Id);
        //}

    }
}

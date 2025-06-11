using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.models
{
    public class PeopleRow
    {
        public int id { get;private set; }
        public string firstName { get; private set; }

        public string lastName { get; private set; }

        public string secretCode { get; private set; }

        public string type { get; private set; }

        public int numReports { get; private set; }

        public int numMentions { get; private set; }

        public void ConstractorPerson(string firstName, string lastName, string secretCode, string type)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.secretCode = secretCode;
            this.type = type;
        }
        public void ConstractorDefultValuesPerson(int id,int numReporters, int numMentions)
        {
            this.id = id;
            this.numReports = numReporters;
            this.numMentions = numMentions;
        }
    }
}

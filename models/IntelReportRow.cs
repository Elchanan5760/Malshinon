using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.models
{
    public class IntelReportRow
    {
        public int id { private set; get; }
        public int reporterId {private set; get; }
        public int targetId { private set; get; }
        public string text { private set; get; }
        public DateTime timeStamp { private set; get; }
        public void ConstractorReport(int reporterId, int targetId, string text)
        {
            this.reporterId = reporterId;
            this.targetId = targetId;
            this.text = text;
        }
        public void ConstractorDefultValues(int id,DateTime timeStamp)
        {
            this.id = id;
            this.timeStamp = timeStamp;
        }
    }
}

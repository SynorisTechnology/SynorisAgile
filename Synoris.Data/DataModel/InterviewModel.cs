using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synoris.Data.DataModel
{
    public class InterviewModel
    {
        public int InterviewID { get; set; }
        public string CandidateName { get; set; }
        public string Phone { get; set; }
        public string JobForApply { get; set; }
        public string JobPortal { get; set; }
        public Nullable<System.DateTime> InterviewDate { get; set; }
        public string Time { get; set; }
        public Nullable<decimal> CurrentCTC { get; set; }
        public string Experience { get; set; }
        public string Feedback { get; set; }
    }
}

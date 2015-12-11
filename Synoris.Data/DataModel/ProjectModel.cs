using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synoris.Data.DataModel
{
    public class ProjectModel
    {
        public int ProjectID { get; set; }
        public string ProjectTitle { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> DeadLine { get; set; }
        public string StartDateSt { get; set; }
        public string EndDateSt { get; set; }
        public string Status { get; set; }
        public Nullable<bool> Tracker { get; set; }
        public string DeadLineSt { get; set; }
        public string BitBucketUrl { get; set; }
        public string SVN { get; set; }
        public string ClientInfo { get; set; }
        public string ProjectPassword { get; set; }
        public Nullable<int> Targated { get; set; }
        public Nullable<decimal> Budget { get; set; }
        public string DemoUrl { get; set; }
        public string ProductionUrl { get; set; }
        public string ProjectTech { get; set; }

       
    }
}
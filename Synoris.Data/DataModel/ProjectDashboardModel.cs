using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synoris.Data.DataModel
{
    public class ProjectDashboardModel
    {
        public int ProjectID { get; set; }
        public string ProjectTitle { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
        public Nullable<bool> Tracker { get; set; }
        public Nullable<System.DateTime> DealLine { get; set; }
        public string BitBucketUrl { get; set; }
        public string SVN { get; set; }
        public string ClientInfo { get; set; }
        public string ProjectPassword { get; set; }
        public Nullable<int> Targated { get; set; }
        public Nullable<decimal> Budget { get; set; }
        public string ReourceName { get; set; }
        public List<ResourceModel> ResourceList { get; set; }
        public string DemoUrl { get; set; }
        public string ProductionUrl { get; set; }
        public string ProjectTech { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synoris.Data.DataModel
{
    public class ResourceModel
    {
        public int ResourceID { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public string EmpCode { get; set; }
        public Nullable<System.DateTime> CrDate { get; set; }
        public string CrBy { get; set; }
    }
}

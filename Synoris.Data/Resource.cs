//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Synoris.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Resource
    {
        public Resource()
        {
            this.ProjectResources = new HashSet<ProjectResource>();
        }
    
        public int ResourceID { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public string EmpCode { get; set; }
        public Nullable<System.DateTime> CrDate { get; set; }
        public string CrBy { get; set; }
        public Nullable<int> DepartmentId { get; set; }
    
        public virtual ICollection<ProjectResource> ProjectResources { get; set; }
        public virtual Department Department { get; set; }
    }
}

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
    
    public partial class Project
    {
        public int ProjectID { get; set; }
        public string ProjectTitle { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Status { get; set; }
        public Nullable<bool> Tracker { get; set; }
        public Nullable<System.DateTime> DeadLine { get; set; }
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

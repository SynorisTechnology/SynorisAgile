﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SynoProjectDBEntities : DbContext
    {
        public SynoProjectDBEntities()
            : base("name=SynoProjectDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ProjectResource> ProjectResources { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Payslip> Payslips { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Interview> Interviews { get; set; }
    }
}

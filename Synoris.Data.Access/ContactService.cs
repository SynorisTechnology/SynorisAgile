using AutoMapper;
using Synoris.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Synoris.Data.Access.Helper;
namespace Synoris.Data.Access
{
    public interface IContactService
    {
        int AddContact(ContactModel reso);
        //int EditProject(ProjectModel reso);
        //List<ProjectModel> AllProject();
        //ProjectModel GetProject(int projectID);
        //List<ProjectModel> GetProject(string name);
        //List<ProjectDashboardModel> GetProjectDashboard();
    }
    public class ContactService : IContactService
    {
        #region Private Fields
        private readonly LogHelper lhelper;
        private readonly SynoProjectDBEntities DBContext;
        #endregion
        public ContactService()
        {           
            DBContext = new SynoProjectDBEntities();
        }
        public int AddContact(ContactModel proj)
        {
            int ret = 0;
            try
            {
                using (SynoProjectDBEntities context = new SynoProjectDBEntities())
                {

                    Mapper.CreateMap<ContactModel, Contact>();
                    var mdl = Mapper.Map<ContactModel, Contact>(proj);
                    context.Contacts.Add(mdl);
                    context.SaveChanges();
                };
                ret = 1;
            }
            catch (Exception ex)
            {
                //lhelper.LogException(ex);
                //ret = 0;
            }
            return ret;
        }
        public List<ContactModel> GetContactList()
        {
            List<ContactModel> pdashMdl = new List<ContactModel>();
            using (SynoProjectDBEntities context = new SynoProjectDBEntities())
            {
                var plist = context.Contacts.ToList();
                foreach (var pl in plist)
                {
                    Mapper.CreateMap<Contact, ContactModel>();
                    var mdl = Mapper.Map<Contact, ContactModel>(pl);
                    pdashMdl.Add(mdl);
                }
            }
            return pdashMdl;
        }
        public int EditContact(ContactModel Contact)
        {
            using (SynoProjectDBEntities Context = new SynoProjectDBEntities())
            {
                //var PeojectDetails = context.Projects.Where(i => i.ProjectID == proj.ProjectID);
                Mapper.CreateMap<ContactModel, Contact>();
                var md = Mapper.Map<ContactModel, Contact>(Contact);
                Context.Contacts.Add(md);
                Context.Entry(md).State = EntityState.Modified;
                int i = Context.SaveChanges();
                return i;
            };

        }
        public ContactModel GetContact(int ContactID)
        {
            var plist = DBContext.Contacts.Where(i => i.ContactID == ContactID).FirstOrDefault();
            Mapper.CreateMap<Contact, ContactModel>();
            var mdl = Mapper.Map<Contact, ContactModel>(plist);
            return mdl;
        }
    }
}

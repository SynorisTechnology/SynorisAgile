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
    public interface IProjectService
    {
        int AddProject(ProjectModel reso);
        int EditProject(ProjectModel reso);
        List<ProjectModel> AllProject();
        ProjectModel GetProject(int projectID);
        List<ProjectModel> GetProject(string name);
        List<ProjectDashboardModel> GetProjectDashboard();
    }
    public class ProjectService : IProjectService
    {
        #region Private Fields
        private readonly LogHelper lhelper;
        private readonly SynoProjectDBEntities dbContext;
        #endregion
        public ProjectService()
        {
            lhelper = new LogHelper();
            dbContext = new SynoProjectDBEntities();
        }
        public int AddProject(ProjectModel proj)
        {
            int ret = 0;
            try
            {
                using (SynoProjectDBEntities context = new SynoProjectDBEntities())
                {
                    if (proj.StartDateSt != null) proj.StartDate = Convert.ToDateTime(proj.StartDateSt, DataHelper.IndianDateFormat());
                    if (proj.EndDateSt != null) proj.EndDate = Convert.ToDateTime(proj.EndDateSt, DataHelper.IndianDateFormat());
                    if (proj.DeadLineSt != null) proj.DeadLine = Convert.ToDateTime(proj.DeadLineSt, DataHelper.IndianDateFormat());
                    Mapper.CreateMap<ProjectModel, Project>();
                    var mdl = Mapper.Map<ProjectModel, Project>(proj);
                    context.Projects.Add(mdl);
                    context.SaveChanges();
                };
                ret = 1;
            }
            catch (Exception ex)
            {
                lhelper.LogException(ex);
                ret = 0;
            }
            return ret;
        }

        public int EditProject(ProjectModel proj)
        {
            using (SynoProjectDBEntities Context = new SynoProjectDBEntities())
            {
                //var PeojectDetails = context.Projects.Where(i => i.ProjectID == proj.ProjectID);
                Mapper.CreateMap<ProjectModel, Project>();
                var md = Mapper.Map<ProjectModel, Project>(proj);
                Context.Projects.Add(md);
                Context.Entry(md).State = EntityState.Modified;
                int i = Context.SaveChanges();
                return i;
            };

        }

        public List<ProjectModel> AllProject()
        {
            List<ProjectModel> prjMdl = new List<ProjectModel>();
            using (SynoProjectDBEntities context = new SynoProjectDBEntities())
            {
                var ptx = context.Projects.ToList();
                foreach (var pt in ptx)
                {
                    Mapper.CreateMap<Project, ProjectModel>();
                    var mdl = Mapper.Map<Project, ProjectModel>(pt);
                    prjMdl.Add(mdl);
                }
            }



            return prjMdl;
        }


        public ProjectModel GetProject(int projectID)
        {
            var plist = dbContext.Projects.Where(i => i.ProjectID == projectID).FirstOrDefault();
                Mapper.CreateMap<Project, ProjectModel>();
                var mdl = Mapper.Map<Project, ProjectModel>(plist);
                if (mdl.DeadLine != null) mdl.DeadLineSt = mdl.DeadLine.Value.ToString("dd/MM/yyyy");
                if (mdl.StartDate != null) mdl.StartDateSt = mdl.StartDate.Value.ToString("dd/MM/yyyy");
                if (mdl.EndDate != null) mdl.EndDateSt = mdl.EndDate.Value.ToString("dd/MM/yyyy");
                return mdl;
        }

        public List<ProjectModel> GetProject(string name)
        {
            List<ProjectModel> _obj = new List<ProjectModel>();
            return _obj;
        }
        public List<ProjectDashboardModel> GetProjectDashboard()
        {
            List<ProjectDashboardModel> pdashMdl = new List<ProjectDashboardModel>();
            using (SynoProjectDBEntities context = new SynoProjectDBEntities())
            {
                var plist = context.Projects.Where(i => i.Status == "true").ToList();
                foreach (var pl in plist)
                {
                    Mapper.CreateMap<Project, ProjectDashboardModel>();
                    var mdl = Mapper.Map<Project, ProjectDashboardModel>(pl);
                    if (String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(mdl.StartDate)) == "01/01/0001")
                    { mdl.StartDate = Convert.ToString(""); }
                    else
                    { mdl.StartDate = String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(mdl.StartDate)); }


                    if (String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(mdl.EndDate)) == "01/01/0001")
                    { mdl.EndDate = Convert.ToString(""); }
                    else
                    { mdl.EndDate = String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(mdl.EndDate)); }
                    pdashMdl.Add(mdl);
                }
            }
            return pdashMdl;
        }
        public List<ProjectDashboardModel> FreeTextSearch(string search)
        {
            List<ProjectDashboardModel> pdashMdl = new List<ProjectDashboardModel>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());// "Data Source=111.118.250.186;Initial Catalog=SynoProjectDB; User ID=sa; Password=Syno2015;");
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proc_search";
            cmd.Parameters.AddWithValue("@Search_text", search);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow rw in dt.Rows)
            {
                ProjectDashboardModel md = new ProjectDashboardModel();
                md.ProjectTitle = rw["ProjectTitle"].ToString();
                md.ProjectTech = rw["ProjectTech"].ToString();
                string Budget = Convert.ToString(rw["Budget"].ToString());
                if (Budget == "")
                { Budget = "0.00"; }
                md.Budget = Convert.ToDecimal(Budget);
                md.ClientInfo = rw["ClientInfo"].ToString();
                md.Status = rw["Status"].ToString();
                md.Description = rw["Description"].ToString();
                md.DemoUrl = rw["DemoUrl"].ToString();
                md.ProductionUrl = rw["ProductionUrl"].ToString();
                string Targated = Convert.ToString(rw["Targated"].ToString());
                if (Targated == "")
                { Targated = "0"; }
                md.Targated = Convert.ToInt32(Targated);
                md.StartDate = String.Format("{0:MM/dd/yyyy}", rw["StartDate"]);
                md.EndDate = String.Format("{0:MM/dd/yyyy}", rw["EndDate"]);
                string Tracker = Convert.ToString(rw["Tracker"].ToString());
                if (Tracker == "")
                { Tracker = "false"; }
                md.Tracker = Convert.ToBoolean(Tracker);
                pdashMdl.Add(md);
            }
            return pdashMdl;
        }

        public List<ProjectModel> GetProjectbYiD(int id)
        {
            List<ProjectModel> pdashMdl = new List<ProjectModel>();
            using (SynoProjectDBEntities context = new SynoProjectDBEntities())
            {
                var plist = context.Projects.Where(i => i.ProjectID == id);

                foreach (var pl in plist)
                {
                    Mapper.CreateMap<Project, ProjectModel>();
                    var mdl = Mapper.Map<Project, ProjectModel>(pl);
                    pdashMdl.Add(mdl);
                }
            }
            return pdashMdl;
        }
    }
}

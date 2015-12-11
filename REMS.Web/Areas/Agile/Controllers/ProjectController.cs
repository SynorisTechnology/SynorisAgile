using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace REMS.Web.Areas.Agile.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Agile/Project
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddProject()
        {
            return View();
        }

        public ActionResult EditProject(string id)
        {
            Synoris.Data.Access.ProjectService objProject = new Synoris.Data.Access.ProjectService();
            ViewBag.id = id;
            return View();
        }

        public ActionResult SearchProject()
        {
            return View();
        }
        public bool SaveProject(Synoris.Data.DataModel.ProjectModel project)
        {
            Synoris.Data.Access.ProjectService objProject = new Synoris.Data.Access.ProjectService();
           int i= objProject.AddProject(project);
            return true;
        }
      
        public string ShowProjectById(string id)
        {
            try
            {
                Synoris.Data.Access.ProjectService objProject = new Synoris.Data.Access.ProjectService();
                var ret = objProject.GetProject(Convert.ToInt32(id));
                //return Json(ret, JsonRequestBehavior.AllowGet);
                return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            }
            catch (Exception ex) { throw ex; }
        }


        public string ShowProjectBySearch(string searchText)
        {
            try
            {
                Synoris.Data.Access.ProjectService objProject = new Synoris.Data.Access.ProjectService();
                var ret = objProject.FreeTextSearch(Convert.ToString(searchText));
                //return Json(ret, JsonRequestBehavior.AllowGet);
                return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            }
            catch (Exception ex) { throw ex; }
        }


        public int UpdateProjectById(Synoris.Data.DataModel.ProjectModel project, string id)
        {
            Synoris.Data.Access.ProjectService objProject = new Synoris.Data.Access.ProjectService();
           int i= objProject.EditProject(project);
            return i;
        }
        public string GetProjectList()
        {
            try
            {
                Synoris.Data.Access.ProjectService objProject = new Synoris.Data.Access.ProjectService();
                var ret = objProject.GetProjectDashboard();
                //return Json(ret, JsonRequestBehavior.AllowGet);
                return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            }
            catch (Exception ex) { throw ex; }
        }

        public string GetAllProjectList()
        {
            try
            {
                Synoris.Data.Access.ProjectService objProject = new Synoris.Data.Access.ProjectService();
                var ret = objProject.AllProject();
                //return Json(ret, JsonRequestBehavior.AllowGet);
                return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            }
            catch (Exception ex) { throw ex; }
        }

    }
}
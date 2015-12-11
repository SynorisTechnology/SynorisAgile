//using REMS.Data;
//using REMS.Data.Access.Admin;
//using REMS.Data.CustomModel;
//using REMS.Data.DataModel;
using Synoris.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace REMS.Web.Areas.Admin.Controllers
{
    public class PropertyProjectController : Controller
    {
        ProjectService pservice = new ProjectService();

        // GET: Admin/PropertyProject
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddProject()
        {
            return View();
        }
        public ActionResult AddPropertyType()
        {
            return View();
        }


//        #region AngularService
//        public string GetAllProjects()
//        {
//            List<ProjectModel> model = pservice.AllProjects();
//            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
//        }
//        public string GetProject(int projectID)
//        {
//            Project model = pservice.GetProject(projectID);
//            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
//        }
//        //public string SaveProject(ProjectModel project)
//        //{
//        //    project.CrBy = User.Identity.Name;
//        //    int i = pservice.AddProject(project);
//        //    return Newtonsoft.Json.JsonConvert.SerializeObject(i);
//        //}
//        //public string EditProject(ProjectModel pmodel)
//        //{
//        //    int i = pservice.EditProject(pmodel);
//        //    return Newtonsoft.Json.JsonConvert.SerializeObject(i);
//        //}
//        public string GetAllProjectTypes()
//        {
//            List<ProjectTypeModel> model = pservice.AllProjectTypes();
//            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
//        }
//        public string GetProjectType(int projectID)
//        {
//            if (projectID == 0)
//            {
//                List<ProjectTypeModel> model = pservice.AllProjectTypes();
//                return Newtonsoft.Json.JsonConvert.SerializeObject(model);
//            }
//            else
//            {
//                List<ProjectTypeModel> model = pservice.GetProjectTypeList(projectID);
//                return Newtonsoft.Json.JsonConvert.SerializeObject(model);
//            }
//        }
//        public string SaveProjectType(ProjectTypeModel project)
//        {
//            project.CrBy = User.Identity.Name;
//            project.CrDate = DateTime.Now;
//            int i = pservice.AddProjectType(project);
//            return Newtonsoft.Json.JsonConvert.SerializeObject(i);
//        }
//        public string EditProjectType(ProjectTypeModel pmodel)
//        {
//            int i = pservice.EditProjectType(pmodel);
//            return Newtonsoft.Json.JsonConvert.SerializeObject(i);
//        }

//        public string TowerView(int towerID)
//        {
//            TowerService tservice = new TowerService();
//            List<TowerViewModel> model = tservice.TowerViewList(towerID);

//            string towerhtml = "";
//            foreach (var md in model)
//            {
//                string html = TowerHtml();
//                html=  html.Replace("<% FloorNo %>", md.FloorNo.Value.ToString());
//                string flats = "";
//                foreach (var ft in md.FlatList)
//                {
//                    string fml = flathtml();
//                     //ft.Status=
//                    flats += fml.Replace("<% FlatType %>", ft.FlatType).Replace("<% FlatSize %>", ft.FlatSize.Value.ToString() + " " + ft.FlatSizeUnit).Replace("<% FlatID %>", ft.FlatID.ToString());
//                }
//                html = html.Replace("<% Flats %>", flats);
//                towerhtml += html;
//            }
//            return towerhtml;
//        }
//        public string TowerHtml()
//        {
//            string st = @"<li>
//    <div class='smart-timeline-icon'>
//       <% FloorNo %><sup>th</sup>
//    </div>
//    <div class='smart-timeline-time'>
//        <small>Floor </small>
//    </div>
//    <div class='smart-timeline-content'>
//        <div class='row'>
//           <% Flats %>
//        </div>
//    </div>
//</li>";
//            return st;
//        }
//        public string flathtml()
//        {
//            string st = @" <div class='col-sm-6 col-md-3 col-lg-3'>
//                <div class='jarviswidget jarviswidget-color-red'>
//                    <header>
//                        <h2><i class='fa fa-home'></i> <% FlatType %> <% FlatSize %> </h2>
//                        <div class=''>
//                            &nbsp;&nbsp;
//                            <a href='#' class='btn btn-circle btn-dark dropdown-toggle' data-toggle='dropdown' tabindex='-1'>
//                                <span class='caret'>  </span>
//                            </a>
//                            <ul class='dropdown-menu pull-right no-padding' role='menu'>
//                                <li class='no-padding'><a href='<% FlatID %>'>Sale</a></li>
//                                <li class='divider no-padding'></li>
//                                <li class='no-padding'><a href='javascript:void(0);'>View Details</a></li>
//                            </ul>
//                        </div>
//                    </header>
//                    <div>
//                        <div class='widget-body hidden'>
//                        </div>
//                    </div>
//                </div>
//            </div>";
//            return st;
//        }

//        #endregion
    }
}
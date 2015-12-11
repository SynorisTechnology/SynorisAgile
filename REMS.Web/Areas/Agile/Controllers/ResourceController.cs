using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace REMS.Web.Areas.Agile.Controllers
{
    public class ResourceController : Controller
    {
        // GET: Agile/Resource
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddResource()
        {
            return View();
        }
        public string SaveResource(string name, string contact, string email, string empCode)
        {
            int ret = 0;
            string ex1 = string.Empty;
            Synoris.Data.Access.ResourceService objResource = new Synoris.Data.Access.ResourceService();
            Synoris.Data.DataModel.ResourceModel resModel = new Synoris.Data.DataModel.ResourceModel();
            resModel.Name = name;
            resModel.ContactNo = contact;
            resModel.EmailID = email;
            resModel.EmpCode = empCode;
            resModel.CrDate = System.DateTime.Today;
            if (User.Identity.IsAuthenticated)
            {
                resModel.CrBy = User.Identity.Name;
               
            }
            try
            {
                ex1 = objResource.AddResource(resModel);
                //ex1 = "done";
            }
            catch (Exception ex) { ret = 0; ex1=ex.Message; throw ex; }
            return ex1;
        }
        public string GetResourceList()
        {
            try
            {
                Synoris.Data.Access.ResourceService objProject = new Synoris.Data.Access.ResourceService();
                var ret = objProject.AllResource();
                //return Json(ret, JsonRequestBehavior.AllowGet);
                
                return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
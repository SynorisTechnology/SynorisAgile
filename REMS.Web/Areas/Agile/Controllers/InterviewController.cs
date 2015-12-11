using Synoris.Data.Access;
using Synoris.Data.Access.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace REMS.Web.Areas.Agile.Controllers
{
    public class InterviewController : Controller
    {
        public readonly InterviewService conService;
        public InterviewController()
        {
            conService = new InterviewService();
        }
        // GET: /Agile/Interview/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InterviewSection()
        {
            return View();
        }
        public ActionResult InterviewList()
        {
            return View();
        }
        public ActionResult EditInterview(int? id)
        {
            Synoris.Data.Access.InterviewService objContact = new Synoris.Data.Access.InterviewService();
            ViewBag.id = id;
            return View();
        }
        public bool AddInterviewInfo(Synoris.Data.DataModel.InterviewModel Interview)
        {
            int i = conService.AddInterviewInfo(Interview);
            return true;
        }
        public string GetInterviewList()
        {
            try
            {
                //Synoris.Data.Access.ContactService objContact = new Synoris.Data.Access.ContactService();
                var ret = conService.GetInterviewList();
                //return Json(ret, JsonRequestBehavior.AllowGet);
                return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            }
            catch (Exception ex) { throw ex; }
        }
        public string ShowInterviewById(string id)
        {
            try
            {
                //Synoris.Data.Access.ContactService objContact = new Synoris.Data.Access.ContactService();
                var ret = conService.GetInterview(Convert.ToInt32(id));
                //return Json(ret, JsonRequestBehavior.AllowGet);
                return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            }
            catch (Exception ex)
            {
                LogHelper hp = new LogHelper();
                hp.LogException(ex);
                throw ex;
            }
        }
        public int UpdateInterviewById(Synoris.Data.DataModel.InterviewModel Interview, string id)
        {
            //Synoris.Data.Access.ContactService objContact = new Synoris.Data.Access.ContactService();
            int i = conService.EditInterview(Interview);
            return i;
        }
    }
}
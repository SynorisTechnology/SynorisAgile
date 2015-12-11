using Synoris.Data.Access;
using Synoris.Data.Access.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace REMS.Web.Areas.Agile.Controllers
{
    public class ContactController : Controller
    {
        public readonly ContactService conService;
        public ContactController()
        {
            conService = new ContactService();
        }
        // GET: Agile/Contact
        public ActionResult Index()
        {
            return View();
        }
        public bool SaveContact(Synoris.Data.DataModel.ContactModel Contact)
        {
            int i = conService.AddContact(Contact);
            return true;
        }
        public ActionResult ShowContact()
        {
            return View();
        }
        public ActionResult EditContact(int? id)
        {
            Synoris.Data.Access.ContactService objContact = new Synoris.Data.Access.ContactService();
            ViewBag.id = id;
            return View();
        }
        public string ShowContactById(string id)
        {
            try
            {
                //Synoris.Data.Access.ContactService objContact = new Synoris.Data.Access.ContactService();
                var ret = conService.GetContact(Convert.ToInt32(id));
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
        public string GetContactList()
        {
            try
            {
                //Synoris.Data.Access.ContactService objContact = new Synoris.Data.Access.ContactService();
                var ret = conService.GetContactList();
                //return Json(ret, JsonRequestBehavior.AllowGet);
                return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            }
            catch (Exception ex) { throw ex; }
        }
        public int UpdateContactById(Synoris.Data.DataModel.ContactModel Contact, string id)
        {
            //Synoris.Data.Access.ContactService objContact = new Synoris.Data.Access.ContactService();
            int i = conService.EditContact(Contact);
            return i;
        }
        public string ShowProjectById(int id)
        {
            try
            {
                //Synoris.Data.Access.ContactService objContact = new Synoris.Data.Access.ContactService();
                var ret = conService.GetContact(Convert.ToInt32(id));
                //return Json(ret, JsonRequestBehavior.AllowGet);
                return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
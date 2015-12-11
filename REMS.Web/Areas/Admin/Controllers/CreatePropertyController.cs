﻿using REMS.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using REMS.Data.Access.Admin;
//using REMS.Data;
using AutoMapper;
using REMS.Web.App_Helpers;
//using REMS.Data.DataModel;

namespace REMS.Web.Areas.Admin.Controllers
{
    public class CreatePropertyController : Controller
    {
        // GET: Admin/CreateProperty
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddTower()
        {
            return View();
        }
        public ActionResult AddFloor()
        {
            return View();
        }
        public ActionResult AddFlat()
        {
            return View();
        }
        public ActionResult EditFlat()
        {
            return View();
        }
        // Angular Service
        //TowerService tservice = new TowerService();
        //FlatService fservice = new FlatService();
        //FloorService flrService = new FloorService();
        //#region TowerService
        //public string SaveTower(TowerModel tower)
        //{
        //    TowerService ts = new TowerService();
        //    Mapper.CreateMap<TowerModel, Tower>();
        //    Tower tw = Mapper.Map<TowerModel, Tower>(tower);
        //    tw.CrBy = User.Identity.Name;
        //    tw.CrDate = DateTime.Now;
        //    int i = ts.AddTower(tw);
        //    return i.ToString();
        //}
        //public string UpdateTower(TowerModel tower)
        //{
        //    TowerService ts = new TowerService();
        //    Mapper.CreateMap<TowerModel, Tower>();
        //    Tower tw = Mapper.Map<TowerModel, Tower>(tower);
        //    tw.CrBy = User.Identity.Name;
        //    tw.CrDate = DateTime.Now;
        //    int i = ts.EditTower(tw);
        //    return i.ToString();
        //}
        //public string getAllTower()
        //{
        //    List<Tower> ts = new List<Tower>();
        //    List<TowerModel> tm = new List<TowerModel>();
        //    ts = tservice.AllTower();
        //    foreach (var md in ts)
        //    {
        //        Mapper.CreateMap<Tower, TowerModel>();
        //        var tmdl = Mapper.Map<Tower, TowerModel>(md);
        //        if (tmdl.PossessionDate != null)
        //            tmdl.PossessionDateSt = tmdl.PossessionDate.Value.ToString("dd/MM/yyyy");
        //        tm.Add(tmdl);
        //    }
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(tm);
        //}
        //public string getTowerbyID(int towerid)
        //{
        //    Tower tw = tservice.TowerList(towerid);
        //    Mapper.CreateMap<Tower, TowerModel>();
        //    var model = Mapper.Map<Tower, TowerModel>(tw);
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        //}
        //public string AllTowerProject()
        //{
        //    var model = tservice.AllTowerProject();
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        //}
        //#endregion
        //#region FloorService
        //public string SaveFloor(FloorModel floor)
        //{
        //    Mapper.CreateMap<FloorModel, Floor>();
        //    Floor fl = Mapper.Map<FloorModel, Floor>(floor);
        //    fl.CrBy = User.Identity.Name;
        //    fl.CrDate = DateTime.Now;
        //    int i = flrService.AddFloor(fl);
        //    return i.ToString();
        //}
        //public string UpdateFloor(FloorModel floor)
        //{
        //    Mapper.CreateMap<FloorModel, Floor>();
        //    Floor fl = Mapper.Map<FloorModel, Floor>(floor);
        //    int i = flrService.EditFloor(fl);
        //    return i.ToString();
        //}
        //public string getFloorByID(int floorid)
        //{
        //    Floor fl = flrService.FloorList(floorid);
        //    Mapper.CreateMap<Floor, FloorModel>();
        //    var model = Mapper.Map<Floor, FloorModel>(fl);
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        //}
        //public string getAllFloorByTowerID(int towerid)
        //{
        //    List<FloorModel> fl = flrService.AllFloor(towerid);
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(fl);
        //}
        //public string DeleteFloor(int floorid)
        //{
        //    int i = flrService.DeleteFloor(floorid);
        //    return i.ToString();
        //}
        //#endregion
        //#region FlatService Edit

        //public string SaveFat(FlatModel flat)
        //{
        //    Mapper.CreateMap<FlatModel, Flat>();
        //    Flat fl = Mapper.Map<FlatModel, Flat>(flat);
        //    fl.CrBy = User.Identity.Name;
        //    fl.CrDate = DateTime.Now;
        //    int i = fservice.AddNewFlat(fl);
        //    return i.ToString();
        //}
        //public string UpdateFlat(FlatModel flat)
        //{
        //    Mapper.CreateMap<FlatModel, Flat>();
        //    Flat fl = Mapper.Map<FlatModel, Flat>(flat);
        //    int i =fservice.EditFlat(fl);
        //    return i.ToString();
        //}
        //public string getFlatByID(int flatid)
        //{
        //    FlatModel fl = fservice.GetFlatByID(flatid);
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(fl);
        //}
        //public string GetFlatsByFloorID(int floorid)
        //{
        //    List<FlatModel> fl= fservice.GetFlatsByFloorID(floorid);
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(fl);
        //}
        //public string DeleteFlat(int flatid)
        //{
        //    int i = fservice.DeleteFlat(flatid);
        //    return i.ToString();
        //}
        //#endregion
        //#region GenerateFlat Property
        //public string FlatHmtl(string TotalFlat)
        //{
        //    string FltHtml = "";
        //    int flatcount = Convert.ToInt32(TotalFlat);
        //    for (int i = 1; i <= flatcount; i++)
        //    {
        //        string html = fservice.FlatCreateBody();
        //        PLCService ps = new PLCService();
        //        var model = ps.GetAllPLC();
        //        html += "<div id='panel" + i.ToString() + "'>";
        //        foreach (var pm in model)
        //        {
        //            string id = pm.PLCID.ToString() + " " + i.ToString();
        //            html += @"<label class='checkbox'><input type='checkbox' value='" + pm.PLCID + "' name='" + pm.PLCName + "' id='" + id + "'><i></i> " + pm.PLCName + "</label>";
        //        }
        //        html += "</div></div>";
        //        FltHtml += html.Replace("<% FlatNo %>", "FlatNo" + i).Replace("<% PreIncrement %>", "PreIncrement" + i);
        //    }
        //    return FltHtml;
        //}
        //public string GenerateTowerAddFloor(int TotalFloor, int TowerID)
        //{
        //    int i = fservice.AddFloor(TowerID, TotalFloor, User.Identity.Name);
        //    return i.ToString();
        //}
        //public string GenerateTowerAddFlat(int TotalFloor, List<int> FlatNo, List<bool> PreIncrement, string[] PLCIDs, int TowerID)
        //{
        //    int i = 0;
        //    //foreach (int flat in FlatNo)
        //    //{
        //    List<PLCModel> pmodel = new List<PLCModel>();
        //    PLCModel pm = new PLCModel();
        //    foreach (string s in PLCIDs)
        //    {
        //        if (s != null && s != "")
        //        {
        //            pmodel.Add(new PLCModel { PLCID = Convert.ToInt32(s), PLCName = s });
        //        }
        //    }
        //    int ss = fservice.AddFlats(TotalFloor, 0, FlatNo, PreIncrement, pmodel, User.Identity.Name, TowerID);
        //    i++;
        //    // }

        //    return "1";
        //}
        //#endregion
    }
}
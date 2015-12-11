using Synoris.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Synoris.Data.Access
{
    public interface IResourceService
    {
        int AddResource(ResourceModel reso);
        int EditResource(ResourceModel reso);
        List<ResourceModel> AllResource();
        ResourceModel GetResource(int resourceID);
        List<ResourceModel> GetResource(string name);
        List<ResourceModel> GetProjectResource(int ProjectID, string status);
    }
    public class ResourceService
    {
        public string AddResource(ResourceModel res)
        {
            string ret = string.Empty;
            try
            {
                using(SynoProjectDBEntities objEnt=new SynoProjectDBEntities())
                {
                    Mapper.CreateMap<ResourceModel, Resource>();
                    var mdl = Mapper.Map<ResourceModel, Resource>(res);
                    objEnt.Resources.Add(mdl);
                    objEnt.SaveChanges();
                }
                ret = "done";
            }
            catch(Exception ex)  { ret = ex.Message;
            
            }
            return ret;
        }

        public int EditResource(ProjectModel proj)
        {

            return 0;
        }
        public List<ResourceModel> AllResource()
        {
            List<ResourceModel> rsMd = new List<ResourceModel>();
            using (SynoProjectDBEntities context = new SynoProjectDBEntities())
            {
                var ret = context.Resources.ToList();
                foreach (var rt in ret)
                {
                    Mapper.CreateMap<Resource, ResourceModel>();
                    var md = Mapper.Map<Resource, ResourceModel>(rt);
                    rsMd.Add(md);
                }
            }
            return rsMd;
        }


        public ResourceModel GetResource(int resourceID)
        {
            ResourceModel _cls = new ResourceModel();

            return _cls;
        }

        public List<ResourceModel> GetResource(string name)
        {
            List<ResourceModel> _cls = new List<ResourceModel>();

            return _cls;
        }

        public List<ResourceModel> GetProjectResource(int ProjectID, string status)
        {
            List<ResourceModel> _cls = new List<ResourceModel>();

            return _cls;
        }

    }
}

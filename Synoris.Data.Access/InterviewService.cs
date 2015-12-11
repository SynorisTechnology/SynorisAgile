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
    public interface IInterviewService
    {
        int AddInterviewInfo(InterviewModel Intrvw);
    }
    public class InterviewService : IInterviewService
    {
        #region Private Fields
        private readonly LogHelper lhelper;
        private readonly SynoProjectDBEntities DBContext;
        #endregion
        public InterviewService()
        {
            DBContext = new SynoProjectDBEntities();
        }
        public int AddInterviewInfo(InterviewModel Intrvw)
        {
            int ret = 0;
            try
            {
                using (SynoProjectDBEntities context = new SynoProjectDBEntities())
                {

                    Mapper.CreateMap<InterviewModel, Interview>();
                    var mdl = Mapper.Map<InterviewModel, Interview>(Intrvw);
                    context.Interviews.Add(mdl);
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
        public List<InterviewModel> GetInterviewList()
        {
            List<InterviewModel> pdashMdl = new List<InterviewModel>();
            using (SynoProjectDBEntities context = new SynoProjectDBEntities())
            {
                var plist = context.Interviews.ToList();
                foreach (var pl in plist)
                {
                    Mapper.CreateMap<Interview, InterviewModel>();
                    var mdl = Mapper.Map<Interview, InterviewModel>(pl);
                    pdashMdl.Add(mdl);
                }
            }
            return pdashMdl;
        }
        public InterviewModel GetInterview(int InterviewID)
        {
            var plist = DBContext.Interviews.Where(i => i.InterviewID == InterviewID).FirstOrDefault();
            Mapper.CreateMap<Interview, InterviewModel>();
            var mdl = Mapper.Map<Interview, InterviewModel>(plist);
            return mdl;
        }

        public int EditInterview(InterviewModel Interview)
        {
            using (SynoProjectDBEntities Context = new SynoProjectDBEntities())
            {
                //var PeojectDetails = context.Projects.Where(i => i.ProjectID == proj.ProjectID);
                Mapper.CreateMap<InterviewModel, Interview>();
                var md = Mapper.Map<InterviewModel, Interview>(Interview);
                Context.Interviews.Add(md);
                Context.Entry(md).State = EntityState.Modified;
                int i = Context.SaveChanges();
                return i;
            };

        }
    }
}

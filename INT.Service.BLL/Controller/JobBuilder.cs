using INT.Service.DAL.Base;
using INT.Service.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.Service.BLL.Controller
{
    public class JobBuilder
    {
        #region Methods

        public List<JobResponse> GetCurrentJobs()
        {
            var jobs = new List<JobResponse>();

            var query = new BaseContext();

            var tasks = query.Context.Scheduler.ToList();
        }

        #endregion
    }
}

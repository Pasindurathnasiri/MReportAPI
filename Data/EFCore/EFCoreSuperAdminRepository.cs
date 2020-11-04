using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MReportAPI.Models;

namespace MReportAPI.Data.EFCore
{
    public class EFCoreSuperAdminRepository : EFCoreRepository<SuperAdmin, MReportAPIContext>
    {
        public EFCoreSuperAdminRepository(MReportAPIContext context) : base(context)
        {

        }
    }

}

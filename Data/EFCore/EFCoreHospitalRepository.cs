using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MReportAPI.Models;


namespace MReportAPI.Data.EFCore
{
    public class EFCoreHospitalRepository : EFCoreRepository<Hospital, MReportAPIContext>
    {
        public EFCoreHospitalRepository(MReportAPIContext context) : base(context)
        {

        }
    }
}

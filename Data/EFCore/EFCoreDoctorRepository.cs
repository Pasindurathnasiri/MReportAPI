using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MReportAPI.Models;

namespace MReportAPI.Data.EFCore
{
    public class EFCoreDoctorRepository : EFCoreRepository<Doctor, MReportAPIContext>
    {
        public EFCoreDoctorRepository(MReportAPIContext context) : base(context)
        {

        }
    }
}

using CoreWebAPIAngualarPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPIAngualarPOC.Interfaces
{
    interface IDepartmentRepository
    {
        Department GetDepartmentbyId(int id);
    }
}

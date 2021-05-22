using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPIAngualarPOC.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
    public class DepartmentDTO
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }   
}

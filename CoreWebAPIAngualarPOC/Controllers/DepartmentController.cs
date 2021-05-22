using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreWebAPIAngualarPOC.Interfaces;
using CoreWebAPIAngualarPOC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreWebAPIAngualarPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        //private readonly CompanyContext _companyContext;
        private readonly IGenericRepository<Department> _deptRepo;
        private readonly IMapper _mapper;


        public DepartmentController(IMapper mapper, IGenericRepository<Department> deptRepo)
        {
            _mapper = mapper;
            //_companyContext = companyContext;
            _deptRepo = deptRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //return await _mapper.Map<DepartmentDTO>(_companyContext.Departments.ToListAsync());
            var departments = _deptRepo.GetAll();
           return Ok(_mapper.Map<IList<DepartmentDTO>>(departments));
        }
        // GET: api/PaymentDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var department = _mapper.Map<DepartmentDTO>(_deptRepo.GetById(id));

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Department departmentDetail)
        {
            if (id != departmentDetail.DepartmentId)
            {
                return BadRequest();
            }
            try
            {
                _deptRepo.Put(departmentDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymentDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("PaymentDetail")]
        public async Task<ActionResult<Department>> Post(Department departmentDetail)
        {
            _deptRepo.Add(departmentDetail);
            //_companyContext.Departments.Add(departmentDetail);
            //await _companyContext.SaveChangesAsync();

            return CreatedAtAction("GetbyId", new { id = departmentDetail.DepartmentId }, departmentDetail);
        }

        // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            //var department = await _companyContext.Departments.FindAsync(id);
            //if (department == null)
            //{
            //    return NotFound();
            //}

            //_companyContext.Departments.Remove(department);
            //await _companyContext.SaveChangesAsync();
            _deptRepo.Remove(_deptRepo.GetById(id));
            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            //return _companyContext.Departments.Any(e => e.DepartmentId == id);
            return true;
        }

    }
}

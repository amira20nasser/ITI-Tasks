using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class DepartmentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public DepartmentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<DepartmentListDto> GetAll()
        {
            return _mapper.Map<List<DepartmentListDto>>(_context.Departments.Include(d => d.Students).ToList());
        }

        public DepartmentListDto? GetById(int id)
        {
            var dept = _context.Departments.Include(d => d.Students).SingleOrDefault(d => d.DeptId == id);
            if (dept == null)
            {
                return null;
            }
            //return new DepartmentListDto
            //{
            //    Id = dept.DeptId,
            //    Name = dept.DeptName,
            //    Description = dept.DeptDesc,
            //    Location = dept.DeptLocation,
            //    NumOfStudents = dept.Students.Count()
            //};
            return _mapper.Map<DepartmentListDto>(dept);
        }

        public void Add(AddDepartmentDto dto)
        {
            var dept = _mapper.Map<Department>(dto);
            _context.Departments.Add(dept);
           
            _context.SaveChanges();
        }

        public void Update(int id, EditDepartmentDto dto)
        {
            var dept = _context.Departments.Find(id);
            if (dept == null)
            {
                throw new Exception("Department not found");
            }
            dept.DeptName = dto.Name;
            dept.DeptDesc = dto.Description;
            dept.DeptLocation = dto.Location;
            dept.DeptManager = dto.ManagerId;
            dept.ManagerHiredate = dto.ManagerHiredate;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var dept = _context.Departments.Find(id);
            if (dept == null)
            {
                throw new Exception("Department not found");
            }
            _context.Departments.Remove(dept);
            _context.SaveChanges();
        }
    }
}

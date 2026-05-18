using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer
{
    public class StudentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public StudentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<StudentListDto> GetByName(string? FName, string? LName)
        {
            var query = _context.Students.Include(s => s.Dept).Include(s => s.StSuperNavigation).AsQueryable();

            if (!string.IsNullOrEmpty(FName))
            {
                query = query.Where(s => s.StFname != null &&
                                         s.StFname.ToLower() == FName.ToLower());
            }
            if (!string.IsNullOrEmpty(LName))
            {
                query = query.Where(s => s.StLname != null &&
                                         s.StLname.ToLower() == LName.ToLower());
            }

            var students = query.ToList();

            if (students == null || !students.Any())
            {
                return new List<StudentListDto>();
            }


            //return students.Select(d => new StudentListDto
            //{
            //    StId = d.StId,
            //    StFname = d.StFname,
            //    StAddress = d.StAddress,
            //    DeptName = d.Dept?.DeptName,
            //    StAge = d.StAge,
            //    StLname = d.StLname,
            //    StSuperName = d.StSuperNavigation != null ? $"{d.StSuperNavigation.StFname} {d.StSuperNavigation.StLname}" : null
            //}).ToList();

            return _mapper.Map<List<StudentListDto>>(students);
        }



        public List<StudentListDto> GetAll()
        {
            return _mapper.Map<List<StudentListDto>>(_context.Students.Include(s => s.Dept).Include(s => s.StSuperNavigation).ToList());
        }
       
        public StudentListDto? GetById(int id)
        {
            var student = _context.Students.Include(s => s.Dept).Include(s => s.StSuperNavigation).SingleOrDefault(s => s.StId == id);
            if (student == null)
            {
                return null;
            }
            //return new StudentListDto
            //{
            //    StId = student.StId,
            //    StFname = student.StFname,
            //    DeptName = student.Dept?.DeptName,
            //    StAddress = student.StAddress,
            //    StAge = student.StAge,
            //    StLname = student.StLname,
            //    StSuperName = student.StSuperNavigation != null ? $"{student.StSuperNavigation.StFname} {student.StSuperNavigation.StLname}" : null
            //};
            return _mapper.Map<StudentListDto>(student);
        }

        public void Add(AddStudentDto dto)
        {
            //var student = new Student
            //{
               
            //    StId = dto.Id,
            //    StFname = dto.Fname,
            //    StLname = dto.Lname,
            //    StAddress = dto.Address,
            //    StAge = dto.Age,
            //};
            var student = _mapper.Map<Student>(dto);
            _context.Students.Add(student);
            _context.SaveChanges();
        }

    

        public void Update(int id, EditStudentDto dto)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                throw new Exception("Student not found");
            }
            student.StFname = dto.StFname;
            student.StLname = dto.StLname;
            student.StAddress = dto.StAddress;
            student.StAge = dto.StAge;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                throw new Exception("Student not found");
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}

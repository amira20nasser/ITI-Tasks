using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Department, DepartmentListDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DeptId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DeptName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.DeptDesc))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.DeptLocation))
                .ForMember(dest => dest.NumOfStudents, opt => opt.MapFrom(src => src.Students.Count()));

         
            CreateMap<AddDepartmentDto, Department>()
                .ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DeptName, opt => opt.MapFrom(src => src.DeptName))
                .ForMember(dest => dest.DeptDesc, opt => opt.MapFrom(src => src.DeptDesc))
                .ForMember(dest => dest.DeptLocation, opt => opt.MapFrom(src => src.DeptLocation));


            CreateMap<Student, StudentListDto>().AfterMap((src, dest) =>
            {
                dest.DeptName = src.Dept?.DeptName ;
                dest.StSuperName = src.StSuperNavigation?.StFname + " " + src.StSuperNavigation?.StLname;
            });


            CreateMap<AddStudentDto, Student>()
                .ForMember(dest => dest.StId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StFname, opt => opt.MapFrom(src => src.Fname))
                .ForMember(dest => dest.StLname, opt => opt.MapFrom(src => src.Lname))
                .ForMember(dest => dest.StAddress, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.StAge, opt => opt.MapFrom(src => src.Age));
        }
    }
}

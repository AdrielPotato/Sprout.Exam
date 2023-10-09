using AutoMapper;
using Sprout.Exam.Business.Commands.CreateEmployee;
using Sprout.Exam.Business.Commands.UpdateEmployee;
using Sprout.Exam.Business.Queries.GetAllEmployees;
using Sprout.Exam.Business.Queries.GetEmployeeById;
using Sprout.Exam.Common.Models;

namespace Contacts.Application.Mappings
{
    public class ExplicitMappingConfiguration : Profile
    {
        public ExplicitMappingConfiguration()
        {

            CreateMap<Employee, GetAllEmployeesResponse>()
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.EmployeeTypeId))
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate.ToString("yyyy-MM-dd")));

            CreateMap<Employee, GetEmployeeByIdResponse>()
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.EmployeeTypeId))
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate.ToString("yyyy-MM-dd")));

            CreateMap<CreateEmployeeCommand,Employee>()
                .ForMember(dest=>dest.EmployeeTypeId, opt =>opt.MapFrom(src=>src.TypeId))
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate.ToString("yyyy-MM-dd")));

            CreateMap<UpdateEmployeeCommand, Employee>()
                .ForMember(dest => dest.EmployeeTypeId, opt => opt.MapFrom(src => src.TypeId))
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate.ToString("yyyy-MM-dd")));

            CreateMap<Employee, UpdateEmployeeResponse>()
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.EmployeeTypeId))
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate.ToString("yyyy-MM-dd")));
        }
    }
}

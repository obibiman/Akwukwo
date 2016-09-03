using AngularJS.Domain.DomainModel;
using AngularJS.RESTful.WebApi.Models;
using AutoMapper;

namespace AngularJS.RESTful.WebApi
{
    public class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeModel>()
                    .ForMember(y => y.EmployeeId, x => x.MapFrom(y => y.EmployeeId))
                    .ForMember(y => y.EmployeeName, x => x.MapFrom(y => y.EmployeeName))
                    .ForMember(y => y.EmployeeCity, x => x.MapFrom(y => y.EmployeeCity))
                    .ForMember(y => y.EmployeeAge, x => x.MapFrom(y => y.EmployeeAge)).ReverseMap();

                cfg.CreateMap<Student, StudentModel>()
                    .ForMember(y => y.StudentId, x => x.MapFrom(y => y.StudentId))
                    .ForMember(y => y.FirstName, x => x.MapFrom(y => y.FirstName))
                    .ForMember(y => y.LastName, x => x.MapFrom(y => y.LastName))
                    .ForMember(y => y.Email, x => x.MapFrom(y => y.Email))
                    .ForMember(y => y.Address, x => x.MapFrom(y => y.Address)).ReverseMap();
            });
        }
    }
}
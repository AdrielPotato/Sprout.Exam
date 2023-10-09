using AutoMapper;
using Contacts.Application.Mappings;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Sprout.Exam.Business.Commands.CreateEmployee;
using Sprout.Exam.Business.Factories;
using Sprout.Exam.Business.Factories.Interfaces;
using System.Reflection;

namespace Sprout.Exam.Business
{
    public static class Configuration
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            //AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblyContaining<CreateEmployeeValidator>();

            // MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddTransient<IEmployeeFactory, EmployeeFactory>();

            return services;
        }
    }
}

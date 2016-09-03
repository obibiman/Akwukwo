using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using AngularJS.Domain.DomainModel;
using AngularJS.RESTful.WebApi.Models;
using AngularJS.Services.Interfaces;
using AutoMapper;

namespace AngularJS.RESTful.WebApi.Controllers
{
    /// <summary>
    ///     EmployeeController
    /// </summary>
    [RoutePrefix("v1/Employee")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        /// <summary>
        ///     EmployeeController
        /// </summary>
        public EmployeeController()
        {
        }

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("GetEmployees", Name = "GetEmployees")]
        public IEnumerable<EmployeeModel> GetEmployees()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeModel>());
            var mapper = config.CreateMapper();

            var employees = _employeeService.GetAll();

            var employeeListModels = mapper.Map<IEnumerable<Employee>, List<EmployeeModel>>(employees);
            return employeeListModels;
        }


        [HttpGet]
        [Route("GetEmployee/{employeeId}", Name = "GetEmployee")]
        public IHttpActionResult GetEmployee(int employeeId)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeModel>());
            var mapper = config.CreateMapper();

            var employee = _employeeService.GetById(employeeId);
            var transformedEmployee = mapper.Map<Employee, EmployeeModel>(employee);
            if (transformedEmployee == null)
            {
                return BadRequest("No Employee found");
            }
            return Ok(transformedEmployee);
        }

        [HttpPost]
        [Route("PostEmployee", Name = "PostEmployee")]
        public HttpResponseMessage PostEmployee(EmployeeModel employeeModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeModel, Employee>());
            var mapper = config.CreateMapper();
            var transformedEmployee = mapper.Map<EmployeeModel, Employee>(employeeModel);
            _employeeService.Insert(transformedEmployee);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetEmployee", new { transformedEmployee.EmployeeId }));
            return response;
        }

        [HttpPost]
        [Route("PostEmployees", Name = "PostEmployees")]
        public HttpResponseMessage PostEmployees(IEnumerable<EmployeeModel> employeeModels)
        {
            var employeees = new List<Employee>();

            _employeeService.AddRange(employeees);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        [HttpPut]
        [Route("PutEmployee/{employeeId}", Name = "PutEmployee")]
        public HttpResponseMessage PutEmployee(int employeeId, EmployeeModel employeeModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeModel, Employee>());
            var mapper = config.CreateMapper();
            var transformedEmployee = mapper.Map<EmployeeModel, Employee>(employeeModel);
            transformedEmployee.EmployeeId = employeeId;
            _employeeService.Update(transformedEmployee);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetEmployee", new { transformedEmployee.EmployeeId }));
            return response;
        }

        [HttpDelete]
        [Route("DeleteEmployee/{employeeId}", Name = "DeleteEmployee")]
        public HttpResponseMessage DeleteEmployee(int employeeId)
        {
            var employee = _employeeService.GetById(employeeId);
            _employeeService.Delete(employee);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }

        [HttpDelete]
        [Route("DeleteEmployees", Name = "DeleteEmployees")]
        public HttpResponseMessage DeleteEmployees(List<EmployeeModel> employeeModels)
        {
            var employees = new List<Employee>();

            _employeeService.RemoveRange(employees);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }
    }
}

using System;
using System.Collections.Generic;
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
    ///     StudentController
    /// </summary>
    [RoutePrefix("v1/Student")]
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;

        /// <summary>
        ///     StudentController
        /// </summary>
        public StudentController()
        {
        }

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetStudents", Name = "GetStudents")]
        public IEnumerable<StudentModel> GetStudents()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentModel>());
            var mapper = config.CreateMapper();

            var students = _studentService.GetAll();

            var studentModels = mapper.Map<IEnumerable<Student>, List<StudentModel>>(students);
            return studentModels;
        }


        [HttpGet]
        [Route("GetStudent/{studentId}", Name = "GetStudent")]
        public IHttpActionResult GetStudent(int studentId)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentModel>());
            var mapper = config.CreateMapper();

            var student = _studentService.GetById(studentId);
            var transformedStudent = mapper.Map<Student, StudentModel>(student);
            if (transformedStudent == null)
            {
                return BadRequest("No Student found");
            }
            return Ok(transformedStudent);
        }

        [HttpPost]
        [Route("PostStudent", Name = "PostStudent")]
        public HttpResponseMessage PostStudent(StudentModel studentModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StudentModel, Student>());
            var mapper = config.CreateMapper();
            var transformedStudent = mapper.Map<StudentModel, Student>(studentModel);
            _studentService.Insert(transformedStudent);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetStudent", new { transformedStudent.StudentId }));
            return response;
        }

        [HttpPost]
        [Route("PostStudents", Name = "PostStudents")]
        public HttpResponseMessage PostStudents(IEnumerable<StudentModel> studentModels)
        {
            var studentes = new List<Student>();

            _studentService.AddRange(studentes);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        [HttpPut]
        [Route("PutStudent/{studentId}", Name = "PutStudent")]
        public HttpResponseMessage PutStudent(int studentId, StudentModel studentModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StudentModel, Student>());
            var mapper = config.CreateMapper();
            var transformedStudent = mapper.Map<StudentModel, Student>(studentModel);
            transformedStudent.StudentId = studentId;
            _studentService.Update(transformedStudent);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetStudent", new { transformedStudent.StudentId }));
            return response;
        }

        [HttpDelete]
        [Route("DeleteStudent/{studentId}", Name = "DeleteStudent")]
        public HttpResponseMessage DeleteStudent(int studentId)
        {
            var student = _studentService.GetById(studentId);
            _studentService.Delete(student);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }

        [HttpDelete]
        [Route("DeleteStudents", Name = "DeleteStudents")]
        public HttpResponseMessage DeleteStudents(List<StudentModel> studentModels)
        {
            var students = new List<Student>();

            _studentService.RemoveRange(students);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }
    }
}
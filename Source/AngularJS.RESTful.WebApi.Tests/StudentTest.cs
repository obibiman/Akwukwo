using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using AngularJS.Domain.DomainModel;
using AngularJS.RESTful.WebApi.Controllers;
using AngularJS.RESTful.WebApi.Models;
using AngularJS.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AngularJS.RESTful.WebApi.Tests
{
    [TestClass]
    public class StudentTest
    {
        private Mock<IStudentService> _mockRepo;
        private string _locationUrl;
        private Mock<UrlHelper> _mockUrlHelper;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepo = new Mock<IStudentService>();
            _mockUrlHelper = new Mock<UrlHelper>();
            _locationUrl = "http://localhost:62850/v1/Student/";
        }

        [TestCleanup]
        public void Cleanup()
        {
            _mockRepo = null;
            _mockUrlHelper = null;
            _locationUrl = string.Empty;
        }

        [TestMethod]
        public void GetStudent_Returns_Student()
        {
            //Arrange
            var student = new Student
            {
                StudentId = 1234,
                FirstName = "Mike",
                LastName = "Peterson",
                Address = "1234 Main Street",
                Email = "mike_peterson@yahoo.com"
            };
            var studentModel = new StudentModel()
            {
                StudentId = 1234,
                FirstName = "Mike",
                LastName = "Peterson",
                Address = "1234 Main Street",
                Email = "mike_peterson@yahoo.com"
            };

            var service = new Mock<IStudentService>();
            service.Setup(x => x.GetById(student.StudentId)).Returns(student);
            var controller = new StudentController(service.Object);

            // Act
           var result = controller.GetStudent(1234);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}

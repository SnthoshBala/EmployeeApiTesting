using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiberConnection.Service;
using EmployeeAPI.Controllers;
using Moq;
using EmployeeAPI.FiberConnection;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTestAPI
{
    class UnitControllerTest
    {
        public Mock<IEmployeeServ<Employee>> emock;
        public Employee e;
        public EmployeeController ec;
        [SetUp]
        public void Setup()
        {
            emock = new Mock<IEmployeeServ<Employee>>();
            e = new Employee();
        }
        [Test]
        public void ValidGetEmployee()
        {
            emock.Setup(G => G.GetAllEmployees().Result).Returns(e.GetAllEmployees().Result);
            ec = new EmployeeController(emock.Object);
            var res = ec.GetAllEmployeesAsync().Result as OkObjectResult;
            Assert.AreEqual(200, res.StatusCode);
        }
        [Test]
        public void InValidGetEmployee()
        {
            emock.Setup(G => G.GetAllEmployees().Result).Returns(e.GetAllEmployees().Result);
            ec = new EmployeeController(emock.Object);
            var res = ec.GetAllEmployeesAsync().Result as OkObjectResult;
            Assert.AreEqual(500, res.StatusCode);
        }
        [Test]
        public void ValidGetByEmployeeId()
        {
            emock.Setup(G => G.GetByEmployee(200).Result).Returns(e.GetByEmployee(200).Result);
            ec = new EmployeeController(emock.Object);
            var res = ec.GetByEmployee(200).Result as OkObjectResult;
            Assert.AreEqual(200, res.StatusCode);
        }
        [Test]
        public void InValidGetByEmployeeId()
        {
            emock.Setup(G => G.GetByEmployee(0).Result).Returns(e.GetByEmployee(0).Result);
            ec = new EmployeeController(emock.Object);
            var res = ec.GetByEmployee(0).Result as OkObjectResult;
            Assert.AreEqual(500, res.StatusCode);
        }
    }
}

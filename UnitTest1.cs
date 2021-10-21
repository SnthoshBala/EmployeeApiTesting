using NUnit.Framework;
using EmployeeAPI.FiberConnection;
using FiberConnection.Service;
using Moq;

namespace EmployeeTestAPI
{
    public class Tests
    {
        public Employee e;
        public Employee eadd;
        public Employee einadd;
        public Employee eput;
        public Employee einput;
        public Employee valid;
        public Mock<IEmployeeServ<Employee>> emock;
        [SetUp]
        public void Setup()
        {
            e = new Employee();
            eadd = new Employee
            {
                EmployeeId = 210,
                Name = "Test",
                PhoneNumber = "9994632276",
                Age = 22,
                WorkLocation="Test",
                Address="Test",
                EmployeeMail="Test@gmail.com",
                EmployeePassword="Test",
            };
            einadd = new Employee
            {
                Name = "Test",
                PhoneNumber = "9994632276",
                Age = 22,
                WorkLocation = "Test",
                Address = "Test",
                EmployeeMail = "Test@gmail.com",
                EmployeePassword = "Test",
            };
            eput = new Employee
            {
                EmployeeId = 210,
                Name = "Test",
                PhoneNumber = "9994632276",
                Age = 22,
                WorkLocation = "Test",
                Address = "Test Edited",
                EmployeeMail = "Test@gmail.com",
                EmployeePassword = "Test",
            };
            einput = new Employee
            {
                Name = "Test",
                PhoneNumber = "9994632276",
                Age = 22,
                WorkLocation = "Test",
                Address = "Test",
                EmployeeMail = "Test@gmail.com",
                EmployeePassword = "Test",
            };
            valid = new Employee
            {
                EmployeeId=200,
                Name = "Bala",
                EmployeeMail = "balasb00714@gmail.com",
            };
            emock = new Mock<IEmployeeServ<Employee>>();
        }

        [Test]
        public void ValidGetEmployee()
        {
            emock.Setup(G => G.GetAllEmployees().Result).Returns(e.GetAllEmployees().Result);
            var res = e.GetByEmployee(200).Result;
            Assert.AreEqual(valid.Name,res.Name);
        }
        [Test]
        public void InValidGetEmployee()
        {
            emock.Setup(G => G.GetAllEmployees().Result).Returns(e.GetAllEmployees().Result);
            var res = e.GetByEmployee(201).Result;
            Assert.AreEqual(valid.Name, res.Name);
        }
        [Test]
        public void ValidAddEmployee()
        {
        emock.Setup(G => G.GetAllEmployees().Result).Returns(e.GetAllEmployees().Result);
        var res = e.AddEmpl(eadd).Result;
        Assert.AreEqual(res.Name, eadd.Name);
        }
        [Test]
        public void InValidAddEmployee()
        {
        emock.Setup(G => G.GetAllEmployees().Result).Returns(e.GetAllEmployees().Result);
        var res = e.AddEmpl(einadd).Result;
        Assert.AreEqual(res.Name, einadd.Name);
        }
        [Test]
        public void ValidPutEmployee()
        {
            emock.Setup(G => G.GetAllEmployees().Result).Returns(e.GetAllEmployees().Result);
            var res = e.UpdateEmp(eput.EmployeeId,eput).Result;
            Assert.AreEqual(res.Name, eadd.Name);
        }
        [Test]
        public void InValidPutEmployee()
        {
            emock.Setup(G => G.GetAllEmployees().Result).Returns(e.GetAllEmployees().Result);
            var res = e.UpdateEmp(einput.EmployeeId, eput).Result;
            Assert.AreEqual(res.Name, eadd.Name);
        }
        [Test]
        public void ValidDeleteEmployee()
        {
            emock.Setup(G => G.GetAllEmployees().Result).Returns(e.GetAllEmployees().Result);
            var res = e.DeleteEmployee(eadd.EmployeeId).Result;
            Assert.AreEqual(res.Name, eadd.Name);
        }
        [Test]
        public void InValidDeleteEmployee()
        {
            emock.Setup(G => G.GetAllEmployees().Result).Returns(e.GetAllEmployees().Result);
            var res = e.DeleteEmployee(501).Result;
            Assert.AreEqual(res.Name, eadd.Name);
        }
    }
}
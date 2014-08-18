using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeMgtServiceFixture.EmployeeServiceReference;
using System.Collections.Generic;

namespace EmployeeMgtServiceFixture
{
    
    [TestClass]
    public class EmployeeMgtFixture
    {
        CreateEmployeeServiceClient _writeClient = null;
        RetrieveEmployeeServiceClient _readClient = null;
        Employee _employee = null;
        List<Employee> _employeeList = null;
        Employee.Remark _remarkObject = null;
       
        [TestInitialize]
        public void InitTestData()
        {
            _writeClient = new CreateEmployeeServiceClient("BasicHttpBinding_ICreateEmployeeService");
            _readClient = new RetrieveEmployeeServiceClient("WSHttpBinding_IRetrieveEmployeeService");
            _employee = new Employee();
            _employee.Remarks = new List<Employee.Remark>();
            _remarkObject = new Employee.Remark();
            _employeeList = new List<Employee>();
             SetupTestData.FillTestData(_employeeList);
            
       }

      
       [TestMethod]
        public void createEmployeeTest()
        {
            _employee.Name = "Priti";
            _employee = _writeClient.CreateEmployee(_employee);
            _employeeList.Add(_employee);
            Assert.AreEqual("Priti",_employeeList[_employeeList.Count-1].Name);
        }

        [TestMethod]
        public void searchByNameTest()
        {
            _employee.Name = "Priti";
            _employee = _writeClient.CreateEmployee(_employee);

            _remarkObject._remark = "Hello Priti";
            _remarkObject._remarkTime = DateTime.Now;
            _employee.Remarks.Add(_remarkObject);


            Employee e = _readClient.SearchByName("Priti");
            Assert.AreEqual("Priti", e.Name);
        }

        [TestMethod]
        public void serachByIdTest()
        {
            _employee.Name = "Priti";
            _employee = _writeClient.CreateEmployee(_employee);

            _remarkObject._remark = "Hello Priti";
            _remarkObject._remarkTime = DateTime.Now;
            _employee.Remarks.Add(_remarkObject);

            Employee e = _readClient.SearchById(_employee.Id);
            Assert.AreEqual(_employee.Id, e.Id);
        }

        [TestMethod]
        public void GetAllEmployeesTest()
        {
            _employeeList = new List<Employee>();
            _employee.Name = "Priti";
            _employee = _writeClient.CreateEmployee(_employee);
            _remarkObject._remark = "Hello Priti";
            _remarkObject._remarkTime = DateTime.Now;
            _employee.Remarks.Add(_remarkObject);
            _employeeList.Add(_employee);

            _employee.Name = "ABC";
            _employee = _writeClient.CreateEmployee(_employee);
            _remarkObject._remark = "Hello ABC";
            _remarkObject._remarkTime = DateTime.Now;
            _employee.Remarks.Add(_remarkObject);
            _employeeList.Add(_employee);

            List<Employee> empList = new List<Employee>();
            empList = _readClient.GetAllEmployees();
            Assert.AreEqual(_employeeList.Count, empList.Count);
        }
    }
}

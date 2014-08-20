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
            if (_writeClient != null && _writeClient.State == System.ServiceModel.CommunicationState.Opened) _writeClient.Close();
            if (_readClient != null && _readClient.State == System.ServiceModel.CommunicationState.Opened) _readClient.Close();
            _writeClient = new CreateEmployeeServiceClient("BasicHttpBinding_ICreateEmployeeService");
            _readClient = new RetrieveEmployeeServiceClient("WSHttpBinding_IRetrieveEmployeeService");
            _employee = new Employee();
            _employee.Remarks = new List<Employee.Remark>();
            _remarkObject = new Employee.Remark();
            _employeeList = new List<Employee>();
          }


        [TestMethod]
        public void CreateEmployeeTest()
        {
            string name = "Priti";
            _employee = _writeClient.CreateEmployee(name);
            _employeeList.Add(_employee);
            Assert.AreEqual("Priti", _employeeList[_employeeList.Count - 1].Name);
        }

        [TestMethod]
        public void AddRemarkTest()
        {
            string name = "EFG";
            _employee = _writeClient.CreateEmployee(name);
            _writeClient.AddRemarks(_employee.Id, "Hello EFG");

            Employee e = _readClient.SearchByName("EFG");
            Assert.AreEqual("Hello EFG", e.Remarks[e.Remarks.Count - 1]._remark);
        }

        [TestMethod]
        public void SearchByNameTest()
        {
            string name = "XYZ";
            _employee = _writeClient.CreateEmployee(name);

            Employee e = _readClient.SearchByName("XYZ");
            Assert.AreEqual("XYZ", e.Name);
        }

        [TestMethod]
        public void SerachByIdTest()
        {
            string name = "LMN";
            _employee = _writeClient.CreateEmployee(name);

            _remarkObject._remark = "Hello LMN";
            _remarkObject._remarkTime = DateTime.Now;
            _employee.Remarks.Add(_remarkObject);

            Employee e = _readClient.SearchById(_employee.Id);
            Assert.AreEqual(_employee.Id, e.Id);
        }


        [TestMethod]
        public void GetAllEmployeesTest()
        {
            _employeeList = new List<Employee>();
             string name = "STU";
            _employee = _writeClient.CreateEmployee(name);
            _remarkObject._remark = "Hello STU";
            _remarkObject._remarkTime = DateTime.Now;
            _employee.Remarks.Add(_remarkObject);
            _employeeList.Add(_employee);

            name = "ABC";
            _employee = _writeClient.CreateEmployee(name);
            _remarkObject._remark = "Hello ABC";
            _remarkObject._remarkTime = DateTime.Now;
            _employee.Remarks.Add(_remarkObject);
            _employeeList.Add(_employee);

            List<Employee> empList = new List<Employee>();
            empList = _readClient.GetAllEmployees();
        }
        
        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException<FaultExceptionContract>))]
        public void AddRemarkException()
        {
            _writeClient.AddRemarks(new Guid(), "Hello whatever");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException<FaultExceptionContract>))]
        public void SearchByNameTestException()
        {
            Employee e = _readClient.SearchByName("idfdiu");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException<FaultExceptionContract>))]
        public void SearchByIdTestException()
        {
            Employee e = _readClient.SearchById(new Guid());
        }

        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException))]
        public void CreateEmployeeInputTest()
        {
            string name = "1111";
            _employee = _writeClient.CreateEmployee(name);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException))]
        public void AddRemarkInputTest()
        {
            string name = "EFG";
            _employee = _writeClient.CreateEmployee(name);
            _writeClient.AddRemarks(_employee.Id, "Hello 123");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException))]
        public void SearchByNameInputTest()
        {
            string name = "XYZ";
            _employee = _writeClient.CreateEmployee(name);
            Employee e = _readClient.SearchByName("123");
        }
    }
}

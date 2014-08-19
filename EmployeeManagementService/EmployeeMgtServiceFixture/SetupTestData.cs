using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeMgtServiceFixture.EmployeeServiceReference;

namespace EmployeeMgtServiceFixture
{
    static class SetupTestData
    {
       public static void FillTestData(List<Employee> employeeList)
        {
            Employee _employee = new Employee();
            _employee.Id = new Guid();
            _employee.Name = "XYZ";
            _employee.Remarks = new List<Employee.Remark>();
            Employee.Remark _remarkObject = new Employee.Remark();
            _remarkObject._remark = "Not set yet";
            _remarkObject._remarkTime = DateTime.MinValue;
            _employee.Remarks.Add(_remarkObject);
            employeeList.Add(_employee);
        }
    }
}

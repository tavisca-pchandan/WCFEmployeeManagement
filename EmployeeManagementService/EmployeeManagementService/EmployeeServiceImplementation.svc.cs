using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeManagementService
{
    
    public class EmployeeServiceImplementation : ICreateEmployeeService,IRetrieveEmployeeService
    {
        /*To Do :
        1.Use proper method to persist the data... Remove Static
        2. See how to throw conditional exception
         */
        public static List<Employee> _employeeList = new List<Employee>();

        public Employee CreateEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employee.Remarks = new List<Employee.Remark>();
            employee.Remarks.Add(new Employee.Remark(DateTime.MinValue, null));
            if (_employeeList == null)
                throw new FaultException("Dataholder object does not found");
            _employeeList.Add(employee);
            return employee;
        
        }

        public string AddRemarks(Guid id, string remark)
        {
            foreach (Employee employee in _employeeList)
            {
                if (employee.Id.Equals(id))
                {
                    employee.Remarks.Add(new Employee.Remark(System.DateTime.Now, remark));
                    return "Remark Added Successfully...";
                }
            }
            throw new FaultException("Record does not found");
        }

        public List<Employee> GetAllEmployees()
        {
            //if (_employeeList.Count == 0)
            //    throw new FaultException("Empty Database");
            try
            {
                return _employeeList;
            }
            catch
            {
                FaultExceptionContract _faultcontract = new FaultExceptionContract();
                _faultcontract.StatusCode = "Empty Database";
                _faultcontract.Message = "Database does not contains any data";
                _faultcontract.Description = "Error occurred in service";
                throw new FaultException<FaultExceptionContract>(_faultcontract);
            }
        }

        public Employee GetEmployee(Guid id)
        {
            foreach (Employee employee in _employeeList)
            {
                if (employee.Id.Equals(id))
                    return employee;
            }
            throw new FaultException("Record does not found");
        }

        public Employee GetEmployee(string name)
        {
            foreach (Employee employee in _employeeList)
            {
                if (employee.Name == name)
                    return employee;
            }
            throw new FaultException("Record does not found");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeManagementService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class EmployeeServiceImplementation : ICreateEmployeeService, IRetrieveEmployeeService
    {
        /*To Do :
        1.Use proper method to persist the data... Remove Static
        2. Create and through Custom Exception for EmployeeNotFount rather than throwing ArgumentException
         */
        public static List<Employee> _employeeList = new List<Employee>();

        public Employee CreateEmployee(string name)
        {
            try
            {
                Employee employee = new Employee();
                employee.Id = Guid.NewGuid();
                employee.Name = name;
                employee.Remarks = new List<Employee.Remark>();
                employee.Remarks.Add(new Employee.Remark(DateTime.MinValue, null));
                if (_employeeList == null)
                    throw new ArgumentNullException("Dataholder object is not present.");
                _employeeList.Add(employee);
                return employee;

            }
            catch (ArgumentNullException e)
            {
                FaultExceptionContract faultContract = new FaultExceptionContract();
                faultContract.StatusCode = "Empty Database";
                faultContract.Message = "Database does not contains any data";
                faultContract.Description = "Error occurred in service";
                throw new FaultException<FaultExceptionContract>(faultContract, new FaultReason(e.Message));
            }

        }

        public void AddRemarks(Guid id, string remark)
        {
            try
            {
                var employee = _employeeList.Where(e => e.Id == id).FirstOrDefault();
                if (employee == null) throw new ArgumentException("Employee not found");
                employee.Remarks.Add(new Employee.Remark(System.DateTime.Now, remark));
            }
            catch (ArgumentException e)
            {
                FaultExceptionContract faultContract = new FaultExceptionContract();
                faultContract.StatusCode = "Data not fount";
                faultContract.Message = "Database does not contains such record";
                faultContract.Description = "Error occurred in service";
                throw new FaultException<FaultExceptionContract>(faultContract, new FaultReason(e.Message));
            }
            catch (CommunicationException e1)
            {
                FaultExceptionContract faultContract = new FaultExceptionContract();
                faultContract.StatusCode = "Data not fount";
                faultContract.Message = "Database does not contains such record";
                faultContract.Description = "Error occurred in service";
                throw new FaultException<FaultExceptionContract>(faultContract, new FaultReason(e1.Message));
            }
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                return _employeeList;
            }
            catch
            {
                FaultExceptionContract faultContract = new FaultExceptionContract();
                faultContract.StatusCode = "Empty Database";
                faultContract.Message = "Database does not contains any data";
                faultContract.Description = "Error occurred in service";
                throw new FaultException<FaultExceptionContract>(faultContract);
            }
        }

        public Employee GetEmployee(Guid id)
        {
            try
            {
                var employee = _employeeList.Where(e => e.Id == id).FirstOrDefault();
                if (employee == null) throw new ArgumentException("Employee not found");
                return employee;
            }
            catch (ArgumentException e)
            {
                FaultExceptionContract faultContract = new FaultExceptionContract();
                faultContract.StatusCode = "Data not fount";
                faultContract.Message = "Database does not contains such record";
                faultContract.Description = "Error occurred in service";
                throw new FaultException<FaultExceptionContract>(faultContract, new FaultReason(e.Message));
            }
        }

        public Employee GetEmployee(string name)
        {
            try
            {
                var employee = _employeeList.Where(e => e.Name.Equals(name)).FirstOrDefault();
                if (employee == null) throw new ArgumentException("Employee not found");
                return employee;
            }
            catch (ArgumentException e)
            {
                 FaultExceptionContract faultContract = new FaultExceptionContract();
                faultContract.StatusCode = "Data not fount";
                faultContract.Message = "Database does not contains such record";
                faultContract.Description = "Error occurred in service";
                throw new FaultException<FaultExceptionContract>(faultContract, new FaultReason(e.Message));
            }
        }
    }
}

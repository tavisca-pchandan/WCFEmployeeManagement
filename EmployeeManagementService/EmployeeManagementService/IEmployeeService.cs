using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeManagementService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICreateEmployeeService
    {
        [OperationContract]
        Employee CreateEmployee(Employee e);

        [OperationContract]
        string AddRemarks(Guid id, string remark); 
    }

    [ServiceContract]
    public interface IRetrieveEmployeeService
    {
        [OperationContract]
        [FaultContract(typeof(FaultExceptionContract))]
        List<Employee> GetAllEmployees();
        
       [OperationContract(Name = "SearchById")]
        Employee GetEmployee(Guid Id);

        [OperationContract(Name = "SearchByName")]
        Employee GetEmployee(string Name);
    }

    [DataContract]
    public class Employee
    {
        public Employee()
        {
            this.Remarks = new List<Remark>();
            Remarks.Add(new Employee.Remark(DateTime.MinValue, null));
        }


        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataContract]
        public class Remark
        {
           [DataMember]
            public DateTime _remarkTime;
           [DataMember]
            public string _remark;

           public Remark()
           {

           }
            public Remark(DateTime dateTime,string remark)
            {
                this._remarkTime = dateTime;
                this._remark = remark;
            }
        }

        [DataMember]
        public List<Remark> Remarks = new List<Remark>();
    }
    
}

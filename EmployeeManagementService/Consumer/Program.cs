using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consumer.EmployeeServiceReference;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new CreateEmployeeServiceClient("BasicHttpBinding_ICreateEmployeeService");
            var retrieveClient = new RetrieveEmployeeServiceClient("WSHttpBinding_IRetrieveEmployeeService");
            try
            {
               
                int choice = 0;
                do
                {
                    Console.WriteLine("\nEmployee Management Service");
                    Console.WriteLine("1.Add new Employee\n2.Add Remarks\n3.Search Employee by Id\n4.Search Employee by Name\n5.Get All Employee Details\n6.Exit");
                    Console.WriteLine("Enter your choice : ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Employee Name : ");
                            string name = Console.ReadLine();
                            Employee newEmployee = new Employee();
                            newEmployee.Name = name;
                            newEmployee = client.CreateEmployee(newEmployee);
                            Console.WriteLine("Employee created with Id : {0}", newEmployee.Id);
                            break;

                        case 2:
                            Console.WriteLine("Enter Employee ID : ");
                            string id = Console.ReadLine();
                            if (id.Length != 36)
                                //throw new InvalidGuidException();
                            Console.WriteLine("Enter the Remark : ");
                            string remark = Console.ReadLine();
                            string status = client.AddRemarks(new Guid(id), remark);
                            Console.WriteLine(status);
                            break;

                        case 3:
                            Console.WriteLine("Enter Employee ID : ");
                            id = Console.ReadLine();
                            Employee employee = retrieveClient.SearchById(new Guid(id));
                            Console.WriteLine("ID : " + employee.Id + "\nName : " + employee.Name);
                            Console.WriteLine("Posted on\tRemark");
                            foreach (var r in employee.Remarks)
                            {
                                Console.WriteLine(r._remarkTime + "\t" + r._remark);
                            }
                            break;

                        case 4:
                            Console.WriteLine("Enter Employee Name : ");
                            name = Console.ReadLine();
                            employee = retrieveClient.SearchByName(name);
                            Console.WriteLine("ID : " + employee.Id + "\nName : " + employee.Name);
                            Console.WriteLine("Posted on\tRemark");
                            foreach (var r in employee.Remarks)
                            {
                                Console.WriteLine(r._remarkTime + "\t" + r._remark);
                            }

                            break;

                        case 5:
                            Console.WriteLine("Employee Data");
                            List<Employee> empData = new List<Employee>();
                            empData.AddRange(retrieveClient.GetAllEmployees());
                            foreach (Employee emp in empData)
                            {
                                Console.WriteLine("ID : " + emp.Id + "\nName : " + emp.Name);
                                Console.WriteLine("Posted on\tRemark");
                                if (emp.Remarks != null)
                                    foreach (var r in emp.Remarks)
                                    {
                                        Console.WriteLine(r._remarkTime + "\t" + r._remark);
                                    }
                            }
                            break;

                        case 6:
                            break;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                } while (choice != 6);
                //var employeeObject = new EmployeeWcf.EmployeeService();
            }
            catch (TimeoutException timeProblem)
            {
                Console.WriteLine("The service operation timed out. " + timeProblem.Message);
                Console.ReadLine();
                client.Abort();
            }
            catch (System.ServiceModel.FaultException<FaultExceptionContract> Fault)
            {
                Console.WriteLine(Fault.Detail.Message);
                Console.WriteLine(Fault.Detail.StatusCode);
                Console.WriteLine(Fault.Detail.Description);
                Console.ReadLine();
                client.Abort();
            }
            catch (System.ServiceModel.FaultException unknownFault)
            {
                Console.WriteLine("An unknown exception was received. " + unknownFault.Message);
                Console.ReadLine();
                client.Abort();
            }
            catch (System.ServiceModel.CommunicationException commProblem)
            {
                Console.WriteLine("There was a communication problem. " + commProblem.Message + commProblem.StackTrace);
                Console.ReadLine();
                client.Abort();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
using Lab1_ASPNetConnectedMode.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Lab1_ASPNetConnectedMode.BLL
{
    public class Employee
    {
        //private variables
        private int employeeId;
        private string firstName;
        private string lastName;
        private string jobTitle;

        //properties
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }

        //custom methods
        public void SaveEmployee(Employee emp)
        {
            EmployeeDB.SaveRecord(emp);
        }

       public List<Employee> GetAllEmployees()
       {
            return EmployeeDB.GetAllRecords();
       }



        public Employee SearchEmployee(int custId)
        {
            return EmployeeDB.SearchRecord(custId);
        }

        public List<Employee> SearchEmployee(string searchTerm, string field)
        {
            return EmployeeDB.SearchRecord(searchTerm, field);
        }

        public bool IsDuplicateEmployeeId(int empId)
        {
            return EmployeeDB.IsDuplicateId(empId);
        }

        public void UpdateEmployee(Employee emp)
        {
            EmployeeDB.UpdateRecord(emp);
        }    

        public void DeleteEmployee(int empId)
        {
            EmployeeDB.DeleteRecord(empId);
        }

     
    }
}
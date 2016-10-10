using System;
using System.Collections.Generic;
using System.IO;

namespace _12_Employee
{
    internal class EmployeeRepository
    {
        int id = 0;
        List<IEmployee> empList = new List<IEmployee>();
        
        internal void Clear()
        {
            empList.Clear();
        }

        internal int CountEmployees()
        {
            int empCounted = empList.Count;

            return empCounted;
        }

        internal int NextId()
        {
            id++;
            return id;
        }

        internal IEmployee CreateEmployee(string _name, string _position)
        {
            IEmployee employee = new Employee();
            
            employee.Name = _name;
            employee.Type = _position;
            employee.Id = NextId();
            empList.Add(employee);
            return employee;
        }

        internal void SaveEmployee(IEmployee employee)
        {
            StreamWriter sw = new StreamWriter("employeeList.txt");
            sw.WriteLine(employee.ToString());
            sw.Close();
        }

        internal IEmployee LoadEmployee(int id)
        {
            foreach (var employee in empList)
            {
                if (employee.Id == id)
                {
                    return employee;
                }
                
            }
            return null;
        }

        internal List<IEmployee> FindAllEmployees()
        {
            return empList;
        }
    }
}
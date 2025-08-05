using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject.Dao
{
    public class EmployeeDaoImpl : EmployeeDao
    {
        static List<Employee> employeelist;
        static EmployeeDaoImpl()
        {
           employeelist = new List<Employee>();
        }

        public string AddEmployee(Employee employee)
        {
            employeelist.Add(employee);
            return "Employee Record Inserted";
        }

        public string DeleteEmployeeDao(int e)
        {
            Employee employee = SearchEmployeeDao(e);
            if (employee != null)
            {
                employeelist.Remove(employee);
                return "Employee Record Delete Successfully..";
            }
            return "Employee Recorf Deleted Succesffully";
        }

        public string ReadFromFileDao()
        {
            FileStream fs = new FileStream(@"E:\FileHandling\abc.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            employeelist = (List<Employee>)formatter.Deserialize(fs);
            return "Data Retrieved from the file successfully";
        }

        public Employee SearchEmployeeDao(int e)
        {
            Employee employeeFound = null;
            foreach(Employee employee in employeelist)
            {
                employeeFound = employee;
                break;
            }
            return employeeFound;

        }

        public List<Employee> ShowEmployeeDao()
        {
            return employeelist;
        }

        public string UpdateEmployeeDao(Employee e)
        {
            Employee employeeFound = SearchEmployeeDao(e.Empno);
            if (employeeFound != null)
            {
                {
                    employeeFound.Name = e.Name;
                    employeeFound.Gender = e.Gender;
                    employeeFound.Dept = e.Dept;
                    employeeFound.Desig = e.Desig;
                    employeeFound.Basic = e.Basic;
                }
                return "Employee Record Update";

            }
            return "Employee Record not found";
        }

        public string WriteToFileDao()
        {
            FileStream fs = new FileStream(@"E:\FileHandling\abc.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, employeelist);
            fs.Close();
            return "Data Stroed in files successfully";
        }
    }
}

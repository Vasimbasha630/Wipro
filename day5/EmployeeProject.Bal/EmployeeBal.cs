using EmployeeProject.Dao;
using EmployeeProject.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject.Bal
{
    public class EmployeeBal
    {
        public static StringBuilder sb = new StringBuilder();
        public static EmployeeDaoImpl daoImpl;

        static EmployeeBal()
        {
            daoImpl = new EmployeeDaoImpl();
        }
        public List<Employee> ShowEmployeeBal()
        {
            return daoImpl.ShowEmployeeDao();
        }

        public string WriteFileBal()
        {
            return daoImpl.WriteToFileDao();
        }

        public string ReadFileBal()
        {
            return daoImpl.ReadFromFileDao();
        }

        public string DeleteEmployeBal(int empno)
        {
            return daoImpl.DeleteEmployeeDao(empno);    
        }


        public string UpdateEmployBal(Employee e)
        {
            if(ValidateEmploye(e)== true) 
                {
                    return daoImpl.UpdateEmployeeDao(e);
                }
            throw new EmployeeException(sb.ToString());

        }

        public Employee SearchEmployeeBal(int e)
        {
            return daoImpl.SearchEmployeeDao(e);
        }
        public string AddEmployeeBal(Employee employee)
        {
            if (ValidateEmploye(employee) == true)
            {
                return daoImpl.AddEmployee(employee);
            }
            throw new EmployeeException(sb.ToString());
        }
        
        public static bool ValidateEmploye(Employee employee)
        {
            bool flag = true;
            if (employee.Empno <=0)
            {
                sb.Append("Employee No Cannot be zero or negative...\n");
                flag = false;
            }
            if(employee.Name.Length<5)
            {
                sb.Append("Employee Name contains Min 5 characters...\n");
                flag = false;
            }
            if(employee.Basic <10000|| employee.Basic>80000)
            {
                sb.Append("Basic Must be Between 100000 and 80000..\n");
                flag = false;
            }
            return flag;
        }

    }
}

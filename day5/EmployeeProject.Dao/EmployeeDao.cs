using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeProject;
namespace EmployeeProject.Dao
{
    internal interface EmployeeDao
    {
        string AddEmployee(Employee employee);

        List<Employee> ShowEmployeeDao();

        Employee SearchEmployeeDao(int e);

        string UpdateEmployeeDao(Employee e);

        string DeleteEmployeeDao(int e);

        string WriteToFileDao();

        string ReadFromFileDao();

    }
}

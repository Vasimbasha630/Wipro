using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject.Tests
{
    [TestFixture]
    public class EmployeeTest
    {
        [Test]
        public void TestSearchEmployee()
        {
            EmployeeDao employeeDao = new EmployeeDao();
            Employee e = employeeDao.SearchEmployee(1);
            Assert.IsNotNull(e);
            e = employeeDao.SearchEmployee(-1);
            Assert.Null(e);
        }



        [Test]
        public void TestShowEmploye()
        {
            
                List<Employee> employList = new EmployeeDao().ShowEmployee();
                Assert.AreEqual(2, employList.Count);
  
        }

        [Test]
        public void TestToString()
        {
            Employee emp = new Employee();
            emp.Id = 1;
            emp.Name = "Vasim";
            emp.Basic = 8888;
            string expected = "Id 1 Name Vasim Basic 8888";
            Assert.AreEqual(expected, emp.ToString());
        }


        [Test]
        public void TestGettersAndSetters()
        {
            Employee emp = new Employee();
            emp.Id = 1;
            emp.Name = "Vasim";
            emp.Basic = 8888;
        }

        [Test]  
        public void TestConstructor()
        {
            Employee employee = new Employee();
            Assert.NotNull(employee);
            Employee employee2 = new Employee(1, "Vasim", 8888);
            Assert.AreEqual(1, employee2.Id);
            Assert.AreEqual("Vasim",employee2.Name);
            Assert.AreEqual(8888, employee2.Basic);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePoject;
using EmployeeProject;
using EmployeeProject.Bal;
using EmployeeProject.Exception;

namespace EmployeePoject.MainOne
{
    internal class Program
    {
        static EmployeeBal employeeBal;
        static Program()
        {
            employeeBal = new EmployeeBal();
        }

        public static void WriteFileMain()
        {
            Console.WriteLine(employeeBal.WriteFileBal());
        }

        public static void ReadFileMain()
        {
            Console.WriteLine(employeeBal.ReadFileBal());
        }

        public static void DeleteEmployMain()
        {
            int empno;
            Console.WriteLine("Enter employee Number");
            empno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(employeeBal.DeleteEmployeBal(empno));
        }


        public static void UpdateEmployeeMain()
        {
            Employee e = new Employee();
            Console.WriteLine("Enter Employee Number");
            e.Empno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Employee Name ");
            e.Name = Console.ReadLine();
            Console.WriteLine("Enter Gender(Male/Female)");
            e.Gender = Console.ReadLine();
            Console.WriteLine("Enter the Department");
            e.Dept= Console.ReadLine();
            Console.WriteLine("Enter the Designation");
            e.Desig= Console.ReadLine();
            Console.WriteLine("Enter the basics");
            e.Basic= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(employeeBal.UpdateEmployBal(e));

        }

        public static void SearchEmployeeMain()
        {
            int empno;
            Console.WriteLine("Enter Employee Number");
            empno = Convert.ToInt32(Console.ReadLine());
            Employee employee = employeeBal.SearchEmployeeBal(empno);
            if(employee != null)
            {
                Console.WriteLine(employee);
            }
            else
            {
                Console.WriteLine("***Employee record not found**");
            }
        }

        public static void ShowEmployeeMain()
        {
            List<Employee> employeeList = employeeBal.ShowEmployeeBal();
            foreach(Employee employee in employeeList)
            {
                Console.WriteLine(employee);
            }
        }
        public static void AddEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("Enter Employee Number");
            employee.Empno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter employee Name ");
            employee.Name = Console.ReadLine();
            Console.WriteLine("Enter Gender (Male/Female)");
            employee.Gender = Console.ReadLine();
            Console.WriteLine("Enter Department");
            employee.Dept = Console.ReadLine();
            Console.WriteLine("Enter the Designation");
            employee.Desig = Console.ReadLine();
            Console.WriteLine("Enter the Basic");
            employee.Basic = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(employeeBal.AddEmployeeBal(employee));

            

        }
        static void Main(string[] args)
        {
            int choice;
            do
            {

                Console.WriteLine(" O  P  T I O N S");
                Console.WriteLine("*-------------------------*");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. show Employee");
                Console.WriteLine("3. Search Employee");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Write to  Employee");
                Console.WriteLine("7. Resd From Employee");
                Console.WriteLine("Enter your Choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        try
                        {
                            AddEmployee();
                        }
                        catch(EmployeeException e)
                        {
                            Console.WriteLine(e.Message);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 2:
                        ShowEmployeeMain();
                        break;
                    case 3:
                        SearchEmployeeMain();
                        break;
                    case 4:
                        try
                        {
                            UpdateEmployeeMain();
                        }
                        catch(EmployeeException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                        case 5:
                            DeleteEmployMain();
                        break;
                        case 6: 
                            WriteFileMain();
                        break;
                        case 7:
                            ReadFileMain(); 
                        break;
                    case 8:
                        return;


                }
            } while (choice != 8);


        }
    }
}

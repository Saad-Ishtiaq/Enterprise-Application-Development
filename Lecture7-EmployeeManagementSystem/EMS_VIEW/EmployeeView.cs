using EMS_BLL;
using EMS_BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS_VIEW
{
    public class EmployeeView
    {
        public void GetInput()
        {

            Console.WriteLine("Enter Employee Name:");
            string empName=Console.ReadLine();
            
            Console.WriteLine("Enter Employee Age:");
            int empAge = System.Convert.ToInt32( Console.ReadLine());
            EmployeeBO bo = new EmployeeBO { Name = empName, Age = empAge } ;
            EmployeeBLL bll = new EmployeeBLL();
            bll.SaveEmployeeLogic(bo);
        }

        public void Display()
        {
            EmployeeBLL bll = new EmployeeBLL();
            List<EmployeeBO> empBo= bll.ReadEmployeeLogic();
            foreach(EmployeeBO s in empBo)
            {
                Console.WriteLine($"Name: {s.Name,-10} Age: {s.Age,-5} Salary: {s.Salary,10:C}");
            }

        }
    }
}

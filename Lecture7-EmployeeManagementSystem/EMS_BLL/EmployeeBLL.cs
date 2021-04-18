using EMS_BO;
using EMS_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS_BLL
{
    public class EmployeeBLL
    {
        public void SaveEmployeeLogic(EmployeeBO bo)
        {
            if(bo.Age<=20)
            {
                bo.Salary = 50_000;
            }
            else
            {
                bo.Salary = 100_000;
            }
            EmployeeDAL dal = new EmployeeDAL();
            dal.SaveEmployee(bo);
        }
        
        public List<EmployeeBO> ReadEmployeeLogic()
        {
            EmployeeDAL dal = new EmployeeDAL();
            return dal.ReadEmployee();
        }


    }
}

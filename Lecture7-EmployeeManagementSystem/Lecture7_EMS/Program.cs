using EMS_BO;
using EMS_VIEW;
using System;

namespace Lecture7_EMS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------This is our First N-Tier Architecture Code------------");
            EmployeeView view= new EmployeeView();
            //view.GetInput();

            view.Display();

        }
    }
}

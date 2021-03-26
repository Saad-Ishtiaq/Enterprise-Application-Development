using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PosSaleBO
{
    //Sale class
    public class SaleBO
    {
        public static int saleCounter = GetCounter();


        //Setting up Counter Value
        //Counts no of lines and then assigns id accordingly
        public static int GetCounter()
        {
            string filepath = Path.Combine(Environment.CurrentDirectory, "SaleDataBase.txt");
            StreamReader sr = new StreamReader(filepath);
            string line = String.Empty;
            int rc = 1;

            while ((line = sr.ReadLine()) != null)
            {
                rc++;
            }
            sr.Close();
            return rc;
        }
        

        public int SaleID;
        public int CustomerID;
        public bool Status { get; set; }
        public SaleBO()
        {
            SaleID = saleCounter;
            saleCounter++;
            Status = false;
        }
        
        public string SaleDate { get; set; }
        




    }
}

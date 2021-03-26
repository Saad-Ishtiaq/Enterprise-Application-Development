using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PosSaleLineItemBO
{   
    //SaleLineItem class 
    public class SaleLineItemBO
    {
        public static int saleLineCounter = GetCounter();

        //Setting up Counter Value
        //Counts no of lines and then assigns id accordingly
        public static int GetCounter()
        {
            string filepath = Path.Combine(Environment.CurrentDirectory, "SaleLineItemDataBase.txt");
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

        public int LineNo;

        public SaleLineItemBO()
        {
            LineNo = saleLineCounter;
            saleLineCounter++;
        }
        
        public int SaleID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }


    }
}

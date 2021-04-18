using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PosItemBO
{

    //Item Class
    public class ItemBO
    {
        public static int itemCounter=GetCounter();

        //Setting up Counter Value
        //Counts no of lines and then assigns id accordingly
        public static int GetCounter()
        {
            string filepath = Path.Combine(Environment.CurrentDirectory, "ItemDataBase.txt");
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
        

        public int ItemID;
        public ItemBO ()
        {
            ItemID=itemCounter;
            itemCounter++;
        }        
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string CreationDate { get; set; }
    }
}

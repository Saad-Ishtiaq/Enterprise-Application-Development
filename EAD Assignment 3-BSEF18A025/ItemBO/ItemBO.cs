using System;
using System.Collections.Generic;
using System.Text;

namespace ItemBO
{
    public class ItemBO
    {
        static int ItemID=1;
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

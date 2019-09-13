using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; 

namespace TaxFinderReceiptGatherer.Model

{
    public class Receipt
    {
            public decimal Alv24 { get; set; }
            public decimal Alv14 { get; set; }
            public decimal Alv10 { get; set; }
            public decimal Alv0 { get; set; }
            public IFormFile AlvImg { get; set; }

       }
}

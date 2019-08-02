using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; 

namespace TaxFinderReceiptGatherer.Model

{
    public class Receipt
    {
            public Double Alv24 { get; set; }
            public Double Alv12 { get; set; }
            public Double Alv10 { get; set; }
            public Double Alv0 { get; set; }
            public IFormFile AlvImg { get; set; }

       
       }
}

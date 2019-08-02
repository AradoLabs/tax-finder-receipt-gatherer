using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using TaxFinderReceiptGatherer.Model;

namespace TaxFinderReceiptGatherer.Controllers
{

    [Route("api/[controller]")]
    // ^ määrittää reititityksen: api/ + controllerin nimi (ilman sanaa 'controller')
    // Portti on määritelty tiedostossa "launchSettings.json" (sslPort, koska https)
    // Koko url siis:
    // https://localhost:44397/api/receipt
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        [HttpPost]
        public void Post([FromForm] Receipt receipt)
        {
            // Käsittele kuitti!
        }

       [HttpGet]
        public ActionResult Get()
        {
            // Tällä on helppo testata onko api "elossa" :)
            return Ok("I'm alive!");
        }
    }
}

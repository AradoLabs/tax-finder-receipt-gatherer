using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

using TaxFinderReceiptGatherer.Model;

namespace TaxFinderReceiptGatherer.Controllers
{

   
    // ^ määrittää reititityksen: api/ + controllerin nimi (ilman sanaa 'controller')
    // Portti on määritelty tiedostossa "launchSettings.json" (sslPort, koska https)
    // Koko url siis:
    // https://localhost:44397/api/receipt
    [ApiController]
    public class ReceiptController : ControllerBase
    {

        [Route("api/receipt")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] Receipt receipt)
        {

            if (receipt != null)
            {
                // Käsittele kuitti!
                //Tallennetaan kuva Azureen
                await UploadFileToStorage(receipt.AlvImg, receipt.AlvImg.FileName, new AzureStorageConfig());
            }

            // Tähän badRequest tai Try/Catch    
            // tähän palautetaan takaisin sivustolle
            return Redirect("/");
        }

        public static async Task<bool> UploadFileToStorage(IFormFile formFile, string fileName, AzureStorageConfig _storageConfig)
        {

            // Create storagecredentials object by reading the values from the configuration (appsettings.json)
             StorageCredentials storageCredentials = new StorageCredentials(_storageConfig.AccountName, _storageConfig.AccountKey);

            // Create cloudstorage account by passing the storagecredentials
            CloudStorageAccount storageAccount = new CloudStorageAccount(storageCredentials, true);

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Get reference to the blob container by passing the name by reading the value from the configuration (appsettings.json)
            CloudBlobContainer container = blobClient.GetContainerReference(_storageConfig.ImageContainer);

            // Get the reference to the block blob from the container
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);


            using (var stream = new MemoryStream())
            {
                formFile.CopyTo(stream);
                await blockBlob.UploadFromStreamAsync(stream);
            }
            // Upload the file
            

            return await Task.FromResult(true);
        }
        [Route("api/receipt")]
        [HttpGet]
        public ActionResult Get()
        {
            // Tällä on helppo testata onko api "elossa" :)
           return Ok("I'm alive!");
         

  
            }
        }
    }

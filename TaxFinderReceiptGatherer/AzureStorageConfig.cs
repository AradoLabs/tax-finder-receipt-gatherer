//huom! ei githubiin
//save images to azure blob 
//falvstoragaAccesskeys

using System;

namespace TaxFinderReceiptGatherer
{
    public class AzureStorageConfig
    {
        public string AccountName = "falvstorage";
        public string AccountKey = "n4mFCqPpfA/+J3eKiU6y/GMZiTZufeAaVCYb7ZMWYQjnqmv3Qm5DnFK+Ok9rUerH/ykr6rcpx0TzDvlbAo2NZg==";
        public string ImageContainer = "receiptimages";
    }
}
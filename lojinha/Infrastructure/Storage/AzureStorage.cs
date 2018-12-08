using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace lojinha.Infrastructure.Storage
{
    public class AzureStorage
    {
        private readonly CloudStorageAccount _account;
        public AzureStorage(IConfiguration config)
        {
            _account = CloudStorageAccount.Parse(
                config.GetSection("Azure:Storage").Value);
        }
    }
}

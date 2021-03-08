using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngineApi.Infrastructure.Configurations
{
    public class Settings 
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string ENGINE_COLLECTION_NAME { get; set; }

    }
}

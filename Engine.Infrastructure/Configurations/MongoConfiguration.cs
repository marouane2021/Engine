using System.Diagnostics.CodeAnalysis;

namespace Engine.Infrastructure.Configurations
{
    [ExcludeFromCodeCoverage]
    public class MongoConfiguration
    {/// <summary>
     /// Gets or sets the connection string.
     /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the database cleint.
        /// </summary>
        public string Database { get; set; }
    }
}

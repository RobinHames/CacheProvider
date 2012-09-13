using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CacheDiSample.Domain.CacheInterfaces
{
    public interface ISqlCacheDependency : ICacheDependency
    {
        ISqlCacheDependency Initialise(string databaseConnectionName, string tableName);
        ISqlCacheDependency Initialise(System.Data.SqlClient.SqlCommand sqlCommand);
    }
}

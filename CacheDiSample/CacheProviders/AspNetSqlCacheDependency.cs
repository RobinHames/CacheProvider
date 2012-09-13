using System.Web.Caching;
using CacheDiSample.Domain.CacheInterfaces;

namespace CacheDiSample.CacheProviders
{
    public class AspNetSqlCacheDependency : ISqlCacheDependency, IAspNetCacheDependency
    {
        private string databaseConnectionName;

        private string tableName;

        private System.Data.SqlClient.SqlCommand sqlCommand;

        #region ISqlCacheDependency Members

        public ISqlCacheDependency Initialise(string databaseConnectionName, string tableName)
        {
            this.databaseConnectionName = databaseConnectionName;
            this.tableName = tableName;
            return this;
        }

        public ISqlCacheDependency Initialise(System.Data.SqlClient.SqlCommand sqlCommand)
        {
            this.sqlCommand = sqlCommand;
            return this;
        }

        #endregion

        #region IAspNetCacheDependency Members

        public System.Web.Caching.CacheDependency CreateAspNetCacheDependency()
        {
            if (sqlCommand != null)
                return new SqlCacheDependency(sqlCommand);
            else
                return new SqlCacheDependency(databaseConnectionName, tableName);
        }

        #endregion

    }
}
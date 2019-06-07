using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PoolConnectionSample
{
    class ContextDAO
    {
        private SqlConnection obj_sqlConn = new SqlConnection();
        private SqlConnectionStringBuilder obj_sqnBuild = new SqlConnectionStringBuilder();

        public ContextDAO()
        {
            obj_sqnBuild.DataSource = "localhost";
            obj_sqnBuild.UserID = "elles";
            obj_sqnBuild.Password = "54321";
            obj_sqnBuild.InitialCatalog = "PlantAndHealth";
            obj_sqnBuild.MinPoolSize = 1;
            obj_sqnBuild.MaxPoolSize = 3;
            obj_sqnBuild.ConnectTimeout = 10;
            //obj_sqnBuild.LoadBalanceTimeout = 10;
            //obj_sqnBuild.Pooling = true;
            //obj_sqnBuild.IntegratedSecurity = true;
            obj_sqlConn.ConnectionString = obj_sqnBuild.ConnectionString;
        }

        public void openSqlConn(SqlConnection connection)
        {    
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            connection.Open();
        }

        public SqlConnection sConNme
        {
            get
            {
                return obj_sqlConn;
            }
            set
            {
                sConNme = obj_sqlConn;
            }
        }
    }
}

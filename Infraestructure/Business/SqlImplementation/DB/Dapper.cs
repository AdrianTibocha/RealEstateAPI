using Dapper;
using Infraestructure.Business.SqlImplementation.Helper.CustomException;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Infraestructure.Business.SqlImplementation.DB
{
    public abstract class Dapper
    {
        public readonly string connectionString;
        public Dapper(string connectionString)
        {
            if(string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("connectionString");

            this.connectionString = connectionString;
        }

        public virtual IDbConnection GetConnection()
        {
            IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public virtual List<T> GetList<T>(string query, DynamicParameters dynamicParameters)
        {
            try
            {
                using (IDbConnection connection = GetConnection())
                {
                    var result = connection.Query<T>(query, dynamicParameters).ToList();
                    return result;
                }
            }
            catch(SqlException exception)
            {
                throw new CustomSqlException("An Exception was throw while get list", exception);
            }

        }
        public virtual int ExecuteSingle(string query, DynamicParameters dynamicParameters)
        {
            try
            {
                using (IDbConnection connection = GetConnection())
                {
                    return connection.Execute(query, dynamicParameters);
                }
            }
            catch (SqlException exception)
            {
                throw new CustomSqlException("An Exception was throw while execute single row", exception);
            }
        }

    }
}

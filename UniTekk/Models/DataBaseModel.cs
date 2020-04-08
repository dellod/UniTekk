using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Web;
using UniTekk.Models.Products;

namespace UniTekk.Models
{
    public class DatabaseModel
    {

        #region Query Methods

        public SqlConnection GetSQLConnection(string connectionstring)
        {
            if (connectionstring == null)
                return null;
            return new SqlConnection(connectionstring);
        }

        public SqlConnection GetSQLConnection()
        {
            if (databaseCredentials.Get_PuBConnectionString() == null)
                return null;
            return new SqlConnection(databaseCredentials.Get_PuBConnectionString());
        }

        /// <summary>
        /// This method is responisble to to execute a query in your RDBMS and return for you an output value. 
        /// For instance, in some cases when you insert a new records you need to return the id of that record to do other actions
        /// </summary>
        /// <returns></returns>

        public int Execute_Non_Query_Store_Procedure(string procedureName, SqlParameter[] parameters, string returnValue)
        {
            if (GetSQLConnection() == null)
                return -2;

            int successfulQuery = -3;
            SqlCommand sqlCommand = new SqlCommand(procedureName, GetSQLConnection());
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlCommand.Parameters.AddRange(parameters);
                sqlCommand.Parameters["@" + returnValue].Direction = ParameterDirection.Output;
                sqlCommand.Connection.Open();

                //SqlParameter returnParameter = sqlCommand.Parameters.Add("@" + returnValue, SqlDbType.Int);
                //returnParameter.Direction = ParameterDirection.ReturnValue;

                successfulQuery = sqlCommand.ExecuteNonQuery();
                successfulQuery = (int)sqlCommand.Parameters["@" + returnValue].Value;

            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }

            if (sqlCommand.Connection != null && sqlCommand.Connection.State == ConnectionState.Open)
                sqlCommand.Connection.Close();

            return successfulQuery;
        }


        /// <summary>
        /// This method is responisble to to execute a query in your RDBMS and return for you if it was successult executed. Minay used for insert,update, and delete
        /// </summary>
        /// <returns></returns>
        public int Execute_Non_Query_Store_Procedure(string procedureName, SqlParameter[] parameters)
        {
            if (GetSQLConnection() == null)
                return -1;

            int successfulQuery = 1;
            SqlCommand sqlCommand = new SqlCommand(procedureName, GetSQLConnection());
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlCommand.Parameters.AddRange(parameters);
                sqlCommand.Connection.Open();
                successfulQuery = sqlCommand.ExecuteNonQuery();
                // successfulQuery =1

            }
            catch (Exception ex)
            {
                string s = ex.Message;
                successfulQuery = -2;
            }

            if (sqlCommand.Connection != null && sqlCommand.Connection.State == ConnectionState.Open)
                sqlCommand.Connection.Close();

            return successfulQuery;
        }


        /// <summary>
        /// This method is responisble to to execute to rertieve data from your RDBSM by executing a stored procedure. Mainly used when using one select statment
        /// </summary>
        /// <returns></returns>
        public DataTable Execute_Data_Query_Store_Procedure(string procedureName, SqlParameter[] parameters)
        {
            if (GetSQLConnection() == null)
                return null;

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(procedureName, GetSQLConnection());
            sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlAdapter.SelectCommand.Parameters.AddRange(parameters);
                sqlAdapter.SelectCommand.Connection.Open();
                sqlAdapter.Fill(dataTable);
            }
            catch (Exception er)
            {
                string ee = er.ToString();
                dataTable = null;
            }

            if (sqlAdapter.SelectCommand.Connection != null && sqlAdapter.SelectCommand.Connection.State == ConnectionState.Open)
                sqlAdapter.SelectCommand.Connection.Close();

            return dataTable;
        }

        /// <summary>
        /// This method is responisble to to execute to rertieve data from your RDBSM by executing a stored procedure. Mainly used when more than one table is being returned.
        /// </summary>
        /// <returns></returns>
        /// 

        public DataSet Execute_Data_Dataset_Store_Procedure(string procedureName, SqlParameter[] parameters)
        {
            if (GetSQLConnection() == null)
                return null;

            DataSet dataset = new DataSet();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(procedureName, GetSQLConnection());
            sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlAdapter.SelectCommand.Parameters.AddRange(parameters);
                sqlAdapter.SelectCommand.Connection.Open();
                sqlAdapter.Fill(dataset);
            }
            catch (Exception er)
            {
                string ee = er.ToString();
                dataset = null;
            }

            if (sqlAdapter.SelectCommand.Connection != null && sqlAdapter.SelectCommand.Connection.State == ConnectionState.Open)
                sqlAdapter.SelectCommand.Connection.Close();

            return dataset;
        }

        /// <summary>
        /// This method check if the connection string is valid or not
        /// </summary>
        /// <returns></returns>

        public bool CheckDatabaseConnectionString(string ConnectionString)
        {
            try
            {

                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }


        }
        #endregion

        #region Examples
        public int updateEmployee(int empId, string empName, DateTime embBDate, string empAddress)
        {


            SqlParameter[] Parameters = new SqlParameter[4]; // Specifc number of parametrs for this tored procedure. 
            Parameters[0] = new SqlParameter("@empName", empName);//Make sure parameters Name matches thenames given in your stored procedure
            Parameters[1] = new SqlParameter("@embBDate", embBDate);
            Parameters[2] = new SqlParameter("@empAddress", empAddress);
            Parameters[3] = new SqlParameter("@empId", empId);

            return Execute_Non_Query_Store_Procedure("SP_UpdateEmpInfo", Parameters);//Make sure procedure Name matches the Name given in your RDBMS
        }


        public int insertEmployee(string empName, DateTime embBDate, string empAddress)
        {
            SqlParameter[] Parameters = new SqlParameter[3];
            Parameters[0] = new SqlParameter("@empName", empName);
            Parameters[1] = new SqlParameter("@embBDate", embBDate);
            Parameters[2] = new SqlParameter("@empAddress", empAddress);

            Parameters[2] = new SqlParameter("@empId", SqlDbType.Int);
            Parameters[2].Direction = ParameterDirection.Output;


            return Execute_Non_Query_Store_Procedure("SP_InsertEmpInfo", Parameters, "empId");
        }



        public DataTable GetEmpsInfo()
        {
            SqlParameter[] Parameters = new SqlParameter[0];


            return Execute_Data_Query_Store_Procedure("SP_GetEmpsInfo", Parameters);


        }

        //Actual data starts here, this one is returning login info

       /**
        * Sends password and username to database, will verify if these credentials exist
        * Should get a 0,1 or 2 depending on how the credentials verify
        */
        public int returnLoginInfo(string username, string password, string verifier)
        {
            SqlParameter[] Parameters = new SqlParameter[3];
            Parameters[0] = new SqlParameter("@returnVal", 1234);
            Parameters[1] = new SqlParameter("@username", username);
            Parameters[2] = new SqlParameter("@password", password);

            int returnVal = Execute_Non_Query_Store_Procedure("getUserInformation", Parameters, verifier);
            return returnVal;
        }
        /**
         * Inserts either a brand new tuple into the database if the criteria table doesn't contain username
         * OR
         * Updates the tuple already in the database with new price and address
         * Returns a 1 if everything succeeds
         */
        public int insertCriteriaInfo(string username, string address, int price)
        {
            int verifier = 0;
            SqlParameter[] Parameters = new SqlParameter[4];
            Parameters[0] = new SqlParameter("@successValue", verifier);
            Parameters[1] = new SqlParameter("@clientUsername", username);
            Parameters[2] = new SqlParameter("@price", price);
            Parameters[3] = new SqlParameter("@address", address);
            int returnVal = Execute_Non_Query_Store_Procedure("sendCriteria", Parameters, "successValue");
            return returnVal;
        }
        /**
         * Inserts a brand new product into the database. This is made only by someone who is an Admin User
         * The admin will put in all necessary credentials and the type of the product he is inserting.
         * Depending on the type, it will be determined which of the attributes(a1-a5) are required and inserted.
         */
        public int insertProductInfo(Product pro, String type, String a1,String a2, String a3,String a4,String a5)
        {
            int returnVal = 0;
            if(type.Equals("Laptop") || type.Equals("Camera"))
            {
                SqlParameter[] Parameters = new SqlParameter[13];
                Parameters[0] = new SqlParameter("@returnVal", returnVal);
                Parameters[1] = new SqlParameter("@username", pro.username);
                Parameters[2] = new SqlParameter("@sellerName", pro.seller.Name);
                Parameters[3] = new SqlParameter("@link", pro.seller.Link);
                Parameters[4] = new SqlParameter("@availability", pro.availability);
                Parameters[5] = new SqlParameter("@price", pro.price);
                Parameters[6] = new SqlParameter("@productName", pro.Name);
                Parameters[7] = new SqlParameter("@type", type);
                Parameters[8] = new SqlParameter("@attr1", a1);
                Parameters[9] = new SqlParameter("@attr2", a2);
                Parameters[10] = new SqlParameter("@attr3", a3);
                Parameters[11] = new SqlParameter("@attr4", a4);
                Parameters[12] = new SqlParameter("@attr5", a5);
                returnVal = Execute_Non_Query_Store_Procedure("insertNewProduct", Parameters, "returnVal");
            }
            else if (type.Equals("Phone"))
            {
                SqlParameter[] Parameters = new SqlParameter[13];
                Parameters[0] = new SqlParameter("@returnVal", returnVal);
                Parameters[1] = new SqlParameter("@username", pro.username);
                Parameters[2] = new SqlParameter("@sellerName", pro.seller.Name);
                Parameters[3] = new SqlParameter("@link", pro.seller.Link);
                Parameters[4] = new SqlParameter("@availability", pro.availability);
                Parameters[5] = new SqlParameter("@price", pro.price);
                Parameters[6] = new SqlParameter("@productName", pro.Name);
                Parameters[7] = new SqlParameter("@type", type);
                Parameters[8] = new SqlParameter("@attr1", a1);
                Parameters[9] = new SqlParameter("@attr2", a2);
                Parameters[10] = new SqlParameter("@attr3", a3);
                Parameters[11] = new SqlParameter("@attr4", "");
                Parameters[12] = new SqlParameter("@attr5", "");
                returnVal = Execute_Non_Query_Store_Procedure("insertNewProduct", Parameters, "returnVal");
            }
            else if (type.Equals("TV"))
            {
                SqlParameter[] Parameters = new SqlParameter[13];
                Parameters[0] = new SqlParameter("@returnVal", returnVal);
                Parameters[1] = new SqlParameter("@username", pro.username);
                Parameters[2] = new SqlParameter("@sellerName", pro.seller.Name);
                Parameters[3] = new SqlParameter("@link", pro.seller.Link);
                Parameters[4] = new SqlParameter("@availability", pro.availability);
                Parameters[5] = new SqlParameter("@price", pro.price);
                Parameters[6] = new SqlParameter("@productName", pro.Name);
                Parameters[7] = new SqlParameter("@type", type);
                Parameters[8] = new SqlParameter("@attr1", a1);
                Parameters[9] = new SqlParameter("@attr2", a2);
                Parameters[10] = new SqlParameter("@attr3", a3);
                Parameters[11] = new SqlParameter("@attr4", a4);
                Parameters[12] = new SqlParameter("@attr5", "");
                returnVal = Execute_Non_Query_Store_Procedure("insertNewProduct", Parameters, "returnVal");
            }


            return returnVal;
        }
        /**
         * This method will delete a product from the database. It will get productID and use it to terminate all tuples with
         * inputted productID in both the
         * Product table and the sells table and associated child table (Laptop,Phone,Camera,TV)
         */
        public int deleteProduct(int productId)
        {
            int returnVal = 0;
            SqlParameter[] Parameters = new SqlParameter[2];
            Parameters[0] = new SqlParameter("@returnVal", returnVal);
            Parameters[1] = new SqlParameter("@productId",productId);
            returnVal = Execute_Non_Query_Store_Procedure("deleteProduct", Parameters, "returnVal");
            return returnVal;
        }


        public int registerClient(string username, string password, string address)
        {
            SqlParameter[] Parameters = new SqlParameter[4];
            Parameters[0] = new SqlParameter("@returnValue", 1234);
            Parameters[1] = new SqlParameter("@username", username);
            Parameters[2] = new SqlParameter("@password", password);
            Parameters[3] = new SqlParameter("@address", address);
            int returnVal = Execute_Non_Query_Store_Procedure("registerClient", Parameters, "returnValue");
            return returnVal;
        }

        public int insertSeller(string username, string sellerName, string link, string productName, int availability, int price)
        {
            SqlParameter[] Parameters = new SqlParameter[7];
            int returnValue = 0;
            Parameters[0] = new SqlParameter("@returnValue", returnValue);
            Parameters[1] = new SqlParameter("@username", username);
            Parameters[2] = new SqlParameter("@sellerName", sellerName);
            Parameters[3] = new SqlParameter("@link", link);
            Parameters[4] = new SqlParameter("@productName", productName);
            Parameters[5] = new SqlParameter("@availability", availability);
            Parameters[6] = new SqlParameter("@price", price);
            int returnVal = Execute_Non_Query_Store_Procedure("insertSeller", Parameters, "returnValue");
            return returnValue;
        }

        public int deleteSeller(int sellerId)
        {
            int returnValue = 0;
            SqlParameter[] Parameters = new SqlParameter[2];
            Parameters[0] = new SqlParameter("@returnValue", returnValue);
            Parameters[1] = new SqlParameter("@sellerId", sellerId);
            returnValue = Execute_Non_Query_Store_Procedure("deleteSeller", Parameters, "returnValue");
            return returnValue;
        }
        #endregion
    }
}

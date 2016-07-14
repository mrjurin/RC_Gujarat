using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    /// <summary>
    /// Developer Piyush Diwan
    /// user related database functionality
    /// </summary>
    public class User
    {
        DMLSql dmlsql = null;

        public User()
        {
            dmlsql = new DMLSql();
        }

        public object CheckUserCredential(string userName, string password)
        {
            try
            {

                string ReturnValue = string.Empty;

                if (Common.ValidateStringValue(userName) && Common.ValidateStringValue(password))
                {
                    //Procedure to check user credentials
                    string procedure = "CHECK_USER_CREDENTIALS";
                    SqlParameter[] sqlParameter = {
                    new SqlParameter("USERNAME",userName),
                    new SqlParameter("PASSWORD",password)
                };

                    ReturnValue = dmlsql.GetSingleRecord(procedure, sqlParameter, CommandType.StoredProcedure);
                }
                return ReturnValue;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable GetUserDetails()
        {
            try
            {

                //Procedure to get user info
                string procedure = "GET_USER_DETAILS";
                SqlParameter[] sqlParameter = null;

                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Boolean InsertUserDetails(string name, string userName, string password, int userType, string dateValidFrom, string dateValidTill)
        {
            try
            {

                //Procedure to insert user info
                string procedure = "INSERT_USER_DETAILS";
                SqlParameter[] sqlParameter = {
                    new SqlParameter("NAME",name),
                    new SqlParameter("USERNAME",userName),
                    new SqlParameter("PASSWORD",password),
                    new SqlParameter("USERTYPE",userType),
                    new SqlParameter("DATE_VALID_FROM",Convert.ToDateTime(dateValidFrom).ToString("dd-MMM-yyyy")),
                    new SqlParameter("DATE_VALID_TILL",Convert.ToDateTime(dateValidTill).ToString("dd-MMM-yyyy"))
                };

                dmlsql.ExecuteNonquery(procedure, sqlParameter, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool CheckIfUserNameExists(string userName)
        {
            try
            {

                bool result = false;
                //Procedure to insert user info
                string procedure = "CHECK_IF_USERNAME_EXISTS";
                SqlParameter[] sqlParameter = {
                    new SqlParameter("USERNAME",userName)
                };

                if (Common.ValidateStringValue(dmlsql.GetSingleRecord(procedure, sqlParameter, CommandType.StoredProcedure)))
                    result = true;

                return result;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Boolean InsertLoginDetails(string userName, string computerName, int loginStatus)
        {
            try
            {

                //Procedure to insert user login details
                string procedure = "INSERT_LOGIN_DETAILS";

                SqlParameter[] sqlParameter = {
                new SqlParameter("USERNAME",userName),
                //new SqlParameter("LOGIN_DATETIME",loginDateTime.ToString("dd-MMM-yyyy hh:mm:ss")),
                new SqlParameter("COMPUTER_NAME", computerName),
                new SqlParameter("LOGIN_STATUS", loginStatus)
            };

                dmlsql.ExecuteNonquery(procedure, sqlParameter, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Boolean InsertLogoutDetails(string userName, string computerName, int loginStatus, int logoutStatus)
        {
            try
            {

                //Procedure to insert user logout details
                string procedure = "INSERT_LOGOUT_DETAILS";

                SqlParameter[] sqlParameter = {
                new SqlParameter("USERNAME",userName),
                //new SqlParameter("LOGOUT_DATETIME",logoutDateTime.ToString("dd-MMM-yyyy hh:mm:ss")),
                new SqlParameter("COMPUTER_NAME", computerName),
                new SqlParameter("LOGIN_STATUS", loginStatus),
                new SqlParameter("LOGOUT_STATUS", logoutStatus)
            };

                dmlsql.ExecuteNonquery(procedure, sqlParameter, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}

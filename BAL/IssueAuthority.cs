using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BAL
{
    public class IssueAuthority
    {
        DMLSql dmlsql = null;

        public IssueAuthority()
        {
            dmlsql = new DMLSql();
        }

        public DataTable GetSignatureAddedIssueAuthorityCodes()
        {
            try
            {

                //Procedure to get Signature added Issue Authority codes
                string procedure = "GET_SIGNATURE_ADDED_ISSUE_AUTHORITY_CODES";
                SqlParameter[] sqlParameter = null;

                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable GetIssueAuthorityCodesForAddingSignature()
        {
            try
            {

                //Procedure to get Issue Authority codes for adding Signature
                string procedure = "GET_ISSUE_AUTHORITY_CODES_FOR_ADDING_SIGNATURE";
                SqlParameter[] sqlParameter = null;

                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable GetIssueAuthorityCodesToBeAdded()
        {
            try
            {

                //Procedure to get Issue Authority codes to be added
                string procedure = "GET_ISSUE_AUTHORITY_CODES_TO_BE_ADDED";
                SqlParameter[] sqlParameter = null;

                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Boolean InsertIssueAuthoritySignatureWithCodeAndName(string issueAuthorityeCode, byte[] issueAuthoritySignature, string issueAuthorityName)
        {
            try
            {

                //Procedure to insert Issue Authority Signature with code and name
                string procedure = "INSERT_ISSUE_AUTHORITY_SIGNATURE_WITH_CODE_AND_NAME";
                SqlParameter[] sqlParameter = {
                    new SqlParameter("ISSUE_AUTH_CODE",issueAuthorityeCode),
                    new SqlParameter("ISSUE_AUTH_SIGNATURE",issueAuthoritySignature),
                    new SqlParameter("ISSUE_AUTH_NAME",issueAuthorityName),
                };

                dmlsql.ExecuteNonquery(procedure, sqlParameter, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public int DeleteAddedIssueAuthoritySignatureAndName(string issueAuthorityeCode, string issueAuthorityName)
        {
            try
            {

                //Procedure to delete Issue Authority Signature and name
                string procedure = "DELETE_ADDED_ISSUE_AUTHORITY_SIGNATURE_AND_NAME";
                SqlParameter[] sqlParameter = {
                    new SqlParameter("ISSUE_AUTH_CODE",issueAuthorityeCode),
                    new SqlParameter("ISSUE_AUTH_NAME",issueAuthorityName),
                };

                return dmlsql.ExecuteNonquery(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}

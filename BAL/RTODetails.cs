using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BAL
{
    public class RTODetails
    {
        DMLSql dmlsql = null;
        public RTODetails()
        {
            dmlsql = new DMLSql();
        }
        public DataTable GetRTOData()
        {
            try
            {
                //Procedure to get RTO details
                string query = "GET_RTO_DETAILS";
                SqlParameter[] sqlParameter = null;
                return dmlsql.GetRecords(query, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

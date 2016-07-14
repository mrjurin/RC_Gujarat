using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BAL
{
    public class DataBulkPrint
    {
        DMLSql dmlsql = null;
        public DataBulkPrint()
        {
            dmlsql = new DMLSql();
        }

        public DataTable GetBatchesForBulkPrinting()
        {
            try
            {
                //Procedure to get batches for bulk printing
                string procedure = "GET_BATCHES_FOR_BULK_PRINTING";
                SqlParameter[] sqlParameter = null;

                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetVehicleRegistrationNoForBulkPrinting(string batchNo)
        {
            try
            {
                //Procedure to get vehicle regisrtation no for bulk printing
                string procedure = "GET_VEHICLE_REGISTRATION_NO_FOR_BULK_PRINTING";
                SqlParameter[] sqlParameter = {
                new SqlParameter("BATCHNO",batchNo)
                };

                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

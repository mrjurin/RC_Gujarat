using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BAL
{
    public class RejectCardDetails
    {
        
        DMLSql dmlsql = null;

        public RejectCardDetails()
        {
            dmlsql = new DMLSql();
        }

        public bool InsertRejectCardDetails(string vehRegNo, string reason, string userName, string chipSerialNo,
            string cardSerialNo, string batchNo, string challanNo, string printDateTime, string importDateTime)
        {
            try
            {
                if (printDateTime != null)
                    printDateTime = Convert.ToDateTime(printDateTime).ToString("dd-MMM-yyyy hh:mm:ss");
                if (importDateTime != null)
                    importDateTime = Convert.ToDateTime(importDateTime).ToString("dd-MMM-yyyy hh:mm:ss");

                string Query = "InsertRejectCardDetails";
                SqlParameter[] sqlParameter = {
                new SqlParameter("@VEHREGNO",vehRegNo),
                new SqlParameter("@REASON",reason),
                new SqlParameter("@REJECT_USERNAME",userName),
                new SqlParameter("@CHIP_SERIAL_NO",chipSerialNo),
                new SqlParameter("@CARD_SERIAL_NO",cardSerialNo),
                new SqlParameter("@BATCH_NO",batchNo),
                new SqlParameter("@CHALLAN_NO",challanNo),
                new SqlParameter("@PRINT_DATETIME",printDateTime),
                new SqlParameter("@IMPORT_DATETIME",importDateTime)
                };

                if (dmlsql.ExecuteNonquery(Query, sqlParameter, CommandType.StoredProcedure) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string CheckVehicleNo(string vehicleNO)
        {

            try
            {
                string Query = "Check_vehicleNo";
                SqlParameter[] sqlParameter = {
                new SqlParameter("@vehicleNO",vehicleNO),
              
                };

                return dmlsql.GetSingleRecord(Query, sqlParameter, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

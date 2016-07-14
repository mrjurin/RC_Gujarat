using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BAL
{
    public class DataSinglePrint
    {
        DMLSql dmlsql = null;

        public DataSinglePrint()
        {
            dmlsql = new DMLSql();
        }

        public DataTable GetDataForPersonalization()
        {
            try
            {

                //Procedure to get data for personalization
                string procedure = "GET_DATA_FOR_PERSONALIZATION";
                SqlParameter[] sqlParameter = null;

                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable GetDataForPersonalizationSearchingRCNumber(string searchingDLNo)
        {
            try
            {

                if (searchingDLNo.Length == 0)
                {
                    searchingDLNo = "_";
                }

                //Procedure to get data for personalization by searching RC No
                string procedure = "GET_DATA_FOR_PERSONALIZATION_BY_RCNO";
                SqlParameter[] sqlParameter = {
                new SqlParameter("VEHREGNO",searchingDLNo)
                };

                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable GetRCRecordsForPrinting(string vehicleRegNo, string autoID)
        {
            try
            {

                if (!Common.ValidateStringValue(vehicleRegNo) || !Common.ValidateStringValue(autoID))
                {
                    return null;
                }
                else
                {
                    //Procedure to get RC Records for Printing
                    string procedure = "GET_RC_RECORDS_FOR_PRINTING";
                    SqlParameter[] sqlParameter = {
                    new SqlParameter("VEHREGNO",vehicleRegNo),
                    new SqlParameter("AUTOID",Convert.ToInt64(autoID))
                };

                    return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Boolean InsertDetailsForPrintedRCRecords(string autoID, string vehRegNo, string printFlag, string userName, int printCount,string chipSerailNo)
        {
            try
            {

                //Procedure to insert details for printed RC Records
                string procedure = "INSERT_DETAILS_FOR_PRINTED_RC_RECORDS";
                SqlParameter[] sqlParameter = {
                    new SqlParameter("AUTOID",Convert.ToInt64(autoID)),
                    new SqlParameter("VEHREGNO",vehRegNo),
                    new SqlParameter("PRINT_FLAG",printFlag),
                    //new SqlParameter("PRINT_DATETIME",dateTime.ToString("dd-MMM-yyyy hh:mm:ss")),
                    new SqlParameter("PRINT_USERNAME",userName),
                    new SqlParameter("PRINT_COUNT",printCount),
                    new SqlParameter("Chip_SerailNo",chipSerailNo),

                };

                dmlsql.ExecuteNonquery(procedure, sqlParameter, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public string GetVehicleTypeOfRCRecordForReport(string vehicleRegNo,string autoID)
        {
            try
            {

                //Procedure to get vehicle type of RC Record for report
                string procedure = "GET_VEHICLE_TYPE_OF_RC_RECORD_FOR_REPORT";
                SqlParameter[] sqlParameter = {
                    new SqlParameter("VEHREGNO",vehicleRegNo),
                    new SqlParameter("AUTOID",Convert.ToInt64(autoID))
                };

                string ReturnValue = Convert.ToString(dmlsql.GetSingleRecord(procedure, sqlParameter, CommandType.StoredProcedure));
                if (!Common.ValidateStringValue(ReturnValue))
                {
                    return null;
                }
                else
                    return ReturnValue;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

    }
}

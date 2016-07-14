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
    /// <summary>
    /// Developer Piyush Diwan
    /// user related database functionality
    /// </summary>
    public class Validate
    {
        DMLSql dmlsql = null;
     
        public Validate()
        {
            dmlsql = new DMLSql();
        }

        //public DataTable GetDataForValidation()
        //{
        //    try
        //    {

        //        //Procedure to get data for validation
        //        string procedure = "GET_DATA_FOR_VALIDATION";
        //        SqlParameter[] sqlParameter = null;

        //        return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public DataTable GetDataForValidation(string datewise, string vehClass, string vehType, string transacType)
        {
            try
            {

                //Procedure to get data for validation
                string procedure = "GET_DATA_FOR_VALIDATION";
                SqlParameter[] sqlParameter = {
                new SqlParameter("@datewise",datewise),
                new SqlParameter("@vehclass",vehClass),
                new SqlParameter("@vehtype",vehType),
                new SqlParameter("@transactype",transacType)
                };

                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable GetDataForValidationSearchingRCNumber(string searchingDLNo, string datewise, string vehClass, string vehType, string transacType)
        {
            try
            {

                if (searchingDLNo.Length == 0)
                {
                    searchingDLNo = "_";
                }
                //Procedure to get data for validation by searching RC No
                string procedure = "GET_DATA_FOR_VALIDATION_BY_RCNO";
                SqlParameter[] sqlParameter = {
                new SqlParameter("@VEHREGNO",searchingDLNo),
                new SqlParameter("@datewise",datewise),
                new SqlParameter("@vehclass",vehClass),
                new SqlParameter("@vehtype",vehType),
                new SqlParameter("@transactype",transacType)
                };

                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable GetDataForValidationByVehicleType(char vehicleType)
        {
            try
            {
                //Procedure to get data for validation by vehicle type
                string procedure = "GET_DATA_FOR_VALIDATION_BY_VEHICLE_TYPE";
                SqlParameter[] sqlParameter = {
                new SqlParameter("VEHICLE_TYPE",vehicleType)
                };

                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public string GetBatchNo()
        {
            try
            {
                //Procedure to get batch numbers
                string procedure = "GET_BATCH_NO";
                SqlParameter[] sqlParameter = null;
                string ReturnValue = Convert.ToString(dmlsql.GetSingleRecord(procedure, sqlParameter, CommandType.StoredProcedure));
                if (!Common.ValidateStringValue(ReturnValue))
                {
                    return "1";
                }
                else
                    return ReturnValue;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public int ValidateRCRecords(string autoid)
        {
            try
            {
                int TempValue = 0;
                //Procedure to validated RC records
                string procedure = "VALIDATE_RC_RECORDS";
                SqlParameter[] sqlParameter = {
                new SqlParameter("AUTOID",Convert.ToInt64(autoid))
                };
                if (dmlsql.GetSingleRecord(procedure, sqlParameter, CommandType.StoredProcedure) != "")
                {
                    TempValue = 1;
                }
                return TempValue;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Boolean InsertValidatedRCRecordsDetails(string batchNo, string autoID, string userName, string status)
        {
            try
            {

                //Procedure to insert validated RC records details
                string procedure = "INSERT_VALIDATED_RC_RECORDS_DETAILS";
                SqlParameter[] sqlParameter = {
                    new SqlParameter("BATCHNO",batchNo),
                    new SqlParameter("AUTOID",Convert.ToInt64(autoID)),
                    //new SqlParameter("VAL_DATETIME",dateTime.ToString("dd-MMM-yyyy hh:mm:ss")),
                    new SqlParameter("VAL_USERNAME",userName),
                    new SqlParameter("STATUS",status)
                    //new SqlParameter("VEHICLE_TYPE",GetVehicleTypeForRCRecords(GetVehicleTypeOfRCRecord(vehRegNo)))
                };

                dmlsql.ExecuteNonquery(procedure, sqlParameter, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Boolean InsertBatchRecords(string batchNo, int records)
        {
            try
            {

                // Procedure to insert batch records successfully validating records.
                string procedure = "INSERT_BATCH_DETAILS";
                SqlParameter[] sqlParameter = {
                    new SqlParameter("BATCH_NO",batchNo),
                    //new SqlParameter("BATCH_DATETIME",batchDate.ToString("dd-MMM-yyyy hh:mm:ss")),
                    new SqlParameter("RECORDS",records)
                };

                dmlsql.ExecuteNonquery(procedure, sqlParameter, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        //public string GetVehicleTypeForRCRecords(string VEHCLASS)
        //{
        //    try
        //    {

        //        string ReturnValue = null;
        //        //Procedure to get vehicle type for RC records
        //        string procedure = "GET_VEHICLE_TYPE_FOR_RC_RECORDS";
        //        SqlParameter[] sqlParameter = {
        //        new SqlParameter("VEHCLASS",VEHCLASS)
        //        };
        //        ReturnValue = Convert.ToString(dmlsql.GetSingleRecord(procedure, sqlParameter, CommandType.StoredProcedure));
        //        return ReturnValue;
        //    }
        //    catch (Exception ex)
        //    {
                
        //        throw ex;
        //    }
        //}

        //public string GetVehicleTypeOfRCRecord(string vehRegNo)
        //{
        //    try
        //    {

        //        string ReturnValue = null;
        //        //Procedure to get vehicle type of RC record
        //        string procedure = "GET_VEHICLE_TYPE_OF_RC_RECORD";
        //        SqlParameter[] sqlParameter = {
        //        new SqlParameter("VEHREGNO",vehRegNo)
        //        };
        //        ReturnValue = Convert.ToString(dmlsql.GetSingleRecord(procedure, sqlParameter, CommandType.StoredProcedure));
        //        return ReturnValue;
        //    }
        //    catch (Exception ex)
        //    {
                
        //        throw ex;
        //    }
        //}

        public Boolean InsertVehicleTypeInRCRecordsBeforeValidation()
        //public Boolean InsertVehicleTypeInRCRecordsBeforeValidation(string vehRegNo, string regDate)
        {
            try
            {

                //Procedure to insert validated RC records details
                string procedure = "INSERT_VEHICLE_TYPE_IN_RC_RECORDS_BEFORE_VALIDATION";
                SqlParameter[] sqlParameter = null;
                
                //SqlParameter[] sqlParameter = {
                //    new SqlParameter("VEHREGNO",vehRegNo),
                //    new SqlParameter("REGDATE",regDate),
                //    new SqlParameter("VEHICLE_TYPE",GetVehicleTypeForRCRecords(GetVehicleTypeOfRCRecord(vehRegNo)))
                //};

                dmlsql.ExecuteNonquery(procedure, sqlParameter, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable GetVehicleClassBeforeValidation()
        {
            try
            {
                //Procedure to Get Vehicle Class Before Validation
                string procedure = "GET_VEHICLE_CLASS_BEFORE_VALIDATION";
                SqlParameter[] sqlParameter = null;

                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable GetTransactionTypeBeforeValidation()
        {
            try
            {
                //Procedure to Get Transaction Type Before Validation
                string procedure = "GET_TRANSACTION_TYPE_BEFORE_VALIDATION";
                SqlParameter[] sqlParameter = null;

                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}


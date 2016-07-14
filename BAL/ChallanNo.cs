using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BAL
{
    public class ChallanNo
    {
        DMLSql dMLSql = null;

        public ChallanNo()
        {
            dMLSql = new DMLSql();
        }

        public string GetChallanNo()
        {
            try
            {
                //Procedure to get challan numbers
                string procedure = "GetChallanNo";
                SqlParameter[] sqlParameter = null;
                string ReturnValue = Convert.ToString(dMLSql.GetSingleRecord(procedure, sqlParameter, CommandType.StoredProcedure));
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

        public DataTable GetRecordsForChallan(string datewise, string vehClass, string vehRegNo, string printDate)
        {
            try
            {
                string Query = "GetRecordsForChallan";
                SqlParameter[] sqlParameter = {
                new SqlParameter("@datewise",datewise),
                new SqlParameter("@vehclass",vehClass),
                new SqlParameter("@vehregno",vehRegNo),
                new SqlParameter("@PRINT_DATETIME",printDate)
                };

                return dMLSql.GetRecords(Query, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CreateChallan(string AutoID, string VehicleNo,string ChallanNo,string userName)
        {
            try
            {
                string Query = "CreateChallanNo";
                SqlParameter[] sqlParameter = {
                new SqlParameter("@AUTOID",Convert.ToInt64(AutoID)),
                new SqlParameter("@VehicleNo",VehicleNo),
                new SqlParameter("@challanNo",ChallanNo),
                new SqlParameter("@UserName",userName)
                };

                return dMLSql.ExecuteNonquery(Query, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BindChallanNO()
        {
            try
            {
                string Query = "BindChallanNo";
                SqlParameter[] sqlParameter = {
                };

                return dMLSql.GetRecords(Query, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

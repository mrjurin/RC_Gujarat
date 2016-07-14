using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using System.Data.SqlClient;

namespace BAL
{
   public class GetRecordsRC_Cash
    {
        DMLSql objDMLSql = null;
        public GetRecordsRC_Cash()
        {
            objDMLSql = new DMLSql();
        }

       public DataTable GetRecords(string vehicleRegNo, string autoID)
       {
           try
           {
               string Query = "GetRC_Records";
               SqlParameter[] sqlParameter = {
                new SqlParameter("@VehicleNo",vehicleRegNo),
                new SqlParameter("@AUTOID",Convert.ToInt64(autoID))
                };
               return objDMLSql.GetRecords(Query, sqlParameter, CommandType.StoredProcedure);

           }
           catch (Exception ex)
           {
               
               throw ex;
           }
      
       }

       public int Get_bind(string vehicleRegNO)
       {
           try
           {
               string Query = "UpdateChip";
               SqlParameter[] sqlParameter = {
                new SqlParameter("@VehicleNo",vehicleRegNO)
                };

               return objDMLSql.ExecuteNonquery(Query, sqlParameter, CommandType.StoredProcedure);
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
       }

    }
}

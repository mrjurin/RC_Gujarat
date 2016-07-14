using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BAL
{
    public class RCVehicle
    {
        DMLSql dmlsql = null;

        public RCVehicle()
        {
            dmlsql = new DMLSql();
        }

        public DataTable GetImageAddedRCVehicleCodes()
        {
            try
            {

                //Procedure to get Image added RC vehicle codes
                string procedure = "GET_IMAGE_ADDED_RC_VEHICLE_CODES";
                SqlParameter[] sqlParameter = null;

                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable GetRCVehicleCodesForAddingImage()
        {
            try
            {

                //Procedure to get RC vehicle codes for adding Image
                string procedure = "GET_RC_VEHICLE_CODES_FOR_ADDING_IMAGE";
                SqlParameter[] sqlParameter = null;

                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable GetRCVehicleCodesToBeAdded()
        {
            try
            {

                //Procedure to get RC vehicle codes to be added
                string procedure = "GET_RC_VEHICLE_CODES_TO_BE_ADDED";
                SqlParameter[] sqlParameter = null;

                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Boolean InsertRCVehicleImageWithCode(string vehicleCode, byte[] vehicleImage)
        {
            try
            {

                //Procedure to insert RC vehicle Images with vehicle code
                string procedure = "INSERT_RC_VEHICLE_IMAGE_WITH_CODE";
                SqlParameter[] sqlParameter = {
                    new SqlParameter("VEH_CLASS_CD",vehicleCode),
                    new SqlParameter("VEH_CLASS_IMG",vehicleImage),
                };

                dmlsql.ExecuteNonquery(procedure, sqlParameter, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public int DeleteRCVehicleImage(string vehicleCode)
        {
            try
            {

                //Procedure to delete Vehicle Image and Code
                string procedure = "DELETE_ADDED_RC_VEHICLE_IMAGE";
                SqlParameter[] sqlParameter = {
                    new SqlParameter("VEH_CLASS_CD",vehicleCode),
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

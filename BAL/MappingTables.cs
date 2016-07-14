using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BAL
{
    public class MappingTables
    {
        DMLSql dmlsql = null;

        public MappingTables()
        {
            dmlsql = new DMLSql();
        }

        public DataTable GetRCMakerCodesAndDescriptionToBeAddedInMappingTable()
        {
            try
            {
                //Procedure to get RC maker codes and description to be added in mapping table(MAPPING_MAKER)
                string procedure = "GET_RC_MAKER_CODES_AND_DESCRIPTION_TO_BE_ADDED_IN_MAPPING_TABLE";
                SqlParameter[] sqlParameter = null;
                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable GetRCFuelCodesAndDescriptionToBeAddedInMappingTable()
        {
            try
            {
                //Procedure to get RC fuel codes and description to be added in mapping table(MAPPING_FUEL)
                string procedure = "GET_RC_FUEL_CODES_AND_DESCRIPTION_TO_BE_ADDED_IN_MAPPING_TABLE";
                SqlParameter[] sqlParameter = null;
                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable GetRCBodytypeCodesAndDescriptionToBeAddedInMappingTable()
        {
            try
            {
                //Procedure to get RC bodytype codes and description to be added in mapping table(MAPPING_BODYTYPE)
                string procedure = "GET_RC_BODYTYPE_CODES_AND_DESCRIPTION_TO_BE_ADDED_IN_MAPPING_TABLE";
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

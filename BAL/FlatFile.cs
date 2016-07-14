using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class FlatFile
    {
        DMLSql dmlsql = null;

        public FlatFile()
        {
            dmlsql = new DMLSql();
        }

        public Boolean InsertRCRecords(string VEHREGNO,string REGDATE,string OWNERNAME,string FNAME,string CADDRESS,string MANUFACTURER,string MODELNO,string COLOUR,string FUEL,string VEHCLASS,
                            string BODYTYPE,string SEATCAP,string STANDCAP,string MANUFDATE,string UNLADENWT,string CUBICCAP,string WHEELBASE,string NOOFCYLIN,string OWNERSERIAL,string CHASISNO,
                            string ENGINENO,string TAXPAIDUPTO,string REGNVALIDITY,string APPROVINGAUTH,string FINNAME,string FINADDRESS,string HYPOFROM,string HYPOTO,string NOCNO,string STATETO,
                            string RTOTO,string NCRBCLEARNO,string NOCISSUEDT,string INSCOMPNAME,string COVERPOLICYNO,string INSTYPE,string INSVALIDUPTO,string PUCCENTERCODE,string PUCVALIDUPTO,
                            string TAXAMOUNT,string FINE,string EXEMPTRECPTNO,string PAYMENTDT,string TAXVALIDFROM,string TAXVALIDTO,string EXEMPTION,string DRTOCODE,string BUFLAG,string FITVALIDUPTO,
                            string FITINSOFFICER,string FITLOCATION,string GROSSVEHWT,string SEMITRAILERS,string TYREINFO,string AXLEINFO,string TRN_TY,string userName)
        {
            try
            {


                //Procedure to insert RC Records
                string query = "INSERT_RC_RECORDS";
                SqlParameter[] sqlParameter = {
                new SqlParameter("VEHREGNO",VEHREGNO),
                new SqlParameter("REGDATE",REGDATE),
                new SqlParameter("OWNERNAME",OWNERNAME),
                new SqlParameter("FNAME",FNAME),
                new SqlParameter("CADDRESS",CADDRESS),
                new SqlParameter("MANUFACTURER",MANUFACTURER),
                new SqlParameter("MODELNO",MODELNO),
                new SqlParameter("COLOUR",COLOUR),
                new SqlParameter("FUEL",FUEL),
                new SqlParameter("VEHCLASS",VEHCLASS),
                new SqlParameter("BODYTYPE",BODYTYPE),
                new SqlParameter("SEATCAP",SEATCAP),
                new SqlParameter("STANDCAP",STANDCAP),
                new SqlParameter("MANUFDATE",MANUFDATE),
                new SqlParameter("UNLADENWT",UNLADENWT),
                new SqlParameter("CUBICCAP",CUBICCAP),
                new SqlParameter("WHEELBASE",WHEELBASE),
                new SqlParameter("NOOFCYLIN",NOOFCYLIN),
                new SqlParameter("OWNERSERIAL",OWNERSERIAL),
                new SqlParameter("CHASISNO",CHASISNO),
                new SqlParameter("ENGINENO",ENGINENO),
                new SqlParameter("TAXPAIDUPTO",TAXPAIDUPTO),
                new SqlParameter("REGNVALIDITY",REGNVALIDITY),
                new SqlParameter("APPROVINGAUTH",APPROVINGAUTH),
                new SqlParameter("FINNAME",FINNAME),
                new SqlParameter("FINADDRESS",FINADDRESS),
                new SqlParameter("HYPOFROM",HYPOFROM),
                new SqlParameter("HYPOTO",HYPOTO),
                new SqlParameter("NOCNO",NOCNO),
                new SqlParameter("STATETO",STATETO),
                new SqlParameter("RTOTO",RTOTO),
                new SqlParameter("NCRBCLEARNO",NCRBCLEARNO),
                new SqlParameter("NOCISSUEDT",NOCISSUEDT),
                new SqlParameter("INSCOMPNAME",INSCOMPNAME),
                new SqlParameter("COVERPOLICYNO",COVERPOLICYNO),
                new SqlParameter("INSTYPE",INSTYPE),
                new SqlParameter("INSVALIDUPTO",INSVALIDUPTO),
                new SqlParameter("PUCCENTERCODE",PUCCENTERCODE),
                new SqlParameter("PUCVALIDUPTO",PUCVALIDUPTO),
                new SqlParameter("TAXAMOUNT",TAXAMOUNT),
                new SqlParameter("FINE",FINE),
                new SqlParameter("EXEMPTRECPTNO",EXEMPTRECPTNO),
                new SqlParameter("PAYMENTDT",PAYMENTDT),
                new SqlParameter("TAXVALIDFROM",TAXVALIDFROM),
                new SqlParameter("TAXVALIDTO",TAXVALIDTO),
                new SqlParameter("EXEMPTION",EXEMPTION),
                new SqlParameter("DRTOCODE",DRTOCODE),
                new SqlParameter("BUFLAG",BUFLAG),
                new SqlParameter("FITVALIDUPTO",FITVALIDUPTO),
                new SqlParameter("FITINSOFFICER",FITINSOFFICER),
                new SqlParameter("FITLOCATION",FITLOCATION),
                new SqlParameter("GROSSVEHWT",GROSSVEHWT),
                new SqlParameter("SEMITRAILERS",SEMITRAILERS),
                new SqlParameter("TYREINFO",TYREINFO),
                new SqlParameter("AXLEINFO",AXLEINFO),
                new SqlParameter("TRN_TY",TRN_TY),
                //new SqlParameter("IMPORT_DATETIME",dateTime.ToString("dd-MMM-yyyy hh:mm:ss")),
                new SqlParameter("IMPORT_USERNAME",userName)
                };

                dmlsql.ExecuteNonquery(query, sqlParameter, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable CheckIfFlatFileExist(string flatFileName)
        {
            try
            {
                string temp = string.Empty;
                if (flatFileName.ToLower().EndsWith(".txt"))
                {
                    int tempLength = flatFileName.Length - 4;
                    temp = flatFileName.Substring(0, tempLength);
                }
                if (flatFileName.ToLower().EndsWith(".dat"))
                {
                    int tempLength = flatFileName.Length - 4;
                    temp = flatFileName.Substring(0, tempLength);
                }

                //Procedure to check whether flat file exists or not
                string procedure = "CHECK_IF_FLATFILE_EXISTS";
                SqlParameter[] sqlParameter = {
                new SqlParameter("FLATFILE_NAME",temp)
                };
                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Boolean InsertFlatFileDetails(string flatFileName, string vehRegNo, string userName, string remark)
        {
            try
            {

                //Procedure to insert flat file info
                string procedure = "INSERT_FLATFILE_DETAILS";
                SqlParameter[] sqlParameter = {
                    new SqlParameter("FLATFILE_NAME",flatFileName),
                    new SqlParameter("VEHREGNO",vehRegNo),
                    new SqlParameter("IMPORT_USERNAME",userName),
                    //new SqlParameter("IMPORT_DATETIME",dateTime.ToString("dd-MMM-yyyy hh:mm:ss")),
                    new SqlParameter("REMARK",remark)
                };

                dmlsql.ExecuteNonquery(procedure, sqlParameter, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable GetImportedFlatFileRecords(string flatFileName)
        {
            try
            {
                string temp=string.Empty;
                if (flatFileName.ToLower().EndsWith(".txt"))
                {
                    int tempLength = flatFileName.Length - 4;
                    temp = flatFileName.Substring(0, tempLength);
                } 
                if (flatFileName.ToLower().EndsWith(".dat"))
                {
                    int tempLength = flatFileName.Length - 4;
                    temp = flatFileName.Substring(0, tempLength);
                }

                //Procedure to get imported flat file record(s)
                string procedure = "GET_IMPORTED_FLATFILE_RECORDS";
                SqlParameter[] sqlParameter = {
                new SqlParameter("FLATFILE_NAME",temp)
                };
                return dmlsql.GetRecords(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public string CheckWhetherVehicleRecordExist(string vehRegNo, string ownerSerial, string transacType)
        {
            try
            {
                //Procedure to check whether vehicle record exist
                string procedure = "CHECK_WHETHER_VEHICLE_RECORD_EXIST";
                SqlParameter[] sqlParameter = {
                new SqlParameter("VEHREGNO",vehRegNo),
                new SqlParameter("OWNERSERIAL",ownerSerial),
                new SqlParameter("TRN_TY",transacType)
                };
                return dmlsql.GetSingleRecord(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string CheckWhetherErrorVehicleRecordExist(string vehRegNo)
        {
            try
            {
                //Procedure to check whether error vehicle record exist
                string procedure = "CHECK_WHETHER_ERROR_VEHICLE_RECORD_EXIST";
                SqlParameter[] sqlParameter = {
                new SqlParameter("VEHREGNO",vehRegNo)
                };
                return dmlsql.GetSingleRecord(procedure, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

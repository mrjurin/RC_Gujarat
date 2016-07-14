using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using persoRCDU;
using BAL;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
//using SmartCardManager;
//using Fargo.PrinterSDK;
using System.Diagnostics;
using ClientRuntime;

namespace RCProject
{
    class PersoCardAssignData
    {
        VEHICLE_PERSONAL_REGESTARTION_DATA obj = new VEHICLE_PERSONAL_REGESTARTION_DATA();
        GetRecordsRC_Cash objGetRc_Cash = new GetRecordsRC_Cash();
        uint SChandle;
        uint scproto;
       // private SmartCardManager.SmartCardManager m_smartCardManager;


        public void PersoCard(DataTable objHoldVehicleRecords, string readerName, int hcontext, string printerName, ref string returnMessage, bool IsSingleCardWrite,ref string chipSerialNo )
        {
            if (objHoldVehicleRecords.Rows.Count > 0)
            {
                if (readerName != "")
                {
                    #region Passing Parameters for perso Card
                    obj.FATHER_NAME = objHoldVehicleRecords.Rows[0]["FNAME"].ToString();
                    /// Right. 35 byte
                    obj.ISSUING_AUTH_ID = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["APPROVINGAUTH"].ToString()); // this id contains first two character state next three number issue office and last remaning unique employee // 10 bytes
                    obj.OWNER_NAME = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["OWNERNAME"].ToString());          //"Joginder Singh"; //35 Byte
                    obj.OWNER_SERIAL_NUMBER = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["Ownerserial"].ToString());                     //"1"; // 1 Byte
                    obj.REGESTRATION_VALIDITY = Common.ReturnDate(objHoldVehicleRecords.Rows[0]["REGNVALIDITY"].ToString());        //"01012015"; // 4 Byte
                    obj.TAXPAIDUPTO = Common.ReturnDate(objHoldVehicleRecords.Rows[0]["TAXPAIDUPTO"].ToString());                  //"01012016"; // 4 Byte
                    obj.VRC_NUMBER = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["VEHREGNO"].ToString());                      //"1234567800"; //10 Byte


                    HYPOTHECATION_DETAILS HYY = new HYPOTHECATION_DETAILS();
                    HYY.ADDRESS = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["FINADDRESS"].ToString());         // "HYTEST"; // 30 Bytes
                    HYY.FINANCIER = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["FINNAME"].ToString());            // "HYFinancier"; // 35 Bytes
                    HYY.FROMDATE = Common.ReturnDate(objHoldVehicleRecords.Rows[0]["HYPOFROM"].ToString());            //  "02022016"; //4  Bytes
                    HYY.TODATE = Common.ReturnDate(objHoldVehicleRecords.Rows[0]["HYPOTO"].ToString());                // "02022016"; // 4 Bytes
                    obj.OBJ_HYPODETAILS = HYY;


                    ///Noc Details....
                    ///
                    NOC_DETAILS noc = new NOC_DETAILS();
                    noc.NOC_NUMBER = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["NOCNO"].ToString());
                    noc.NOC_Issue_Date = Common.ReturnDate(objHoldVehicleRecords.Rows[0]["NOCISSUEDT"].ToString());    // "02022016"; // 4 Byte
                    noc.RTO_TO = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["RTOTO"].ToString());              // "12"; // 4 bytes
                    noc.STATE_TO = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["STATETO"].ToString());         // "1"; // 2 Bytes
                    noc.NCRB_Number = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["NCRBCLEARNO"].ToString());     // 4 bytes...
                    obj.OBJ_NOC_DETAILS = noc;


                    /// Insurance Details
                    /// 
                    INSURANCE_DETAILS ins = new INSURANCE_DETAILS();
                    ins.INSURANCE_CMP_NAME = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["INSCOMPNAME"].ToString());//  35 Bytes "HDFC";
                    ins.INSURANCE_TILLDATE = Common.ReturnDate(objHoldVehicleRecords.Rows[0]["INSVALIDUPTO"].ToString()); // 4 bytes "02022016";
                    ins.POLICY_NUMBER = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["COVERPOLICYNO"].ToString()); // 25 bytes "123";
                    ins.TypeofOnsurance = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["INSTYPE"].ToString()); //  1 bytes "a";
                    obj.obj_INSURANCE_DETAILS = ins;


                    /// Puc Details
                    /// 
                    PUC_DETAILS puc = new PUC_DETAILS();
                    puc.PUC_CODE = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["PUCCENTERCODE"].ToString()); // 4 bytes  "1";
                    puc.PUC_VALIDITY_DATE = Common.ReturnDate(objHoldVehicleRecords.Rows[0]["PUCVALIDUPTO"].ToString()); // 4 bytes "02022016";
                    obj.obj_PUC_DETAILS = puc;

                    // Tax Details

                    TAX_DETAILS tax = new TAX_DETAILS();

                    tax.Amount = Convert.ToInt32(objHoldVehicleRecords.Rows[0]["TAXAMOUNT"]); // 103;  // intger 3 Byte 
                    tax.Backend_Update_Flag = Convert.ToInt32(objHoldVehicleRecords.Rows[0]["BUFLAG"]); // 00; // Intger 00 or 01
                    tax.DRTO_Code = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["DRTOCODE"].ToString()); // "11"; // 2 Bytes String
                    tax.Exemption = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["EXEMPTION"].ToString()); // "Y"; // One Byte Y or N
                    tax.Exemption_Receipt_No = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["EXEMPTRECPTNO"].ToString()); // "Exemption"; // 11 bytes string
                    tax.Fine = Convert.ToInt32(objHoldVehicleRecords.Rows[0]["FINE"]); // 123456; // 6 Bytes Integer...
                    tax.Payment_Date = Common.ReturnDate(objHoldVehicleRecords.Rows[0]["PAYMENTDT"].ToString()); // "02022016"; //4 Bytes Date
                    tax.Valid_From = Common.ReturnDate(objHoldVehicleRecords.Rows[0]["TAXVALIDFROM"].ToString()); // "02022016"; // 4 Bytes date
                    tax.Valid_To = Common.ReturnDate(objHoldVehicleRecords.Rows[0]["TAXVALIDTO"].ToString()); // "02022016"; // 4 Bytes date
                    obj.objTAZ_DETAILS = tax;

                    //

                    // Fitness Details...


                    FITNESS_DETAILS fitness = new FITNESS_DETAILS();
                    fitness.FITTNESS_DATE_VALID = Common.ReturnDate(objHoldVehicleRecords.Rows[0]["FITVALIDUPTO"].ToString());// 4 bytes "02022016";
                    fitness.FITTNESS_TEST_INSPECTOR_ID = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["FITINSOFFICER"].ToString());// 16 bytes "1";
                    fitness.FITTNESS_TEST_LOCATION = Common.ValidateORReturnSomeValue(objHoldVehicleRecords.Rows[0]["FITLOCATION"].ToString());// 16 bytes "t";
                    obj.obj_FITNESS_DETAILS = fitness;



                    // Addition Vehicle Details
                    VEHICLE_ADDITIONAL_DETAILS details = new VEHICLE_ADDITIONAL_DETAILS();
                    details.VEHICLE_WEIGHT = Convert.ToInt32(objHoldVehicleRecords.Rows[0]["GROSSVEHWT"]);           // 120; // 6 Bytes
                    details.Number_of_Semi_Trailers = Convert.ToInt32(objHoldVehicleRecords.Rows[0]["SEMITRAILERS"]); // 1 ; // Integer 1 Byte

                    int Length = objHoldVehicleRecords.Rows[0]["TYREINFO"].ToString().Length;
                    string StrTemp = objHoldVehicleRecords.Rows[0]["TYREINFO"].ToString().Trim().PadRight(64);

                    //if (Length > 0)
                    //{
                        details.Front_Axle = Common.ValidateORReturnSomeValue(StrTemp.Substring(0, 16));                 // "front" 16 Byte
                        details.Rear_Axle = Common.ValidateORReturnSomeValue(StrTemp.Substring(16, 16));                 // "rear" 16 Byte
                        details.Tandem_Axle = Common.ValidateORReturnSomeValue(StrTemp.Substring(32, 16));               // "tandem" 16 Byte 
                        details.Any_Other_Axle = Common.ValidateORReturnSomeValue(StrTemp.Substring(48, 16));            // "any other" 16 Byte
                    //}


                    //Registered 
                    details.Registered_Axle_Weights_Front_Axle = Convert.ToInt32(objHoldVehicleRecords.Rows[0]["AXLEINFO"].ToString().Substring(0, 6));    // "front" 6 Byte
                    details.Registered_Axle_Weights_Rear_Axle = Convert.ToInt32(objHoldVehicleRecords.Rows[0]["AXLEINFO"].ToString().Substring(6, 6));        // "rear" 6 Byte
                    details.Registered_Axle_Weights_Tandem_Axle = Convert.ToInt32(objHoldVehicleRecords.Rows[0]["AXLEINFO"].ToString().Substring(12, 6));        // "tandem" 6 Byte
                    details.Registered_Axle_Weights_Any_Other_Axle = Convert.ToInt32(objHoldVehicleRecords.Rows[0]["AXLEINFO"].ToString().Substring(18, 6));      // "any other" 6 Byte


                    obj.obj_VEHICLE_ADDITIONAL_DTL = details;
                    string strErrorMSg = string.Empty;
                    persoRCDU.SMARTCARDHELPER objSCHELPER = new persoRCDU.SMARTCARDHELPER();
                    persoCarrd objpersocard = new persoCarrd();
                    #endregion

                    //Check data come singlePrint page or Bluk Printing Page...
                    if (IsSingleCardWrite)
                    {
                        string ReaderName = string.Empty;
                        ReaderName = readerName;
                        if (ReaderName == string.Empty)
                        {
                            strErrorMSg = "No Card Attach Plz check and try Again ?";
                            returnMessage = strErrorMSg;
                        }
                        if (!objSCHELPER.Connect_Slected_Reader(hcontext, ReaderName, ref SChandle, ref scproto, ref strErrorMSg))
                        {
                            returnMessage = strErrorMSg;
                        }
                    }


                    else
                    {
                        // If your Printer DTC category...
                        if (printerName.Contains("DTC"))
                        {

                            hcontext = -855572480;
                            objSCHELPER.Connect_Slected_Reader(hcontext, readerName, ref SChandle, ref scproto, ref strErrorMSg);
                        }
                        //if Your Printer Evolis category....
                        if (printerName.Contains("Evolis") && readerName.Contains("Gemplus"))
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                objSCHELPER.SCardRealeaseContext_T(hcontext);
                                objSCHELPER.SCardEstablishContext_T(ref hcontext);
                                objSCHELPER.Connect_Slected_Reader(hcontext, readerName, ref SChandle, ref scproto, ref strErrorMSg);
                                //objSCHELPER.Connect_Slected_Reader(hcontext, readerName, ref SChandle, ref scproto, ref strErrorMSg);
                                if (strErrorMSg == "0:SUCESS")
                                    break;
                            }
                        }
                        else
                            strErrorMSg = "Please select valid printer and reader";
                    }
                    /// If your reader connect successfully... Return 0:sucess
                    /// 

                    if (strErrorMSg == "0:SUCESS")
                    {
                      
                        #region Read The Chip Serail No....Please No Change...
                      
                       
                       // chipSerialNo = string.Empty;
                        //objSCHELPER.ReadChipSrno(SChandle, scproto, ref chipSerialNo);
                        
                        #endregion

                        //if (IsSingleCardWrite)
                        //{
                        //    string IsEmptyPrinter = BusinessHelper.SendCommand(printerName, "Se", "5000");
                        //    string IsResultOK = BusinessHelper.SendCommand(printerName, "Sis", "5000");
                        //}
                        /// If you want New card Perso then must be used 'N' Or used reused card then must be 'B' (any word can apply)...
                        objpersocard.VRC_PERSO_CARD(obj, SChandle, scproto, 'N', ref strErrorMSg);

                        chipSerialNo = string.Empty;
                        int i = 1;
                        while (!Common.ValidateStringValue(chipSerialNo)&& i<=3)
                        {

                            objSCHELPER.ReadChipSrno(SChandle, scproto, ref chipSerialNo);
                            i++;
                        }
                        //Disconnect Card
                        string Disconnect_Msg = "";
                        objSCHELPER.Disconnect_Selected_Reader(SChandle, ref Disconnect_Msg);
                        returnMessage = strErrorMSg;
                    }
                    else
                        returnMessage = strErrorMSg;
                }
                else
                {

                    returnMessage = "Select a Reader Device and then Write";
                }
            }
            else
            {
                returnMessage = "No Records Found";
            }
        }



    }
}

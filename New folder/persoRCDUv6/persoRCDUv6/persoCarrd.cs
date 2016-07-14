// Decompiled with JetBrains decompiler
// Type: persoRCDU.persoCarrd
// Assembly: persoRCDU, Version=6.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0D4F6960-B5F8-4A30-A483-110C96E1E306
// Assembly location: D:\Piyush\NewProject\DLRC_DamanDiu\RC\persoRCDU.dll

using System;
using System.Threading;

namespace persoRCDU
{
  public class persoCarrd
  {
    private VEHICLE_PERSONAL_REGESTARTION_DATA OBJVEHICL_DATA;
    private DL_PERSONALINFORMATION DLPERSOINFO;
    private DLINFORMATION DLINFO;
    private uint SC_HANDLE;
    private uint SC_PROTO;
    private SMARTCARDHELPER objSMARTCARDHELPER;

    public persoCarrd()
    {
      this.objSMARTCARDHELPER = new SMARTCARDHELPER();
    }

    private bool Create_VRC_STRUCTURE(ref string strMsg)
    {
      try
      {
        string[] strArray1 = new string[16]
        {
          "00E000000C620A83023F008201388A0101",
          "00A40000023F00",
          "00E00000366234820138830250008410524320202020202020202020202020208A01018C087FFFFF22222222FFAB08860422F422F297008D02500C",
          "00A40000025000",
          "00E000001B621982050C0100150D830250028801108A01018C066BFFFF22FFFF",
          "00E000001B621982050C01000E0A8302500C8801608A01018C066BFFFF22FFFF",
          "00E000001B62198002016882020101830250038A01018801188C056AFFFF2222",
          "00E000001B62198002004682020101830250048A01018801208C056AFFFF2229",
          "00E000001B62198002000C82020101830250058A01018801288C056AFFFF2228",
          "00E000001B62198002002882020101830250068A01018801308C056AFFFF2223",
          "00E000001B621982050341002305830250078A01018801388C066EFFFF222121",
          "00E000001A621882050301004705830250088A01018801408C056AFFFF2224",
          "00E000001B621982050341002505830250098A01018801488C066EFFFF222525",
          "00E000001B6219800200E6820201018302500A8A01018801508C056AFFFF2727",
          "00E000001B621980020084820201018302500B8A01018801588C056AFFFF2726",
          "00E000001A621882050301003F0A8302500D8A01018801688C056AFFFF272A"
        };
        string[] strArray2 = new string[16]
        {
          "MASTER FILE CREATION ERROR ...",
          "MASTER FILE SELECTION ERROR ...",
          "RCDF CREATION ERROR ...",
          "RCDF SELECTION ERROR ...",
          "KEY FILE CREATION ERROR ...",
          "SECURITY REFERENCE FILE CREATION ERROR ...",
          "VEHICLE PERSONAL FILE CREATION ERROR ...",
          "VEHICLE INSURANCE FILE CREATION ERROR ...",
          "VEHICLE PUC FILE CREATION ERROR ...",
          "VEHICLE FITNESS FILE CREATION ERROR ...",
          "VEHICLE TAX FILE CREATION ERROR ...",
          "VEHICLE ENDORCEMENT FILE CREATION ERROR ...",
          "VEHICLE REVIEW FILE CREATION ERROR ...",
          "VEHICLE PERMIT FILE CREATION ERROR ...",
          "VEHICLE COUNTER SIGNATURE FILE CREATION ERROR ...",
          "VEHICLE ATUHORIZATION FILE CREATION ERROR ..."
        };
        int index = 0;
        string CMDRESULT = string.Empty;
        for (; index < strArray1.Length; ++index)
        {
          if (!this.objSMARTCARDHELPER.ExecuteCommand(this.SC_HANDLE, this.SC_PROTO, strArray1[index], ref CMDRESULT))
          {
            strMsg = strArray2[index] + " \n Error Code : " + CMDRESULT;
            return false;
          }
          strMsg = "CMD:" + strArray1[index] + " executed";
          Thread.Sleep(300);
        }
        strMsg = "Strucutre Create Successfully";
        return true;
      }
      catch (Exception ex)
      {
        strMsg = "EXCEPTION :- CREATE_STRUCTURE, " + ex.Message;
        return false;
      }
    }

    private bool Write_5003_VECHILE_ERPSONAL_INFO(char flag, ref string strMsg)
    {
      try
      {
        string str1 = string.Empty;
        string str2 = string.Empty;
        string str3 = string.Empty;
        string str4 = string.Empty;
        string str5 = string.Empty;
        string Input1 = this.OBJVEHICL_DATA.VRC_NUMBER.PadRight(10, ' ');
        string str6 = str2 + "C0" + Input1.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input1);
        string Input2 = this.OBJVEHICL_DATA.OWNER_NAME.PadRight(35, ' ');
        string str7 = str6 + "C1" + Input2.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input2);
        string Input3 = this.OBJVEHICL_DATA.FATHER_NAME.PadRight(35, ' ');
        string str8 = str7 + "C2" + Input3.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input3) + "C304" + this.OBJVEHICL_DATA.TAXPAIDUPTO + "C404" + this.OBJVEHICL_DATA.REGESTRATION_VALIDITY;
        string Input4 = this.OBJVEHICL_DATA.ISSUING_AUTH_ID.PadRight(10, ' ');
        string str9 = str8 + "C5" + Input4.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input4) + "C601" + this.OBJVEHICL_DATA.OWNER_SERIAL_NUMBER.PadLeft(2, '0') + "C749" + (this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.OBJ_HYPODETAILS.FINANCIER.PadRight(35, ' ') + this.OBJVEHICL_DATA.OBJ_HYPODETAILS.ADDRESS.PadRight(30, ' ')) + this.OBJVEHICL_DATA.OBJ_HYPODETAILS.FROMDATE + this.OBJVEHICL_DATA.OBJ_HYPODETAILS.TODATE);
        string str10 = this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.OBJ_NOC_DETAILS.NOC_NUMBER.PadRight(30, ' ') + this.OBJVEHICL_DATA.OBJ_NOC_DETAILS.STATE_TO.PadRight(2, ' ') + this.OBJVEHICL_DATA.OBJ_NOC_DETAILS.RTO_TO.PadRight(4, ' ') + this.OBJVEHICL_DATA.OBJ_NOC_DETAILS.NOC_NUMBER.PadRight(20, ' ')) + this.OBJVEHICL_DATA.OBJ_NOC_DETAILS.NOC_Issue_Date;
        string str11 = str9 + "C83C" + str10;
        str1 = this.OBJVEHICL_DATA.obj_VEHICLE_ADDITIONAL_DTL.VEHICLE_WEIGHT.ToString().PadLeft(6, '0') + this.OBJVEHICL_DATA.obj_VEHICLE_ADDITIONAL_DTL.Number_of_Semi_Trailers.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.obj_VEHICLE_ADDITIONAL_DTL.Front_Axle.PadRight(16, ' ')) + this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.obj_VEHICLE_ADDITIONAL_DTL.Rear_Axle.PadRight(16, ' ')) + this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.obj_VEHICLE_ADDITIONAL_DTL.Tandem_Axle.PadRight(16, ' ')) + this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.obj_VEHICLE_ADDITIONAL_DTL.Any_Other_Axle.PadRight(16, ' ')) + this.OBJVEHICL_DATA.obj_VEHICLE_ADDITIONAL_DTL.Registered_Axle_Weights_Front_Axle.ToString("X").PadLeft(6, '0') + this.OBJVEHICL_DATA.obj_VEHICLE_ADDITIONAL_DTL.Registered_Axle_Weights_Rear_Axle.ToString("X").PadLeft(6, '0') + this.OBJVEHICL_DATA.obj_VEHICLE_ADDITIONAL_DTL.Registered_Axle_Weights_Tandem_Axle.ToString("X").PadLeft(6, '0') + this.OBJVEHICL_DATA.obj_VEHICLE_ADDITIONAL_DTL.Registered_Axle_Weights_Any_Other_Axle.ToString("X").PadLeft(6, '0');
        string HexInputData = str11 + "C950" + str10;
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "3F00"))
        {
          strMsg = "MASTER FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5000"))
        {
          strMsg = "RCDF FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5003"))
        {
          strMsg = "VRC PERSONAL File Selection Error";
          return false;
        }
        if ((int) flag == 78 || (int) flag == 110)
        {
          if (!this.objSMARTCARDHELPER.WriteOnCurrentSelectedFile(this.SC_HANDLE, this.SC_PROTO, HexInputData, "0000", ref strMsg))
          {
            strMsg = "VRC Data Writing Error :- " + strMsg;
            return false;
          }
        }
        else if (!this.objSMARTCARDHELPER.updateOnCurrentSelectedFile(this.SC_HANDLE, this.SC_PROTO, HexInputData, "0000", ref strMsg))
        {
          strMsg = "VRC Data Updating Error :- " + strMsg;
          return false;
        }
        return true;
      }
      catch (Exception ex)
      {
        strMsg = "EXCEPTION :- WRITE_5003" + ex.Message;
        return false;
      }
    }

    private bool Write_5004_INSURANCE_DETAILS(char flag, ref string strMsg)
    {
      try
      {
        string str1 = string.Empty;
        string str2 = string.Empty;
        string str3 = string.Empty;
        string str4 = string.Empty;
        string str5 = string.Empty;
        string HexInputData = this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.obj_INSURANCE_DETAILS.INSURANCE_CMP_NAME.PadRight(35, ' ')) + this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.obj_INSURANCE_DETAILS.POLICY_NUMBER.PadRight(25, ' ')) + this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.obj_INSURANCE_DETAILS.TypeofOnsurance.PadRight(1, ' ')) + this.OBJVEHICL_DATA.obj_INSURANCE_DETAILS.INSURANCE_TILLDATE;
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "3F00"))
        {
          strMsg = "MASTER FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5000"))
        {
          strMsg = "RCDF FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5004"))
        {
          strMsg = "INSURANCE File Selection Error";
          return false;
        }
        if ((int) flag == 78 || (int) flag == 110)
        {
          if (!this.objSMARTCARDHELPER.WriteOnCurrentSelectedFile(this.SC_HANDLE, this.SC_PROTO, HexInputData, "0000", ref strMsg))
          {
            strMsg = "Insurance Data Writing Error :- " + strMsg;
            return false;
          }
        }
        else if (!this.objSMARTCARDHELPER.updateOnCurrentSelectedFile(this.SC_HANDLE, this.SC_PROTO, HexInputData, "0000", ref strMsg))
        {
          strMsg = "Insurance Data Updating Error :- " + strMsg;
          return false;
        }
        return true;
      }
      catch (Exception ex)
      {
        strMsg = "EXCEPTION :- WRITE_5004" + ex.Message;
        return false;
      }
    }

    private bool Write_5005_PUC_DETAILS(char flag, ref string strMsg)
    {
      try
      {
        string str1 = string.Empty;
        string str2 = string.Empty;
        string HexInputData = this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.obj_PUC_DETAILS.PUC_CODE.PadRight(4, '0')) + this.OBJVEHICL_DATA.obj_PUC_DETAILS.PUC_VALIDITY_DATE;
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "3F00"))
        {
          strMsg = "MASTER FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5000"))
        {
          strMsg = "RCDF FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5005"))
        {
          strMsg = "PUC  File Selection Error";
          return false;
        }
        if ((int) flag == 78 || (int) flag == 110)
        {
          if (!this.objSMARTCARDHELPER.WriteOnCurrentSelectedFile(this.SC_HANDLE, this.SC_PROTO, HexInputData, "0000", ref strMsg))
          {
            strMsg = "PUC Data Writing Error :- " + strMsg;
            return false;
          }
        }
        else if (!this.objSMARTCARDHELPER.updateOnCurrentSelectedFile(this.SC_HANDLE, this.SC_PROTO, HexInputData, "0000", ref strMsg))
        {
          strMsg = "PUC Data Updating  Error :- " + strMsg;
          return false;
        }
        return true;
      }
      catch (Exception ex)
      {
        strMsg = "EXCEPTION :- WRITE_5005" + ex.Message;
        return false;
      }
    }

    private bool Write_5006_FITNESS_DETAILS(char flag, ref string strMsg)
    {
      try
      {
        string str1 = string.Empty;
        string str2 = string.Empty;
        string HexInputData = this.OBJVEHICL_DATA.obj_FITNESS_DETAILS.FITTNESS_DATE_VALID + (this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.obj_FITNESS_DETAILS.FITTNESS_TEST_INSPECTOR_ID.PadRight(16, ' ')) + this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.obj_FITNESS_DETAILS.FITTNESS_TEST_LOCATION.PadRight(16, ' ')));
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "3F00"))
        {
          strMsg = "MASTER FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5000"))
        {
          strMsg = "RCDF FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5006"))
        {
          strMsg = "FITNESS File Selection Error";
          return false;
        }
        if ((int) flag == 78 || (int) flag == 110)
        {
          if (!this.objSMARTCARDHELPER.WriteOnCurrentSelectedFile(this.SC_HANDLE, this.SC_PROTO, HexInputData, "0000", ref strMsg))
          {
            strMsg = "Fitness Data Writing Error :- " + strMsg;
            return false;
          }
        }
        else if (!this.objSMARTCARDHELPER.updateOnCurrentSelectedFile(this.SC_HANDLE, this.SC_PROTO, HexInputData, "0000", ref strMsg))
        {
          strMsg = "Fitness Data Updating Error :- " + strMsg;
          return false;
        }
        return true;
      }
      catch (Exception ex)
      {
        strMsg = "EXCEPTION :- WRITE_5006" + ex.Message;
        return false;
      }
    }

    private bool Write_5007_TAX_DETAILS(ref string strMsg)
    {
      try
      {
        string str1 = string.Empty;
        string str2 = string.Empty;
        string str3 = string.Empty;
        string str4 = string.Empty;
        string str5 = this.OBJVEHICL_DATA.objTAZ_DETAILS.Amount.ToString("X").PadLeft(6, '0') + this.OBJVEHICL_DATA.objTAZ_DETAILS.Fine.ToString("X").PadLeft(6, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.objTAZ_DETAILS.Exemption_Receipt_No.PadRight(11, ' ')) + this.OBJVEHICL_DATA.objTAZ_DETAILS.Payment_Date + this.OBJVEHICL_DATA.objTAZ_DETAILS.Valid_From + this.OBJVEHICL_DATA.objTAZ_DETAILS.Valid_To + this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.objTAZ_DETAILS.Exemption.PadRight(1, ' ')) + this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.objTAZ_DETAILS.DRTO_Code.PadRight(2, '0')) + this.OBJVEHICL_DATA.objTAZ_DETAILS.Backend_Update_Flag.ToString().PadLeft(2, '0');
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "3F00"))
        {
          strMsg = "MASTER FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5000"))
        {
          strMsg = "RCDF FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5007"))
        {
          strMsg = "TAX File Selection Error";
          return false;
        }
        for (int index = 1; index <= 5; ++index)
        {
          string CMDRESULT = string.Empty;
          string Command;
          if (index == 1)
            Command = "00D2" + index.ToString("X").PadLeft(2, '0') + "0423" + index.ToString("X").PadLeft(2, '0') + "21" + str5;
          else
            Command = "00D2" + index.ToString("X").PadLeft(2, '0') + "0423" + index.ToString("X").PadLeft(2, '0') + "21000000000000000000000000000000000000000000000000000000000000000000";
          if (!this.objSMARTCARDHELPER.ExecuteCommand(this.SC_HANDLE, this.SC_PROTO, Command, ref CMDRESULT))
          {
            strMsg = "Tax Data Writing Error :- " + CMDRESULT;
            return false;
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        strMsg = "EXCEPTION :- WRITE_5007" + ex.Message;
        return false;
      }
    }

    private bool Write_5008_EndorsementT_DETAILS(ref string strMsg)
    {
      try
      {
        string str1 = string.Empty;
        string str2 = string.Empty;
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "3F00"))
        {
          strMsg = "MASTER FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5000"))
        {
          strMsg = "RCDF FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5008"))
        {
          strMsg = "Endorsement File Selection Error";
          return false;
        }
        for (int index = 1; index <= 5; ++index)
        {
          string CMDRESULT = string.Empty;
          if (!this.objSMARTCARDHELPER.ExecuteCommand(this.SC_HANDLE, this.SC_PROTO, "00D2" + index.ToString("X").PadLeft(2, '0') + "0447" + index.ToString("X").PadLeft(2, '0') + "45000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", ref CMDRESULT))
          {
            strMsg = "Endorsement Data Writing Error :- " + CMDRESULT;
            return false;
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        strMsg = "EXCEPTION :- WRITE_5008" + ex.Message;
        return false;
      }
    }

    private bool Write_5009_REVIEW_DETAILS(ref string strMsg)
    {
      try
      {
        string str1 = string.Empty;
        string str2 = string.Empty;
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "3F00"))
        {
          strMsg = "MASTER FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5000"))
        {
          strMsg = "RCDF FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5009"))
        {
          strMsg = "Review File Selection Error";
          return false;
        }
        for (int index = 1; index <= 5; ++index)
        {
          string CMDRESULT = string.Empty;
          if (!this.objSMARTCARDHELPER.ExecuteCommand(this.SC_HANDLE, this.SC_PROTO, "00D2" + index.ToString("X").PadLeft(2, '0') + "0425" + index.ToString("X").PadLeft(2, '0') + "230000000000000000000000000000000000000000000000000000000000000000000000", ref CMDRESULT))
          {
            strMsg = "Review Data Writing Error :- " + CMDRESULT;
            return false;
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        strMsg = "EXCEPTION :- WRITE_5009" + ex.Message;
        return false;
      }
    }

    private bool Write_500A_PERMIT_DETAILS(char flag, ref string strMsg)
    {
      try
      {
        string str1 = string.Empty;
        string str2 = string.Empty;
        string str3 = string.Empty;
        string str4 = string.Empty;
        string str5 = string.Empty;
        string Input1 = this.OBJVEHICL_DATA.obj_PERMIT_DETAILS.Permit_Type.PadRight(6, ' ');
        string str6 = str2 + "C0" + Input1.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input1) + "C104" + this.OBJVEHICL_DATA.obj_PERMIT_DETAILS.Valid_from + "C204" + this.OBJVEHICL_DATA.obj_PERMIT_DETAILS.Valid_to;
        string Input2 = this.OBJVEHICL_DATA.obj_PERMIT_DETAILS.Area_of_Operation.PadRight(1, ' ');
        string str7 = str6 + "C3" + Input2.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input2);
        string Input3 = this.OBJVEHICL_DATA.obj_PERMIT_DETAILS.Route_from.PadRight(20, ' ');
        string str8 = str7 + "C4" + Input3.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input3);
        string Input4 = this.OBJVEHICL_DATA.obj_PERMIT_DETAILS.Route_to.PadRight(20, ' ');
        string str9 = str8 + "C5" + Input4.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input4);
        string Input5 = this.OBJVEHICL_DATA.obj_PERMIT_DETAILS.Stage1.PadRight(20, ' ');
        string str10 = str9 + "C6" + Input5.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input5);
        string Input6 = this.OBJVEHICL_DATA.obj_PERMIT_DETAILS.Stage2.PadRight(20, ' ');
        string str11 = str10 + "C7" + Input6.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input6);
        string Input7 = this.OBJVEHICL_DATA.obj_PERMIT_DETAILS.Stage3.PadRight(20, ' ');
        string str12 = str11 + "C8" + Input7.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input7);
        string Input8 = this.OBJVEHICL_DATA.obj_PERMIT_DETAILS.meeternumber.PadRight(25, ' ');
        string HexInputData = str12 + "C9" + Input8.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input8) + "CA36" + (this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.obj_PERMIT_DETAILS.Permit_Action_Details_CODE.PadRight(3, ' ')) + this.OBJVEHICL_DATA.obj_PERMIT_DETAILS.Permit_Action_Details_From_Date + this.OBJVEHICL_DATA.obj_PERMIT_DETAILS.Permit_Action_Details_To_Date + this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.obj_PERMIT_DETAILS.Permit_Action_Details_Reason.PadRight(25, ' '))) + "CB08" + (this.OBJVEHICL_DATA.obj_PERMIT_DETAILS.AITP_Valid_from + this.OBJVEHICL_DATA.obj_PERMIT_DETAILS.AITP_Valid_to);
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "3F00"))
        {
          strMsg = "MASTER FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5000"))
        {
          strMsg = "RCDF FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "500A"))
        {
          strMsg = "Permit  File Selection Error";
          return false;
        }
        if ((int) flag == 78 || (int) flag == 110)
        {
          if (!this.objSMARTCARDHELPER.WriteOnCurrentSelectedFile(this.SC_HANDLE, this.SC_PROTO, HexInputData, "0000", ref strMsg))
          {
            strMsg = "Permit Data Writing Error :- " + strMsg;
            return false;
          }
        }
        else if (!this.objSMARTCARDHELPER.updateOnCurrentSelectedFile(this.SC_HANDLE, this.SC_PROTO, HexInputData, "0000", ref strMsg))
        {
          strMsg = "Permit Data updating Error :- " + strMsg;
          return false;
        }
        return true;
      }
      catch (Exception ex)
      {
        strMsg = "EXCEPTION :- WRITE_500A" + ex.Message;
        return false;
      }
    }

    private bool Write_500D_AUTHORIZATIONFILE(ref string strMsg)
    {
      try
      {
        string str1 = string.Empty;
        string str2 = string.Empty;
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "3F00"))
        {
          strMsg = "MASTER FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5000"))
        {
          strMsg = "RCDF FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "500D"))
        {
          strMsg = "Authorization File Selection Error";
          return false;
        }
        for (int index = 1; index <= 10; ++index)
        {
          string CMDRESULT = string.Empty;
          if (!this.objSMARTCARDHELPER.ExecuteCommand(this.SC_HANDLE, this.SC_PROTO, "00D2" + index.ToString("X").PadLeft(2, '0') + "043F" + index.ToString("X").PadLeft(2, '0') + "3D00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", ref CMDRESULT))
          {
            strMsg = "Authorization Data Writing Error :- " + CMDRESULT;
            return false;
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        strMsg = "EXCEPTION :- WRITE_500D" + ex.Message;
        return false;
      }
    }

    private bool Write_500B_COUNTERSIGNATUREFILE(char flag, ref string strMsg)
    {
      try
      {
        string str1 = string.Empty;
        string str2 = string.Empty;
        string HexInputData = this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.objcounterSignatureFileData.Authorizing_Office_Id.PadRight(16, ' ')) + this.OBJVEHICL_DATA.objcounterSignatureFileData.Valid_from + this.OBJVEHICL_DATA.objcounterSignatureFileData.Valid_till + this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.objcounterSignatureFileData.Route_from.PadRight(20, ' ')) + this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.objcounterSignatureFileData.Route_to.PadRight(20, ' ')) + this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.objcounterSignatureFileData.Stage1.PadRight(20, ' ')) + this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.objcounterSignatureFileData.Stage2.PadRight(20, ' ')) + this.objSMARTCARDHELPER.ConvertStringToHexString(this.OBJVEHICL_DATA.objcounterSignatureFileData.Stage3.PadRight(20, ' '));
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "3F00"))
        {
          strMsg = "MASTER FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "5000"))
        {
          strMsg = "RCDF FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "500B"))
        {
          strMsg = "COUNTER SIGNATURE  File Selection Error";
          return false;
        }
        if ((int) flag == 78 || (int) flag == 110)
        {
          if (!this.objSMARTCARDHELPER.WriteOnCurrentSelectedFile(this.SC_HANDLE, this.SC_PROTO, HexInputData, "0000", ref strMsg))
          {
            strMsg = "COUNTER SIGNATURE Data Writing Error :- " + strMsg;
            return false;
          }
        }
        else if (!this.objSMARTCARDHELPER.updateOnCurrentSelectedFile(this.SC_HANDLE, this.SC_PROTO, HexInputData, "0000", ref strMsg))
        {
          strMsg = "COUNTER SIGNATURE Data updating Error :- " + strMsg;
          return false;
        }
        return true;
      }
      catch (Exception ex)
      {
        strMsg = "EXCEPTION :- WRITE_500B" + ex.Message;
        return false;
      }
    }

    public bool VRC_PERSO_CARD(VEHICLE_PERSONAL_REGESTARTION_DATA VHDATA, uint SCHANDLE, uint SCPROTO, char chrFlag, ref string ErrorMessage)
    {
      try
      {
        this.OBJVEHICL_DATA = VHDATA;
        this.SC_HANDLE = SCHANDLE;
        this.SC_PROTO = SCPROTO;
        return ((int) chrFlag != 78 || this.Create_VRC_STRUCTURE(ref ErrorMessage)) && this.Write_5003_VECHILE_ERPSONAL_INFO(chrFlag, ref ErrorMessage) && (this.Write_5004_INSURANCE_DETAILS(chrFlag, ref ErrorMessage) && this.Write_5005_PUC_DETAILS(chrFlag, ref ErrorMessage)) && (this.Write_5006_FITNESS_DETAILS(chrFlag, ref ErrorMessage) && this.Write_5007_TAX_DETAILS(ref ErrorMessage) && (this.Write_5008_EndorsementT_DETAILS(ref ErrorMessage) && this.Write_5009_REVIEW_DETAILS(ref ErrorMessage))) && (this.Write_500A_PERMIT_DETAILS(chrFlag, ref ErrorMessage) && this.Write_500D_AUTHORIZATIONFILE(ref ErrorMessage) && this.Write_500B_COUNTERSIGNATUREFILE(chrFlag, ref ErrorMessage));
      }
      catch (Exception ex)
      {
        ErrorMessage = "EXCEPTION :- " + ex.Message;
        return false;
      }
    }

    private bool Create_DL_STRUCTURE(ref string strMsg)
    {
      try
      {
        string[] strArray1 = new string[10]
        {
          "00E000000C620A83023F008201388A0101",
          "00A40000023F00",
          "00E00000346232820138830240008410444C20202020202020202020202020208A01018C087F23232323FFFF23AB068402222A97008D024003",
          "00A40000024000",
          "00E000001B621982050C01001604830240028801108A01018C066B232323FFFF",
          "00E000001B621982050C01001404830240038801188A01018C066B232323FFFF",
          "00E00000196217800200A082020141830240048A01018C066E232323FFFF",
          "00E000001962178002019082020141830240058A01018C066E232323FF23",
          "00E0000017621582050301005C0A830240068A01018C056A23232322",
          "00E000001862168205034100250A830240078A01018C066E2323232121"
        };
        string[] strArray2 = new string[10]
        {
          "MASTER FILE CREATION ERROR ...",
          "MASTER FILE SELECTION ERROR ...",
          "DLDF CREATION ERROR ...",
          "DLDF SELECTION ERROR ...",
          "KEY FILE CREATION ERROR ...",
          "SECURITY REFERENCE FILE CREATION ERROR ...",
          "PERSONAL FILE CREATION ERROR ...",
          "DL IFNO FILE CREATION ERROR ...",
          "DL ENDORCEMENT FILE CREATION ERROR ...",
          "DL REVIEW FILE CREATION ERROR ..."
        };
        int index = 0;
        string CMDRESULT = string.Empty;
        for (; index < strArray1.Length; ++index)
        {
          if (!this.objSMARTCARDHELPER.ExecuteCommand(this.SC_HANDLE, this.SC_PROTO, strArray1[index], ref CMDRESULT))
          {
            strMsg = strArray2[index] + " \n Error Code : " + CMDRESULT;
            return false;
          }
          strMsg = "CMD:" + strArray1[index] + " executed";
          Thread.Sleep(300);
        }
        strMsg = "Strucutre Create Successfully";
        return true;
      }
      catch (Exception ex)
      {
        strMsg = "EXCEPTION :- CREATE_STRUCTURE, " + ex.Message;
        return false;
      }
    }

    private bool Write_4004_ERPSONAL_INFO(ref string strMsg)
    {
      try
      {
        string str1 = string.Empty;
        string str2 = string.Empty;
        string str3 = string.Empty;
        string str4 = string.Empty;
        string str5 = string.Empty;
        string Input1 = "1.00";
        string str6 = str2 + "C0" + Input1.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input1);
        str1 = this.DLPERSOINFO.NAME.PadRight(40, ' ');
        string Input2 = this.DLPERSOINFO.NAME.PadRight(40, ' ');
        string str7 = str6 + "C1" + Input2.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input2);
        str1 = this.DLPERSOINFO.FATHERNAME.PadRight(40, ' ');
        string Input3 = this.DLPERSOINFO.FATHERNAME.PadRight(40, ' ');
        string str8 = str7 + "C2" + Input3.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input3) + "C304" + this.DLPERSOINFO.DATAOFBIRTH;
        string Input4 = this.DLPERSOINFO.DL_NUMBER.PadRight(16, ' ');
        string str9 = str8 + "C4" + Input4.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input4);
        string Input5 = this.DLPERSOINFO.ISSUING_AUTHORITY.PadRight(16, ' ');
        string str10 = str9 + "C5" + Input5.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input5) + "CA04" + this.DLPERSOINFO.DATE_OF_ISSUE;
        string Input6 = this.DLPERSOINFO.DL_SEQUENCE_NUMBER.PadRight(9, ' ');
        string HexInputData = str10 + "CB" + Input6.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input6);
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "3F00"))
        {
          strMsg = "MASTER FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "4000"))
        {
          strMsg = "DLDF FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "4004"))
        {
          strMsg = "DL PERSONAL File Selection Error";
          return false;
        }
        if (this.objSMARTCARDHELPER.WriteOnCurrentSelectedFile(this.SC_HANDLE, this.SC_PROTO, HexInputData, "0000", ref strMsg))
          return true;
        strMsg = "PERSONAL Data Writing Error :- " + strMsg;
        return false;
      }
      catch (Exception ex)
      {
        strMsg = "EXCEPTION :- WRITE_4004" + ex.Message;
        return false;
      }
    }

    private bool Write_4005_DL_INFO(ref string strMsg)
    {
      try
      {
        string str1 = string.Empty;
        string str2 = string.Empty;
        string str3 = string.Empty;
        string str4 = string.Empty;
        string str5 = string.Empty;
        int index1 = 0;
        string str6 = "";
        string Input1 = "1.00";
        string HexInputData = str6 + "C0" + Input1.Length.ToString("X").PadLeft(2, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(Input1) + "C604" + this.DLINFO.VALID_TILL_TRANSPORT.PadRight(4, '0') + "C704" + this.DLINFO.VALID_TILL_NON_TRANSPORT.PadRight(4, '0');
        for (; index1 < this.DLINFO.lstVechicleClass.Count; ++index1)
        {
          string Input2 = this.DLINFO.lstVechicleClass[index1].VEHICEE_CLASS.PadRight(6, ' ') + this.DLINFO.lstVechicleClass[index1].TESTING_AUTHORITY.PadRight(20, ' ') + this.DLINFO.lstVechicleClass[index1].DESIGNATION_OF_TESTING_AUTHORITY.PadRight(20, ' ');
          HexInputData = HexInputData + "C832" + this.objSMARTCARDHELPER.ConvertStringToHexString(Input2) + this.DLINFO.lstVechicleClass[index1].TESTING_DATE_OF_ISSUE.PadRight(4, '0');
        }
        if (this.DLINFO.lstBadg_info != null && this.DLINFO.lstBadg_info.Count > 1)
        {
          int index2 = 0;
          string str7 = this.objSMARTCARDHELPER.ConvertStringToHexString(this.DLINFO.lstBadg_info[index2].BADG_NUMBER.PadRight(10, ' ')) + this.DLINFO.lstBadg_info[index2].BADG_LAST_DATE_VALIDIT.PadRight(4, '0') + this.objSMARTCARDHELPER.ConvertStringToHexString(this.DLINFO.lstBadg_info[index2].BADG_AUTHORIZATION_NUBMER.PadRight(10, ' ')) + this.DLINFO.lstBadg_info[index2].BADG_AUTHORIZATION_DATE.PadRight(4, '0');
          HexInputData = HexInputData + "C91C" + str7;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "3F00"))
        {
          strMsg = "MASTER FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "4000"))
        {
          strMsg = "DLDF FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "4005"))
        {
          strMsg = "DL INFORMATION File Selection Error";
          return false;
        }
        if (this.objSMARTCARDHELPER.WriteOnCurrentSelectedFile(this.SC_HANDLE, this.SC_PROTO, HexInputData, "0000", ref strMsg))
          return true;
        strMsg = "DL Data Writing Error :- " + strMsg;
        return false;
      }
      catch (Exception ex)
      {
        strMsg = "EXCEPTION :- WRITE_4005" + ex.Message;
        return false;
      }
    }

    private bool Write_4006_EndorsementT_DETAILS(ref string strMsg)
    {
      try
      {
        string str1 = string.Empty;
        string str2 = string.Empty;
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "3F00"))
        {
          strMsg = "MASTER FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "4000"))
        {
          strMsg = "DLDF FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "4006"))
        {
          strMsg = "Endorsement File Selection Error";
          return false;
        }
        for (int index = 1; index <= 10; ++index)
        {
          string CMDRESULT = string.Empty;
          if (!this.objSMARTCARDHELPER.ExecuteCommand(this.SC_HANDLE, this.SC_PROTO, "00D2" + index.ToString("X").PadLeft(2, '0') + "045C" + index.ToString("X").PadLeft(2, '0') + "5A000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", ref CMDRESULT))
          {
            strMsg = "Endorsement Data Writing Error :- " + CMDRESULT;
            return false;
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        strMsg = "EXCEPTION :- WRITE_4006" + ex.Message;
        return false;
      }
    }

    private bool Write_4007_REVIEW_DETAILS(ref string strMsg)
    {
      try
      {
        string str1 = string.Empty;
        string str2 = string.Empty;
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "3F00"))
        {
          strMsg = "MASTER FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "4000"))
        {
          strMsg = "DLDF FILE File Selection Error";
          return false;
        }
        if (!this.objSMARTCARDHELPER.SelectNgetFileLength(this.SC_HANDLE, this.SC_PROTO, "4007"))
        {
          strMsg = "Review File Selection Error";
          return false;
        }
        for (int index = 1; index <= 10; ++index)
        {
          string CMDRESULT = string.Empty;
          if (!this.objSMARTCARDHELPER.ExecuteCommand(this.SC_HANDLE, this.SC_PROTO, "00D2" + index.ToString("X").PadLeft(2, '0') + "0425" + index.ToString("X").PadLeft(2, '0') + "230000000000000000000000000000000000000000000000000000000000000000000000", ref CMDRESULT))
          {
            strMsg = "Review Data Writing Error :- " + CMDRESULT;
            return false;
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        strMsg = "EXCEPTION :- WRITE_4007" + ex.Message;
        return false;
      }
    }

    public bool DL_PERSO_CARD(DL_PERSONALINFORMATION OBJDLPERSONALINFO, DLINFORMATION OBJDLINFO, uint SCHANDLE, uint SCPROTO, ref string ErrorMessage)
    {
      try
      {
        this.DLPERSOINFO = OBJDLPERSONALINFO;
        this.DLINFO = OBJDLINFO;
        this.SC_HANDLE = SCHANDLE;
        this.SC_PROTO = SCPROTO;
        if (!this.Create_DL_STRUCTURE(ref ErrorMessage) || !this.Write_4004_ERPSONAL_INFO(ref ErrorMessage) || (!this.Write_4005_DL_INFO(ref ErrorMessage) || !this.Write_4006_EndorsementT_DETAILS(ref ErrorMessage)) || !this.Write_4007_REVIEW_DETAILS(ref ErrorMessage))
          return false;
        ErrorMessage = "0:-Successfull";
        return true;
      }
      catch (Exception ex)
      {
        ErrorMessage = "EXCEPTION :- " + ex.Message;
        return false;
      }
    }
  }
}

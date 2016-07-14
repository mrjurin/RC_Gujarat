using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace persoRCDU
{
  public  class Driver_License_Card
    {
      /// <summary>
      /// 4 Bytes 
      /// </summary>
      public string version;
      /// <summary>
      /// string  40 bytes
      /// </summary>
      public string Name;
      /// <summary>
      /// string 40 Bytes..
      /// </summary>
      public string Relation;
      /// <summary>
      /// string mmddyyyy
      /// </summary>
      public string DOB;

      /// <summary>
      /// viz 18 char with space include 2 hyphens 
      /// First 2 char state code... and next 2 char authority...code 1 char new/renewed  and 4 number is yyyy ....
      /// scacn-yyyy-123456c
      /// </summary>
      public string DLNumber;
      /// <summary>
      /// string 16 Bytes 
      /// ST RTO EMP-CAT ID CHECKDIGIT
      /// XX 999 XX 99999999 9
      /// </summary>
      public string IssuingAuthority;
      /// <summary>
      /// 4 BYTES  
      /// MMDDYYYY IF DATE IS NOT AVAILABLE THEN ENTER 00000000
      /// </summary>
      public string DATEOFISSUE;
      /// <summary>
      /// BYTES 4 
      /// MMDDYYYY
      /// </summary>
      public string VALIDTILL_TRANSPORT;
      /// <summary>
      /// BYTES 4 
      /// MMDDYYYY
      /// </summary>
      public string VALIDTILL_NONTRANSPORT;

      //Vehicle Info 50 bytes
      //             Vechile Class 6 bytes
      //             Name of the Testing Authority 20 bytes
      //             Designation of the testing Authority 20 bytes
      //             Respective date of Issue... 4 bytes  mmddyyyy

      //
       
 
      
 





    }
}

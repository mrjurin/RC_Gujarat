﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace persoRCDU
{
    public class VEHICLE_PERSONAL_REGISTRATION_DATA
    {
        public string VRC_NUMBER;
        public string OWNER_NAME;
        public string FATHER_NAME;
        public string TAXPAIDUPTO;
        public string REGESTRATION_VALIDITY;
        public string ISSUING_AUTH_ID;
        public string OWNER_SERIAL_NUMBER;
        public HYPOTHECATION_DETAILS OBJ_HYPODETAILS;
        public NOC_DETAILS OBJ_NOC_DETAILS;
        public VEHICLE_ADDITIONAL_DETAILS obj_VEHICLE_ADDITIONAL_DTL;
        public INSURANCE_DETAILS obj_INSURANCE_DETAILS;
        public PUC_DETAILS obj_PUC_DETAILS;
        public FITNESS_DETAILS obj_FITNESS_DETAILS;
        public PERMIT_DETAILS obj_PERMIT_DETAILS;
        public TAX_DETAILS objTAZ_DETAILS;
        public COUNTER_SIGNATURE_FILE_DATA objcounterSignatureFileData;
    }
}

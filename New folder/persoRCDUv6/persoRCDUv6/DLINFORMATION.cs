// Decompiled with JetBrains decompiler
// Type: persoRCDU.DLINFORMATION
// Assembly: persoRCDU, Version=6.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0D4F6960-B5F8-4A30-A483-110C96E1E306
// Assembly location: D:\Piyush\NewProject\DLRC_DamanDiu\RC\persoRCDU.dll

using System.Collections.Generic;

namespace persoRCDU
{
  public class DLINFORMATION
  {
    public string VALID_TILL_TRANSPORT { get; set; }

    public string VALID_TILL_NON_TRANSPORT { get; set; }

    public List<DL_VEHICLE_CLASS> lstVechicleClass { get; set; }

    public List<DL_BADGE_INFO> lstBadg_info { get; set; }
  }
}

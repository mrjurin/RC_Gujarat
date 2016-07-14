// Decompiled with JetBrains decompiler
// Type: persoRCDU.DLINFORMATION
// Assembly: persoRCDU, Version=6.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4E2429F4-6CA8-499F-879C-1DD0A6A52ADC
// Assembly location: D:\Piyush\NewProject\DLRC_DamanDiu\RC\New folder\persoRCDUv6.2\persoRCDU.dll

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

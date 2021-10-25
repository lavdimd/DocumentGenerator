using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class DefaultSapObjectInterface
    {
        public int Id { get; set; }
        public string Bukrs { get; set; }
        public string Gjahr { get; set; }
        public string Monat { get; set; }
        public string Buzei { get; set; }
        public string Blart { get; set; }
        public string Budat { get; set; }
        public string Bldat { get; set; }
        public string Waers { get; set; }
        public string Xblnr { get; set; }
        public string Bktxt { get; set; }
        public string Bschl { get; set; }
        public string Shkzg { get; set; }
        public string Hkont { get; set; }
        public string Umskz { get; set; }
        public string Altkt { get; set; }
        public string Xnegp { get; set; }
        public string Sgtxt { get; set; }
        public string Zuonr { get; set; }
        public string Dmbtr { get; set; }
        public string Wrbtr { get; set; }
        public string DmbtrBrutto { get; set; }
        public string WrbtrBrutto { get; set; }
        public string Mwskz { get; set; }
        public string Mwsts { get; set; }
        public string Wmwst { get; set; }
        public string Kostl { get; set; }
        public string Aufnr { get; set; }
        public string Menge { get; set; }
        public string Meins { get; set; }
        public string Pernr { get; set; }
        public string Gsber { get; set; }
        public string Prctr { get; set; }
        public string Vbund { get; set; }
        public string Bewar { get; set; }
        public string Fkber { get; set; }
        public string Xref1 { get; set; }
        public string Xref2 { get; set; }
        public string Xref3 { get; set; }
        public string Zfbdt { get; set; }
        public string Bvtyp { get; set; }
        public string Zlsch { get; set; }
        public string Zterm { get; set; }
        public string Zlspr { get; set; }
        public string Projk { get; set; }
        public string Barcd { get; set; }
        public int SapInterfaceType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}

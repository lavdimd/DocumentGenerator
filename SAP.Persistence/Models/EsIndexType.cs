using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class EsIndexType
    {
        public EsIndexType()
        {
            EsAliasIndexLanguageMappings = new HashSet<EsAliasIndexLanguageMapping>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<EsAliasIndexLanguageMapping> EsAliasIndexLanguageMappings { get; set; }
    }
}

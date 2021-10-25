using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class EsAliasIndexLanguageMapping
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string BaseIndexName { get; set; }
        public int LanguageId { get; set; }
        public int IndexTypeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual EsIndexType IndexType { get; set; }
        public virtual Language Language { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Picture
    {
        public Picture()
        {
            ClassifiedAdPictureMappings = new HashSet<ClassifiedAdPictureMapping>();
        }

        public int Id { get; set; }
        public string SeoFilename { get; set; }
        public string AltAttribute { get; set; }
        public string TitleAttribute { get; set; }
        public string MimeType { get; set; }
        public Guid PictureGuid { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<ClassifiedAdPictureMapping> ClassifiedAdPictureMappings { get; set; }
    }
}

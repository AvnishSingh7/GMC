using System;
using System.Collections.Generic;

#nullable disable

namespace GMCManagementSystemAPI.Models
{
    public partial class UploadDocument
    {
        public int DocId { get; set; }
        public int FkDocumentTypeId { get; set; }
        public int? FkRequestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpDatedDate { get; set; }
        public int? UpDateBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Status { get; set; }

        public virtual DocumentType FkDocumentType { get; set; }
        public virtual RequestDetail FkRequest { get; set; }
    }
}

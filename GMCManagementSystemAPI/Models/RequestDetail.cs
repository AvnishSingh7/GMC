using System;
using System.Collections.Generic;

#nullable disable

namespace GMCManagementSystemAPI.Models
{
    public partial class RequestDetail
    {
        public RequestDetail()
        {
            UploadDocuments = new HashSet<UploadDocument>();
        }

        public int RequestId { get; set; }
        public int FkMcdId { get; set; }
        public int FkCatId { get; set; }
        public int FkSubCatId { get; set; }
        public int FkSchemeId { get; set; }
        public int? FkComponentId { get; set; }
        public int? FkAnnouncementId { get; set; }
        public string WardNumber { get; set; }
        public string NameOfWork { get; set; }
        public string ScopeOfWork { get; set; }
        public string AnnouncementNumber { get; set; }
        public DateTime? AnnouncementDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpDatedDate { get; set; }
        public int? UpDateBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Status { get; set; }

        public virtual TypesOfAnnouncement FkAnnouncement { get; set; }
        public virtual CategoryOfWork FkCat { get; set; }
        public virtual ComponentOfScheme FkComponent { get; set; }
        public virtual MunicipalCorporationDetail FkMcd { get; set; }
        public virtual TypesOfScheme FkScheme { get; set; }
        public virtual SubCategoryOfWork FkSubCat { get; set; }
        public virtual ICollection<UploadDocument> UploadDocuments { get; set; }
    }
}

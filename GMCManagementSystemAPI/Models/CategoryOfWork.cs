using System;
using System.Collections.Generic;

#nullable disable

namespace GMCManagementSystemAPI.Models
{
    public partial class CategoryOfWork
    {
        public CategoryOfWork()
        {
            MunicipalCorporationCategoryMappings = new HashSet<MunicipalCorporationCategoryMapping>();
            RequestDetails = new HashSet<RequestDetail>();
            SubCategoryOfWorks = new HashSet<SubCategoryOfWork>();
        }

        public int CatId { get; set; }
        public int FkMcdId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpDatedDate { get; set; }
        public int? UpDateBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Status { get; set; }

        public virtual MunicipalCorporationDetail FkMcd { get; set; }
        public virtual ICollection<MunicipalCorporationCategoryMapping> MunicipalCorporationCategoryMappings { get; set; }
        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
        public virtual ICollection<SubCategoryOfWork> SubCategoryOfWorks { get; set; }
    }
}

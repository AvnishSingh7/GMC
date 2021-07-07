using System;
using System.Collections.Generic;

#nullable disable

namespace GMCManagementSystemAPI.Models
{
    public partial class MunicipalCorporationCategoryMapping
    {
        public int MccId { get; set; }
        public int FkMcdId { get; set; }
        public int FkCatId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpDatedDate { get; set; }
        public int? UpDateBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Status { get; set; }

        public virtual CategoryOfWork FkCat { get; set; }
        public virtual MunicipalCorporationDetail FkMcd { get; set; }
    }
}

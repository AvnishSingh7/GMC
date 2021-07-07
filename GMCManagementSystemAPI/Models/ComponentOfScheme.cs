using System;
using System.Collections.Generic;

#nullable disable

namespace GMCManagementSystemAPI.Models
{
    public partial class ComponentOfScheme
    {
        public ComponentOfScheme()
        {
            RequestDetails = new HashSet<RequestDetail>();
        }

        public int ComponentId { get; set; }
        public int FkSchemeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpDatedDate { get; set; }
        public int? UpDateBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Status { get; set; }

        public virtual TypesOfScheme FkScheme { get; set; }
        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
    }
}

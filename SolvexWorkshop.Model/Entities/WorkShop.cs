using SolvexWorkShop.Core.BaseModel;
using System;
using System.Collections.Generic;

namespace SolvexWorkshop.Model.Entities
{
    public class WorkShop : BaseEntity
    {
        public WorkShop()
        {
            Days = new HashSet<WorkShopDay>();
            Members = new HashSet<WorkShopMember>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ContentSupport { get; set; }
        public virtual ICollection<WorkShopDay> Days { get; set; }
        public virtual ICollection<WorkShopMember> Members { get; set; }
    }
}

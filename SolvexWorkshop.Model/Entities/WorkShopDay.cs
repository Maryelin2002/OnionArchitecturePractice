using SolvexWorkShop.Core.BaseModel;
using SolvexWorkShop.Core.Enums;
using System;

namespace SolvexWorkshop.Model.Entities
{
    public class WorkShopDay : BaseEntity
    {
        public WeekDay Day { get; set; }
        public WorkShopDayMode Mode { get; set; }
        public string ModeLocation { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan? EndHour { get; set; }

        public int WorkShopId { get; set; }
        public virtual WorkShop WorkShop { get; set; }
    }
}

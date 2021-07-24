using SolvexWorkShop.Core.BaseModel;
using SolvexWorkShop.Core.Enums;
using System;

namespace SolvexWorkShop.Bl.Dto
{
    public class WorkShopDayDto : BaseEntityDto
    {
        public WeekDay Day { get; set; }
        public WorkShopDayMode Mode { get; set; }
        public string ModeLocation { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan? EndHour { get; set; }

        public int WorkShopId { get; set; }
    }
}

﻿using SolvexWorkshop.Model.Entities;
using SolvexWorkShop.Core.BaseModel;
using SolvexWorkShop.Core.Enums;

namespace SolvexWorkShop.Bl.Dto
{
    public class WorkShopMemberDto : BaseEntityDto
    {
        public WorkShopMemberRole Role { get; set; }
        public int WorkShopId { get; set; }
        public int UserId { get; set; }
    }
}

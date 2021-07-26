using GenericApi.Controllers;
using SolvexWorkshop.Model.Entities;
using SolvexWorkShop.Bl.Dto;
using SolvexWorkShop.Services.Services;

namespace SolvexWorkShop.Controllers
{
    public class WorkShopDayController : BaseController<WorkShopDay, WorkShopDayDto>
    {
        public WorkShopDayController(IWorkShopDayService service) : base(service)
        {

        }
    }
}

using GenericApi.Controllers;
using SolvexWorkshop.Model.Entities;
using SolvexWorkShop.Bl.Dto;
using SolvexWorkShop.Services.Services;

namespace SolvexWorkShop.Controllers
{
    public class WorkShopController : BaseController<WorkShop, WorkShopDto>
    {
        public WorkShopController(IWorkShopService service) : base(service)
        {

        }
    }
}

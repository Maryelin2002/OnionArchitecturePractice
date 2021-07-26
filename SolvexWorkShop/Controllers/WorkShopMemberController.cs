using GenericApi.Controllers;
using SolvexWorkshop.Model.Entities;
using SolvexWorkShop.Bl.Dto;
using SolvexWorkShop.Services.Services;

namespace SolvexWorkShop.Controllers
{
    public class WorkShopMemberController : BaseController<WorkShopMember, WorkShopMemberDto>
    {
        public WorkShopMemberController(IWorkShopMemberService service) : base(service)
        {

        }
    }
}

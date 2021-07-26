using GenericApi.Controllers;
using SolvexWorkshop.Model.Entities;
using SolvexWorkShop.Bl.Dto;
using SolvexWorkShop.Services.Services;

namespace SolvexWorkShop.Controllers
{
    public class UserController : BaseController<User, UserDto>
    {
        public UserController(IUserService service) : base(service)
        {

        }
    }
}

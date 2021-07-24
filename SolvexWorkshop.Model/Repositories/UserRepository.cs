using SolvexWorkshop.Model.Contexts;
using SolvexWorkshop.Model.Entities;

namespace SolvexWorkshop.Model.Repositories
{
    public interface IUserRepository : IBaseRepository<User> { }
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(WorkShopContext context) : base(context)
        {

        }
    }
}

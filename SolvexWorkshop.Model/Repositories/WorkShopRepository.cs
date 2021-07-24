using SolvexWorkshop.Model.Contexts;
using SolvexWorkshop.Model.Entities;

namespace SolvexWorkshop.Model.Repositories
{
    public interface IWorkShopRepository : IBaseRepository<WorkShop> { }
    public class WorkShopRepository : BaseRepository<WorkShop>, IWorkShopRepository
    {
        public WorkShopRepository(WorkShopContext context) : base(context)
        {

        }
    }
}

using SolvexWorkshop.Model.Contexts;
using SolvexWorkshop.Model.Entities;

namespace SolvexWorkshop.Model.Repositories
{
    public interface IWorkShopDayRepository : IBaseRepository<WorkShopDay> { }
    public class WorkShopDayRepository : BaseRepository<WorkShopDay>, IWorkShopDayRepository
    {
        public WorkShopDayRepository(WorkShopContext context) : base(context)
        {

        }
    }
}

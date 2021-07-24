using SolvexWorkshop.Model.Contexts;
using SolvexWorkshop.Model.Entities;

namespace SolvexWorkshop.Model.Repositories
{
    public interface IWorkShopMemberRepository : IBaseRepository<WorkShopMember> { }
    public class WorkShopMemberRepository : BaseRepository<WorkShopMember>, IWorkShopMemberRepository
    {
        public WorkShopMemberRepository(WorkShopContext context) : base(context)
        {

        }
    }
}

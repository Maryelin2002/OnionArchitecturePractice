using SolvexWorkshop.Model.Contexts;
using SolvexWorkshop.Model.Entities;

namespace SolvexWorkshop.Model.Repositories
{
    public interface IDocumentRepository : IBaseRepository<Document> { }
    public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(WorkShopContext context) : base(context)
        {

        }
    }
}

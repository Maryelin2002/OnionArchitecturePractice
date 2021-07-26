using GenericApi.Controllers;
using SolvexWorkshop.Model.Entities;
using SolvexWorkShop.Bl.Dto;
using SolvexWorkShop.Services.Services;

namespace SolvexWorkShop.Controllers
{
    public class DocumentController : BaseController<Document, DocumentDto>
    {
        public DocumentController(IDocumentService service) : base(service)
        {

        }
    }
}

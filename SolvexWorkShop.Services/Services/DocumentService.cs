using AutoMapper;
using FluentValidation;
using SolvexWorkshop.Model.Entities;
using SolvexWorkshop.Model.Repositories;
using SolvexWorkShop.Bl.Dto;

namespace SolvexWorkShop.Services.Services
{
    public interface IDocumentService : IBaseService<Document, DocumentDto> { }
    public class DocumentService : BaseService<Document, DocumentDto>, IDocumentService
    {
        public DocumentService(
            IDocumentRepository repository,
            IMapper mapper,
            IValidator<DocumentDto> validator) : base(repository, mapper, validator)
        {
        }
    }
}

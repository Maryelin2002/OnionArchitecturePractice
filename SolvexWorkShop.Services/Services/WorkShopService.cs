using AutoMapper;
using FluentValidation;
using SolvexWorkshop.Model.Entities;
using SolvexWorkshop.Model.Repositories;
using SolvexWorkShop.Bl.Dto;

namespace SolvexWorkShop.Services.Services
{
    public interface IWorkShopService : IBaseService<WorkShop, WorkShopDto> { }
    public class WorkShopService : BaseService<WorkShop, WorkShopDto>, IWorkShopService
    {
        public WorkShopService(
            IWorkShopRepository repository,
            IMapper mapper,
            IValidator<WorkShopDto> validator) : base(repository, mapper, validator)
        {
        }
    }
}

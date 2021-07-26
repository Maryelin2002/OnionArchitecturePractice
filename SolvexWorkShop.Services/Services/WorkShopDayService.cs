using AutoMapper;
using FluentValidation;
using SolvexWorkshop.Model.Entities;
using SolvexWorkshop.Model.Repositories;
using SolvexWorkShop.Bl.Dto;

namespace SolvexWorkShop.Services.Services
{
    public interface IWorkShopDayService : IBaseService<WorkShopDay, WorkShopDayDto> { }
    public class WorkShopDayService : BaseService<WorkShopDay, WorkShopDayDto>, IWorkShopDayService
    {
        public WorkShopDayService(
            IWorkShopDayRepository repository,
            IMapper mapper,
            IValidator<WorkShopDayDto> validator) : base(repository, mapper, validator)
        {
        }
    }
}

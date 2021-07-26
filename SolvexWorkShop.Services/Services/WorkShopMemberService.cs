using AutoMapper;
using FluentValidation;
using SolvexWorkshop.Model.Entities;
using SolvexWorkshop.Model.Repositories;
using SolvexWorkShop.Bl.Dto;

namespace SolvexWorkShop.Services.Services
{
    public interface IWorkShopMemberService : IBaseService<WorkShopMember, WorkShopMemberDto> { }
    public class WorkShopMemberService : BaseService<WorkShopMember, WorkShopMemberDto>, IWorkShopMemberService
    {
        public WorkShopMemberService(
            IWorkShopMemberRepository repository,
            IMapper mapper,
            IValidator<WorkShopMemberDto> validator) : base(repository, mapper, validator)
        {
        }
    }
}

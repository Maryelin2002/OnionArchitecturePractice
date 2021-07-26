using AutoMapper;
using FluentValidation;
using SolvexWorkshop.Model.Entities;
using SolvexWorkshop.Model.Repositories;
using SolvexWorkShop.Bl.Dto;

namespace SolvexWorkShop.Services.Services
{
    public interface IUserService : IBaseService<User, UserDto> { }
    public class UserService : BaseService<User, UserDto>, IUserService
    {
        public UserService(
            IUserRepository repository,
            IMapper mapper,
            IValidator<UserDto> validator) : base(repository, mapper, validator)
        {
        }
    }
}

using SolvexWorkshop.Model.Repositories;
using SolvexWorkShop.Bl.Dto;
using SolvexWorkShop.Bl.Validations;
using SolvexWorkShop.Services.Services;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SolvexWorkShop.Services.Tests
{
    public class UserServiceTests : IClassFixture<ServicesTestsFixture>
    {
        private readonly IUserService _userService;
        private readonly ServicesTestsFixture _fixture;

        public UserServiceTests(ServicesTestsFixture fixture)
        {
            _fixture = fixture;

            IUserRepository repository = new UserRepository(fixture.Context);

            var validator = new UserValidator();

            _userService = new UserService(repository, fixture.Mapper, validator, fixture.Settings);
        }

        [Fact]
        public async Task ShouldSaveUserAsync()
        {
            //Arrange
            var requestDto = new UserDto
            {
                Name = "Emmanuel",
                MiddleName = "Enrique",
                LastName = "Jimenez",
                SecondLastName = "Pimentel",
                Dob = new System.DateTime(1996, 06, 16),
                DocumentType = Core.Enums.DocumentType.ID,
                DocumentTypeValue = "22500851658",
                Gender = Core.Enums.Gender.MALE,
                UserName = "enrique",
                Password = "Hola1234,"
            };

            //Act
            var result = await _userService.AddAsync(requestDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task ShouldGetUserToken()
        {
            //Arrange
            var requestDto = new AuthenticateRequestDto
            {
                UserName = "maryelinram",
                Password = "Hola1234"
            };

            //Act
            var result = await _userService.GetToken(requestDto);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<AuthenticateResponseDto>(result);
            Assert.NotEmpty(result.Token);
            Assert.Equal(_fixture._maryelin.UserName, result.UserName);

        }

        [Fact]
        public async Task ShouldGetAllUsersAsync()
        {
            //Act
            var result = await _userService.GetAllAsync();

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ShouldUpdateUserAsync()
        {
            //Arrange
            var id = 2;

            var requestDto = new UserDto
            {
                Id = 2,
                Name = "Enmanuel",
                MiddleName = "Enrique",
                LastName = "Jimenez",
                SecondLastName = "Pimentel",
                Dob = new System.DateTime(1996, 06, 16),
                DocumentType = Core.Enums.DocumentType.ID,
                DocumentTypeValue = "22500851658",
                Gender = Core.Enums.Gender.MALE,
                UserName = "emma123",
                Password = "Hola1234"
            };

            //Act
            var result = await _userService.UpdateAsync(id, requestDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Equal(requestDto.UserName, result.Entity.UserName);

        }

        [Fact]
        public async Task ShouldDeleteUserAsync()
        {
            //Arrange
            var id = 1;

            //Act
            var result = await _userService.DeleteByIdAsync(id);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.True(result.Entity.Deleted);
        }
    }
}

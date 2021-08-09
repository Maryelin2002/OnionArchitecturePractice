using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Options;
using Moq;
using SolvexWorkshop.Model.Entities;
using SolvexWorkshop.Model.Repositories;
using SolvexWorkShop.Bl.Dto;
using SolvexWorkShop.Bl.Validations;
using SolvexWorkShop.Core.Settings;
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
        private IUserService _userservice;

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
            Assert.Equal(requestDto.Id, result.Entity.Id);

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

        [Theory]
        [InlineData("Hola1234,")]
        public async Task ShouldSaveUserMockAsync(string password)
        {
            #region Arrange
            var dto = new UserDto
            {
                Name = "Emmanuel",
                UserName = "Emma",
                Password = password
            };
            var user = new User
            {
                Name = dto.Name,
                UserName = dto.UserName,
                Password = dto.Password
            };

            var validatorMock = new Mock<IValidator<UserDto>>();
            validatorMock
                .Setup(x => x.Validate(dto))
                .Returns(new FluentValidation.Results.ValidationResult());

            var mapperMock = new Mock<IMapper>();
            mapperMock
                .Setup(x => x.Map<User>(It.IsAny<UserDto>()))
               .Returns(user);

            var repositoryMock = new Mock<IUserRepository>();
            repositoryMock
                .Setup(x => x.Add(It.IsAny<User>()))
                .Callback<User>(x =>
                {
                    user.Id = 1;
                    user.Password = x.Password;
                    user.CreatedDate = System.DateTimeOffset.UtcNow;
                })
                .ReturnsAsync(user);

            mapperMock
                .Setup(x => x.Map(It.IsAny<User>(), It.IsAny<UserDto>()))
                .Callback<User, UserDto>((x, y) =>
                {
                    dto.Id = x.Id;
                    dto.Password = x.Password;
                    dto.CreatedDate = x.CreatedDate;
                })
                .Returns(dto);

            var optionMock = new Mock<IOptions<JwtSettings>>();

            _userservice = new UserService(
                repositoryMock.Object,
                mapperMock.Object,
                validatorMock.Object,
                optionMock.Object
                );

            #endregion

            //Act
            var result = await _userservice.AddAsync(dto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.Equal(result.Entity, dto);
            Assert.Equal(result.Entity.UserName, user.UserName);
            Assert.NotEqual(result.Entity.Password, password);
            Assert.Equal(result.Entity.CreatedDate, user.CreatedDate);
        }

        public async Task ShouldGetUserTokenMock()
        {

        }

        [Fact]
        public async Task ShouldValidationFailed()
        {
            #region Arrange
            var validatorMock = new Mock<IValidator<UserDto>>();
            validatorMock.Setup(x => x.Validate(It.IsAny<UserDto>()))
                .Returns(new UserValidator().Validate(new UserDto()));

            var mapperMock = new Mock<IMapper>();
            var repositoryMock = new Mock<IUserRepository>();
            var optionMock = new Mock<IOptions<JwtSettings>>();

            _userservice = new UserService(
                repositoryMock.Object,
                mapperMock.Object,
                validatorMock.Object,
                optionMock.Object
                );

            #endregion

            //Act
            var result = await _userService.AddAsync(new UserDto());

            //Assert
            Assert.False(result.IsSuccess);
        }
    }
}

using SolvexWorkshop.Model.Repositories;
using SolvexWorkShop.Bl.Dto;
using SolvexWorkShop.Bl.Validations;
using SolvexWorkShop.Services.Services;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SolvexWorkShop.Services.Tests
{
    public class WorkShopMemberServiceTests : IClassFixture<ServicesTestsFixture>
    {
        private readonly IWorkShopMemberService _workShopMemberService;

        public WorkShopMemberServiceTests(ServicesTestsFixture fixture)
        {
            IWorkShopMemberRepository repository = new WorkShopMemberRepository(fixture.Context);

            var validator = new WorkShopMemberValidator();

            _workShopMemberService = new WorkShopMemberService(repository, fixture.Mapper, validator);
        }

        [Fact]
        public async Task ShouldSaveWorkShopMemberAsync()
        {
            //Arrange
            var requestDto = new WorkShopMemberDto
            {
                Role = 0,
                WorkShopId = 1,
                UserId = 2,
            };

            //Act
            var result = await _workShopMemberService.AddAsync(requestDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task ShouldGetAllWorkShopsAsync()
        {
            //Act
            var result = await _workShopMemberService.GetAllAsync();

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ShouldUpdateWorkShopMemberAsync()
        {
            //Arrange
            var id = 1;

            var requestDto = new WorkShopMemberDto
            {
                Id = 1,
                Role = (Core.Enums.WorkShopMemberRole)1,
                WorkShopId = 1,
                UserId = 2,
            };

            //Act
            var result = await _workShopMemberService.UpdateAsync(id, requestDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Equal(requestDto.Id, result.Entity.Id);
        }

        [Fact]
        public async Task ShouldDeleteWorkShopMemberAsync()
        {
            //Arrange
            var id = 1;

            //Act
            var result = await _workShopMemberService.DeleteByIdAsync(id);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.True(result.Entity.Deleted);
        }
    }
}

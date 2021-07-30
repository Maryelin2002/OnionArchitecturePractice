using SolvexWorkshop.Model.Repositories;
using SolvexWorkShop.Bl.Dto;
using SolvexWorkShop.Bl.Validations;
using SolvexWorkShop.Services.Services;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SolvexWorkShop.Services.Tests
{
    public class DocumentServiceTests : IClassFixture<ServicesTestsFixture>
    {
        private readonly IDocumentService _documentService;

        public DocumentServiceTests(ServicesTestsFixture fixture)
        {
            IDocumentRepository repository = new DocumentRepository(fixture.Context);

            var validator = new DocumentValidator();

            _documentService = new DocumentService(repository, fixture.Mapper, validator);
        }

        [Fact]
        public async Task ShouldSaveDocumentAsync()
        {
            //Arrange
            var requestDto = new DocumentDto
            {
                FileName = "Prueba",
                OriginalName = "Prueba",
                ContentType = "Adobe Acrobat Document (.pdf)"
            };

            //Act
            var result = await _documentService.AddAsync(requestDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task ShouldGetAllDocumentsAsync()
        {
            //Act
            var result = await _documentService.GetAllAsync();

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ShouldUpdateDocumentAsync()
        {
            //Arrange
            var id = 1;
            var requestDto = new DocumentDto
            {
                Id = 1,
                FileName = "Prueba",
                OriginalName = "Prueba",
                ContentType = "Adobe Acrobat Document (.pdf)"
            };

            //Act
            var result = await _documentService.UpdateAsync(id, requestDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Equal(requestDto.FileName, result.Entity.FileName);
        }

        [Fact]
        public async Task ShouldDeleteDocumentAsync()
        {
            //Arrange
            var id = 1;

            //Act
            var result = await _documentService.DeleteByIdAsync(id);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.True(result.Entity.Deleted);
        }
    }
}

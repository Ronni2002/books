using Books.Service.Dtos.Books;
using Books.Service.Interfaces.Books;
using Books.Service.Models;

namespace Books.Tests.BooksUnitTests
{
    public class BooksTests
    {
        private readonly IBookService _mock;

        public BooksTests(IBookService service)
        {
            _mock = service;
        }

        [Fact]
        public async Task BookService_GetAllAsync()
        {
            //Arrange
            ;

            PaginationFilter paginationTest = new PaginationFilter()
            {
                PageNumber = 1,
                PageSize = 10,
            };

            //Act
            var result = _mock.GetAllAsync(paginationTest);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task BookService_GetByIdAsync()
        {
            //Arrange

            //Act
            var result = _mock.GetByIdAsync(1);

            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task BookService_AddAsync()
        {
            //Arrange

            var create = new BookDto();

            //Act
            var result = _mock.AddAsync(create);

            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task BookService_UpdateAsync()
        {
            //Arrange

            var update = new BookDto();

            //Act
            var result = await _mock.UpdateAsync(1, update);

            //Assert
            Assert.NotNull(result);
        }
    }
}

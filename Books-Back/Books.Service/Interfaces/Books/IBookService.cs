using Books.Service.Dtos.Books;
using Books.Service.Models;

namespace Books.Service.Interfaces.Books
{
    public interface IBookService
    {
        Task<PagedResponse<List<BookDto>>> GetAllAsync(PaginationFilter filter);
        Task<Response<BookDto>> GetByIdAsync(int id);
        Task<Response<BookDto>> AddAsync(BookDto book);
        Task<Response<BookDto>> UpdateAsync(int id, BookDto book);
        Task<string> DeleteAsync(int id);
    }
}

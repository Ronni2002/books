using Books.Service.Dtos.Books;
using Books.Service.Interfaces.Books;
using Books.Service.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Books.Service.Services.Books
{
    public class BookService : IBookService
    {
        private readonly string _url;
        private readonly HttpClient _http;
        private readonly string controller = "Books";
        public BookService(IOptions<ConnectionProps> settings)
        {
            _url = $"{settings.Value.ConnectionUrl}/{controller}";
            _http = new HttpClient();
        }

        public async Task<PagedResponse<List<BookDto>>> GetAllAsync(PaginationFilter filter)
        {
            HttpResponseMessage response = await _http.GetAsync(_url);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<BookDto>>(responseString)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize).ToList();


            return PagedResponse<List<BookDto>>
                .Create(result, result.Count(), filter.PageNumber, filter.PageSize);
        }

        public async Task<Response<BookDto>> GetByIdAsync(int id)
        {
            HttpResponseMessage response = await _http.GetAsync($"{_url}/{id}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            return Response<BookDto>.Create(JsonConvert.DeserializeObject<BookDto>(responseString));
        }

        public async Task<Response<BookDto>> AddAsync(BookDto book)
        {
            var payload = JsonConvert.SerializeObject(book); ;

            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _http.PostAsync(_url, content);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return Response<BookDto>.Create(JsonConvert.DeserializeObject<BookDto>(responseString));
        }

        public async Task<Response<BookDto>> UpdateAsync(int id, BookDto book)
        {
            var payload = JsonConvert.SerializeObject(book); ;

            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _http.PutAsync($"{_url}/{id}", content);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            return Response<BookDto>.Create(JsonConvert.DeserializeObject<BookDto>(responseString));
        }

        public async Task<string> DeleteAsync(int id)
        {
            HttpResponseMessage response = await _http.DeleteAsync($"{_url}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}

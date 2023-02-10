using Books.Service.Interfaces.Books;
using Books.Service.Services.Books;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Books.Service
{
    public static class IoC
    {
        public static IServiceCollection AddService(this IServiceCollection service, IConfiguration configuration)
        {
            return service.AddScoped<IBookService, BookService>();
        }
    }
}

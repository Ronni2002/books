using Books.Service.Dtos.Books;
using Books.Service.Interfaces.Books;
using Books.Service.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Books.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            return Ok(await _service.GetAllAsync(filter));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] BookDto update)
        {
            try
            {
                await _service.UpdateAsync(id, update);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

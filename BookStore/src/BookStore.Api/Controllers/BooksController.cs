using System.Threading.Tasks;
using BookStore.BL;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        protected readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        // GET: api/books
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await _service.Get();
            return Ok(model);
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _service.Get(id);
            if (model != null)
                return Ok(model);
            return NotFound();
        }

        // GET api/books/options
        [HttpGet("options")]
        public async Task<IActionResult> Options()
        {
            var model = await _service.Options();
            if (model != null)
                return Ok(model);
            return NotFound();
        }

        // POST api/books
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Create(model);
                return Created($"{Request.GetDisplayUrl()}/{result.Id}", result);
            }
            return BadRequest(model);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Update(model);
                if (result)
                    return NoContent();
                return NotFound();
            }
            return BadRequest(model);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (result)
                return NoContent();
            return NotFound();
        }
    }
}

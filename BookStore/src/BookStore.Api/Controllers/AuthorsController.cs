using BookStore.BL;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Controllers
{
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorsController(IAuthorService service)
        {
            _service = service;
        }

        // GET: api/authors
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.Get());

        // GET api/authors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _service.Get(id);
            return model != null ? Ok(model) as IActionResult : NotFound();
        }

        // GET api/authors/options
        [HttpGet("options")]
        public async Task<IActionResult> Options()
        {
            var model = await _service.Options();
            return model.Any() ? Ok(model) as IActionResult : NotFound();
        }

        // POST api/authors
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AuthorViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(model);

            var result = await _service.Create(model);
            return Created($"{Request.GetDisplayUrl()}/{result.Id}", result);
        }

        // PUT api/authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]AuthorViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(model);

            var result = await _service.Update(model);
            return result ? NoContent() as IActionResult : NotFound();
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => await _service.Delete(id) ? NoContent() as IActionResult : NotFound();
    }
}

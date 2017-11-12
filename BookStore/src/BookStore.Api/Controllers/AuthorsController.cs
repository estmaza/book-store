using BookStore.BL;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public IActionResult Get() => Ok(_service.Get());

        // GET api/authors/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = _service.Get(id);
            return model != null ? Ok(model) as IActionResult : NotFound();
        }

        // GET api/authors/options
        [HttpGet("options")]
        public IActionResult Options()
        {
            var model = _service.Options();
            return model.Any() ? Ok(model) as IActionResult : NotFound();
        }

        // POST api/authors
        [HttpPost]
        public IActionResult Post([FromBody]AuthorViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(model);
            
            var result = _service.Create(model);    
            return Created($"{Request.GetDisplayUrl()}/{result.Id}", result);
        }

        // PUT api/authors/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AuthorViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(model);
            
            var result = _service.Update(model);
            return result ? NoContent() as IActionResult : NotFound();
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => _service.Delete(id) ? NoContent() as IActionResult : NotFound();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using BookStore.BL;
using BookStore.ViewModels;

namespace BookStore.Api.Controllers
{
    [Route("api/authors")]
    public class AuthorsController : BaseController
    {
        protected readonly IAuthorService _service;

        public AuthorsController(IAuthorService service)
        {
            _service = service;
        }

        // GET: api/authors
        [HttpGet]
        public IActionResult Get()
        {
            var model = _service.Get();
            return Ok(model);
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = _service.Get(id);
            if (model != null)
                return Ok(model);
            return NotFound();
        }

        // GET api/authors/options
        [HttpGet("options")]
        public IActionResult Options()
        {
            var model = _service.Options();
            if (model != null)
                //return Ok(new { Options = model });
                return Ok(model);
            return NotFound();
        }

        // POST api/authors
        [HttpPost]
        public IActionResult Post([FromBody]AuthorViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var result = _service.Create(model);
                
                return Created($"{Request.GetDisplayUrl()}/{result.Id}", result);
            }
            return BadRequest(model);
        }

        // PUT api/authors/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AuthorViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var result = _service.Update(model);
                if (result)
                    return NoContent();
                return NotFound();
            }
            return BadRequest(model);
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            if (result)
                return NoContent();
            return NotFound();
        }
    }
}

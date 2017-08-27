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
    [Route("api/books")]
    public class BooksController : BaseController
    {
        protected readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        // GET: api/books
        [HttpGet]
        public IActionResult Get()
        {
            var model = _service.Get();
            return Ok(model);
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = _service.Get(id);
            if (model != null)
                return Ok(model);
            return NotFound();
        }

        // GET api/books/options
        [HttpGet("options")]
        public IActionResult Options()
        {
            var model = _service.Options();
            if (model != null)
                //return Ok(new { Options = model });
                return Ok(model);
            return NotFound();
        }

        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody]BookViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var result = _service.Create(model);
                return Created($"{Request.GetDisplayUrl()}/{result.Id}", result);
            }
            return BadRequest(model);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]BookViewModel model)
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

        // DELETE api/books/5
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

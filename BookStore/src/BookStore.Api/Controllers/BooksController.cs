using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public JsonResult Get()
        {
            return JsonData(true, _service.Get());
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return JsonData(true, _service.Get(id));
        }

        // POST api/books
        [HttpPost]
        public void Post([FromBody]BookViewModel model)
        {
            if (ModelState.IsValid) 
            {
                _service.Create(model);
            }
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]BookViewModel model)
        {
            if (ModelState.IsValid) 
            {
                _service.Update(model);
            }
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}

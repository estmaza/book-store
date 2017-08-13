using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public JsonResult Get()
        {
            return JsonData(true, _service.Get());
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return JsonData(true, _service.Get(id));
        }

        // POST api/authors
        [HttpPost]
        public JsonResult Post([FromBody]AuthorViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var id = _service.Create(model);
                return JsonData(true, new { Id = id });
            }
            return JsonData(false, model, "Invalid model state.");
        }

        // PUT api/authors/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]AuthorViewModel model)
        {
            if (ModelState.IsValid) 
            {
                _service.Update(model);
            }
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}

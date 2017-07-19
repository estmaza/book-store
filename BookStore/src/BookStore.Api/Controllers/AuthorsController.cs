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
        public IEnumerable<AuthorViewModel> Get()
        {
            return _service.Get();
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public AuthorViewModel Get(int id)
        {
            return _service.Get(id);
        }

        // POST api/authors
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/authors/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

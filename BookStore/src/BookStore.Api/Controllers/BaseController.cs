using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected JsonResult JsonData(bool isSuccess, object data, string message = null)
        {
            var result = Json(new
            {
                IsSuccess = isSuccess,
                Message = message,
                Data = data
            });

            return result;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using NetCoreProject.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreProject.Controllers
{
    public class DummyController : Controller
    {
        private CityInfoContext _ctx;

        public DummyController(CityInfoContext ctx)
        {
            _ctx = ctx;
        }


        [HttpGet]
        [Route("api/testDatabase")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}

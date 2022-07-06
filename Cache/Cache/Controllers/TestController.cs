using Microsoft.AspNetCore.Mvc;

namespace Cache.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        [HttpGet(Name = "GetInteger")]
        public int Get()
        {
            var result = CacheModel.Get("testId");
            CacheModel.Delete("testId");
            result = CacheModel.Get("testId");
            return result;

        }
    }
}

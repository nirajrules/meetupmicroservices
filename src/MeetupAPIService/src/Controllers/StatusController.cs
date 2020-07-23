using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MeetupAPIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        [HttpGet()]
        public string GetStatus(string URL)
        { 
            return "OK";
        }
    }
}

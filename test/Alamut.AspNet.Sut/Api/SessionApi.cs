using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alamut.AspNet.Sut.Api
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class SessionApi : ControllerBase
    {
        private readonly ISession _session;
        public SessionApi(ISession session)
        {
            this._session = session;
        }

        [HttpGet]
        public object TestSession()
        {
            return Content(_session.GetString("test"));
            //  return Content("test watch");
        }
    }


}
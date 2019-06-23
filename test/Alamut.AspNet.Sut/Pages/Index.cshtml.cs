using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alamut.Utilities.AspNet.Sut.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISession _session;
        public IndexModel(ISession session)
        {
            _session = session;
        }

        public void OnGet()
        {
            _session.SetString("test","IndexModel set session");
        }
    }
}

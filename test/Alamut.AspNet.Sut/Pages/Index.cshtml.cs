using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Alamut.AspNet.Sut.Models;

namespace Alamut.AspNet.Sut.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISession _session;
        private readonly Foo _foo;
        public IndexModel(ISession session, Foo foo)
        {
            this._foo = foo;
            _session = session;
        }

        public void OnGet()
        {
            
            _session.SetString("test", "IndexModel set session to " + _foo.Bar);
        }
    }
}

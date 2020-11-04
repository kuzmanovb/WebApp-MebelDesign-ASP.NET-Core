using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MebelDesign71.Web.Controllers
{
    public class ServicesController : BaseController
    {

        public IActionResult ServiceIndex()
        {

            return this.View();

        }
    }
}

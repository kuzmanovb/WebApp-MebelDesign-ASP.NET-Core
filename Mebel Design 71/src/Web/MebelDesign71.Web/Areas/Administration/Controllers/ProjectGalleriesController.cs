using MebelDesign71.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    public class ProjectGalleriesController : BaseController
    {

        public IActionResult Index()
        {

            return this.View();
        }
    }
}

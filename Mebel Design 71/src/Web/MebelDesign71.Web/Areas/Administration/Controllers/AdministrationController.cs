namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using MebelDesign71.Common;
    using MebelDesign71.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}

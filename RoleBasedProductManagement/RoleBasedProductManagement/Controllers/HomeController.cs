using Microsoft.AspNetCore.Mvc;

namespace RoleBasedProductManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View(); // Points to Views/Shared/AccessDenied.cshtml
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Sample.AspNetCore.Controllers;

public class TermsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
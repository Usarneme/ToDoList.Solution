using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
  public class HomeController : Controller
  {

    [Route("/")]
    public ActionResult Index() { return View(); }

  }
}

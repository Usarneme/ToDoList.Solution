using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/hello")]
    public string Hello() { return "Hello friend!"; }

    [Route("/goodbye")]
    public ActionResult GoodBye() { return View(); }

    // [Route("/")]
    // public string Letter() { return "Our virtual To Do List will go here soon!"; }

    [Route("/")]
    public ActionResult Index() { return View(); }

  }
}

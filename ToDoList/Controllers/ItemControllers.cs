using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
  public class ItemController : Controller
  {

    [Route("/items")]
    public ActionResult Index()
    {
      // contact the model and get all the current items in the todo list
      return View();
    }

  }

}

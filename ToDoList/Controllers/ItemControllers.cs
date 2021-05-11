using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class ItemController : Controller
  {

    [HttpGet("/items")]
    public ActionResult Index()
    {
      // contact the model and get all the current items in the todo list
      List<ToDoList.Models.Item> allTodos = ToDoList.Models.Item.GetAll();
      return View(allTodos);
    }

    [HttpPost("/items")]
    public ActionResult HandleNewToDo(string new_item)
    {
      // call our model to create the new todo item
      Item newItem = new Item(new_item);
      // the Item model then saves it to _instances
      // redirect back to get the items page
      return RedirectToAction("Index");

    }

  }

}

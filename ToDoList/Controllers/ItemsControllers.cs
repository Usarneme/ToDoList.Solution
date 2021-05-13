// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
// using ToDoList.Models;

// namespace ToDoList.Controllers
// {
//   public class ItemController : Controller
//   {

//     [HttpGet("/items")]
//     public ActionResult Index()
//     {
//       // contact the model and get all the current items in the todo list
//       List<Item> allTodos = Item.GetAll();
//       return View(allTodos);
//     }

//     [HttpPost("/items")]
//     public ActionResult HandleNewToDo(string new_item)
//     {
//       // call our model to create the new todo item
//       Item newItem = new Item(new_item);
//       // the Item model then saves it to _instances
//       // redirect back to get the items page
//       return RedirectToAction("Index");

//     }

//     [HttpPost("/items/delete/{description}")]
//     public ActionResult DeleteTodo(string description)
//     {
//       // first find the item, and delete from the items list
//       Item.DeleteOne(description);
//       return RedirectToAction("Index");
//     }

//   }

// }


using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    [HttpGet("/categories/{categoryId}/items/{itemId}")]
    public ActionResult Show(int categoryId, int itemId)
    {
      Item item = Item.Find(itemId);
      Category category = Category.Find(categoryId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("item", item);
      model.Add("category", category);
      return View(model);
    }

    [HttpGet("/categories/{categoryId}/items/new")]
    public ActionResult New(int categoryId)
    {
      Category category = Category.Find(categoryId);
      return View(category);
    }

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
      Item.ClearAll();
      return View();
    }
  }
}

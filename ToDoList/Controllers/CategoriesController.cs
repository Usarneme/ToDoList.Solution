using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {

    private readonly ToDoListContext _db;

    public CategoriesController(ToDoListContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Category> model = _db.Categories.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {
      _db.Categories.Add(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("categories/details/{id}")]
    public ActionResult Details(int id)
    {
      // Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      // IEnumerable<Item> theseItems = _db.Items.Where(item => item.CategoryId == id);
      // Dictionary<string, object> myModels = new Dictionary<string, object>();
      // myModels.Add("items", theseItems);
      // myModels.Add("category", thisCategory);
      // return View(myModels);
      var thisCategory = _db.Categories
        .Include(category => category.JoinEntities)
        .ThenInclude(join => join.Item)
        .FirstOrDefault(Category => Category.CategoryId == id);
      return View(thisCategory);
    }

    public ActionResult Edit(int id)
    {
      var thisItem = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisItem);
    }

    [HttpPost]
    public ActionResult Edit(Category category)
    {
      _db.Entry(category).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      _db.Categories.Remove(thisCategory);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}

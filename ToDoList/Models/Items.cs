using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    private static List<Item> _instances = new List<Item> { };

    public Item(string description)
    {
      Description = description;
      _instances.Add(this);
    }

    public static List<Item> GetAll()

    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static void DeleteOne(string description)
    {
      _instances.RemoveAll(todo => todo.Description == description);
    }

  }
}
    // - must be declared static because it returns a static variable (_instances)
    // - variables & methods *dealing with entire classes* must be static
    // - whenever we use static data, we *need to create a Dispose() method* to clean up between tests
    // https://www.learnhowtoprogram.com/c-and-net/test-driven-development-with-c/adding-a-disposable-method-to-tests
// properties, methods, etc. will go here.
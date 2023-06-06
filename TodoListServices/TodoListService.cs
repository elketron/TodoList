using TodoListData.Models;

namespace TodoListServices.Services;

public class TodoListService
{
    private readonly TodoListContext _context;

    public TodoListService(TodoListContext context)
    {
        _context = context;
    }

    public List<TodoItem> GetAll()
    {
        return _context.items.ToList();
    }

    public TodoItem? GetById(Guid id)
    {
        return _context.items.FirstOrDefault(t => t.Id == id);
    }

    public bool Delete(Guid id)
    {
        var item = GetById(id);

        if (item != null)
        {
            _context.items.Remove(item);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public bool Update(TodoItem item)
    {
        var context_item = GetById(item.Id);

        if (item != null)
        {
            context_item = item;
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public void Add(TodoItem item)
    {
        _context.items.Add(item);
        _context.SaveChanges();
    }
}

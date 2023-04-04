using Microsoft.EntityFrameworkCore;

namespace TodoListData.Models;

public class TodoListContext : DbContext
{
    public TodoListContext(DbContextOptions options) : base(options) { }

    public DbSet<TodoItem> items { get; set; }
}

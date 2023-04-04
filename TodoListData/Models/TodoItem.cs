using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListData.Models;

public class TodoItem
{
    [Key]
    public Guid Id { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string Title { get; set; }
    public bool Done { get; set; }
    public DateTime EndDate { get; set; }
}

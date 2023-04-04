using TodoListServices.Services;
using TodoListData.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/todolist")]
[ApiController]
class TodoListController : ControllerBase
{
    private readonly TodoListService _service;

    public TodoListController(TodoListService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult GetById(Guid id)
    {
        var item = _service.GetById(id);

        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [HttpPost]
    public ActionResult Add(TodoItem item)
    {
        _service.Add(item);

        return CreatedAtAction(nameof(GetById), new { id = item.Id }, null);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        if (_service.Delete(id))
        {
            return Ok();
        }

        return NotFound();
    }
}

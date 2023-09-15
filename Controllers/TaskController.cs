using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace firstApiNet.Controllers;

[ApiController]
[Route("api/task")]
public class TaskController: ControllerBase
{
    ITaskService taskService;
    public TaskController(ITaskService service)
    {
        taskService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(taskService.Get());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TaskInserted task)
    {   
        await taskService.Save(task);
        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(Guid id, TaskInserted task)
    {
        await taskService.Update(id,task);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await taskService.Delete(id);
        return Ok();
    }
}
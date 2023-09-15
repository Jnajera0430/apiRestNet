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
    public async Task<IActionResult> Post([FromBody] ITaskInserted task)
    {   
        await taskService.Save((TaskInserted) task);
        return Ok();
    }
}
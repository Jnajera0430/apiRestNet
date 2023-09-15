using Microsoft.AspNetCore.Mvc;

namespace firstApiNet.Controllers;

[ApiController]
[Route("helloWorld")]
public class HelloWorld: ControllerBase
{
    private readonly ILogger<HelloWorld> logger;
    private readonly IHelloWordService HelloWorldService;

    public HelloWorld(IHelloWordService helloWorldService, ILogger<HelloWorld> paramlogger)
    {
        logger = paramlogger;
        HelloWorldService = helloWorldService;
    }

    [HttpGet]
    public IActionResult Get()
    {   
        logger.LogInformation("Listo esta implementado.");
        return Ok(HelloWorldService.GetHelloWorld());
    }
}
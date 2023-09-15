using Microsoft.AspNetCore.Mvc;

namespace firstApiNet.Controllers;

[ApiController]
[Route("helloWorld")]
public class HelloWorld : ControllerBase
{
    private readonly ILogger<HelloWorld> logger;
    private readonly IHelloWordService HelloWorldService;
    private readonly ApplicationDbContext dbContext;
    public HelloWorld(IHelloWordService helloWorldService, ILogger<HelloWorld> paramlogger,
         ApplicationDbContext db)
    {
        logger = paramlogger;
        HelloWorldService = helloWorldService;
        dbContext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        logger.LogInformation("Listo esta implementado.");
        return Ok(HelloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createDb")]
    public IActionResult CreateDatabase()
    {
        dbContext.Database.EnsureCreated();
        return Ok();
    }
}
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace firstApiNet.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController: ControllerBase
{
    ICategoryService categoryService;
    public CategoryController(ICategoryService service)
    {
        categoryService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoryService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] ICategory categoria){
        if(categoria is null)
        {
            throw new ArgumentNullException(nameof(categoria));
        }
        categoryService.Save((Categoria) categoria);
        return Ok();
        
    }

    [HttpPatch("{id}")]
    public IActionResult Put(Guid id,[FromBody] Categoria categoria){
        if(categoria is null)
        {
            throw new ArgumentNullException(nameof(categoria));
        }
        categoryService.Update(id,categoria);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id){
        if(id.ToString() is null)
        {
            throw new ArgumentNullException(nameof(id));
        }
        categoryService.Delete(id);
        return Ok();
    }
}
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
    public async Task<IActionResult> Post([FromBody] Categoria categoria){
        await categoryService.Save(categoria);
        return Ok();   
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(Guid id,[FromBody] Categoria categoria){
        if(id.ToString() is null)
        {
            throw new ArgumentNullException(nameof(id));
        }
        await categoryService.Update(id,categoria);
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
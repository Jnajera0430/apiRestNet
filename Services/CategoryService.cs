using webapi.Models;
namespace webapi.Services;

public class CategoryService: ICategoryService
{
    ApplicationDbContext appContext;

    public CategoryService(ApplicationDbContext paramAppContext){
        appContext = paramAppContext;
    }

    public IEnumerable<Categoria> Get()
    {
        return appContext.Categorys;
    }

    public async Task Save(Categoria categoria){
        appContext.Add(categoria);
        await appContext.SaveChangesAsync();
    }

    public async Task Update(Guid id,Categoria category){
        var categoryFound = appContext.Categorys.Find(id);
        if(categoryFound != null){
            categoryFound.Name = category.Name;
            categoryFound.Description = category.Description;
            categoryFound.Weight = category.Weight;
            await appContext.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id){
        var categoryFound = appContext.Categorys.Find(id);
        if(categoryFound != null){
            appContext.Categorys.Remove(categoryFound);
            await appContext.SaveChangesAsync();
        }
    }
}

public interface ICategoryService
{
    public IEnumerable<Categoria> Get();
    public Task Save(Categoria categoria);
    public Task Update(Guid id,Categoria category);
    public Task Delete(Guid id);
}
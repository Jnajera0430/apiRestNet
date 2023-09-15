using webapi.Models;
namespace webapi.Services;
public class TaskService: ITaskService
{
    ApplicationDbContext appContext;
    public TaskService(ApplicationDbContext paramAppContext){
        appContext = paramAppContext;
    }

    public IEnumerable<TaskInserted> Get()
    {
        return appContext.Tasks;
    }
    public async Task Save(TaskInserted task){
        appContext.Add(task);
        await appContext.SaveChangesAsync();
    }
    public async Task Update(Guid id,TaskInserted task){
        var taskFound = appContext.Tasks.Find(id);
        if(taskFound != null){
            taskFound.Title = task.Title;
            taskFound.Description = task.Description;
            taskFound.PriorityTask = task.PriorityTask;
            taskFound.IdCategory = task.IdCategory;
            await appContext.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id){
        var taskFound = appContext.Tasks.Find(id);
        if(taskFound != null){
            appContext.Tasks.Remove(taskFound);
            await appContext.SaveChangesAsync();
        }
    }
}

public interface ITaskService{
    public IEnumerable<TaskInserted> Get();
    public Task Save(TaskInserted task);
    public Task Update(Guid id,TaskInserted task);
    public Task Delete(Guid id);
}
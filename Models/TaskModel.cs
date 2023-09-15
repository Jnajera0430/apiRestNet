using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapi.Models;

public class TaskInserted : AbstractModel,ITaskInserted
{
    public Guid IdCategory { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Priority PriorityTask { get; set; }

    public virtual Categoria Category { get; set; }

    public string Resumen { get; set; }
}

public enum Priority{
    Baja,
    media,
    alta
}

public interface ITaskInserted
{
    public Guid IdCategory { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Priority PriorityTask { get; set; }

    public Categoria Category { get; set; }

    public string Resumen { get; set; }
}
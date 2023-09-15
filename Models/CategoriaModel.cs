using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapi.Models;

public class Categoria : AbstractModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int Weight { get; set; } = 0;

    [JsonIgnore]
    public virtual ICollection<TaskInserted>? tasks { get; set; }
}

public interface ICategory
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    public ICollection<TaskInserted> tasks { get; set; }
}
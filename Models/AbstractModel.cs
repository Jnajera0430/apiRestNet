using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapi.Models;

public class AbstractModel
{

    public Guid id { get; set; }

    public DateTime createdAt { get; set; } = DateTime.UtcNow;
}
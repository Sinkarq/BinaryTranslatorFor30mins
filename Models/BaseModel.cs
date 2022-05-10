using System.ComponentModel.DataAnnotations;

namespace BinaryTranslator.Models;

public class BaseModel
{
    [Required]
    public string Data { get; set; }
}
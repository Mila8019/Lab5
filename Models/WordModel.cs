using System.ComponentModel.DataAnnotations;

namespace Lab5.Models;

public sealed class WordModel
{
    [Key]
    public int Id { get; set; }
    public string Word { get; set; }
    public string Construction { get; set; }
    public string Root { get; set; }
    
}
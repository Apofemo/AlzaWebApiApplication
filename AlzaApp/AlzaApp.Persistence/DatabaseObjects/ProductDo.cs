using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlzaApp.Persistence.DatabaseObjects;

[Table("Products")]
internal sealed record ProductDo()
{
    [Key]
    public required int Id { get; init; }
    
    [Required]
    public required string Name { get; init; }
    
    [Required]
    public required string ImgUri { get; init; }
    
    [Required]
    public required decimal Price { get; init; }
    
    public string Description { get; init; } = string.Empty;
}
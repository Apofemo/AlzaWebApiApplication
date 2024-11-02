using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlzaApp.Persistence.DatabaseObjects;

[Table("Products")]
internal sealed class ProductDo
{
    [Key]
    public required int Id { get; init; }
    
    [Required]
    [StringLength(200)]
    public required string Name { get; set; }
    
    [Required]
    [StringLength(500)]
    public required string ImgUri { get; set; }
    
    [Required]
    public required decimal Price { get; set; } 
    
    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Required] 
    public DateTimeOffset CreatedAt { get; init; }
    
    public DateTimeOffset UpdatedAt { get; set; }
}
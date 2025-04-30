using System;
using System.ComponentModel.DataAnnotations;
public class CreateBookDto
{
    [Required]
    [StringLength(255)]
    public required string Title { get; set; }
    [Required]
    [StringLength(255)]
    public required string Author { get; set; }
    public DateTime PublishedDate { get; set; }
    [StringLength(20)]
    public string? ISBN { get; set; }
    public int CategoryId { get; set; }
    public string? CoverImagePath { get; set; } 
}

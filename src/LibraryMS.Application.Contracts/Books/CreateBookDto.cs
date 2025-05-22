using System;
using System.Collections.Generic;
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

    public string? CoverImagePath { get; set; }

    public List<int> CategoryIds { get; set; } = new();
}

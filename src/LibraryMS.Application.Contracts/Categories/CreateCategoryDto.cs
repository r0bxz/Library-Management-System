using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

public class CreateCategoryDto
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [StringLength(255)]
    public string Description { get; set; }

    public List<int> BookIds { get; set; } = new();
}

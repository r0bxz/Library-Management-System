using System.Collections.Generic;
using System;
using Volo.Abp.Application.Dtos;

public class BookDto : FullAuditedEntityDto<int>
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public DateTime PublishedDate { get; set; }
    public string? ISBN { get; set; }
    public string? CoverImagePath { get; set; }
    public List<int> CategoryIds { get; set; } = new();

}

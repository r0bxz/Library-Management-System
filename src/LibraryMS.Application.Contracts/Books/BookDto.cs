using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;
public class BookDto : FullAuditedEntityDto<int>
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public DateTime PublishedDate { get; set; }
    public string? ISBN { get; set; }
    public string? CoverImagePath { get; set; }
    public int CategoryId { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

public class CategoryDto : FullAuditedEntityDto<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}

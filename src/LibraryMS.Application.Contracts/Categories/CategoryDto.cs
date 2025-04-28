using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;


public class CategoryDto : EntityDto<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}

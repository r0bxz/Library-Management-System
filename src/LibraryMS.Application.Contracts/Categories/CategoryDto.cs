using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

public class CategoryDto : FullAuditedEntityDto<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<int> BookIds { get; set; } = new();

}

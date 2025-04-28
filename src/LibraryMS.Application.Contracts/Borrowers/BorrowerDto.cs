using Volo.Abp.Application.Dtos;


public class BorrowerDto: EntityDto<int>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

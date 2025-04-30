using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

public class ReturnBorrowedBookDto : EntityDto<int>
{
    [Required]
    public int Id { get; set; }
    public DateTime ReturnDate { get; set; }
}

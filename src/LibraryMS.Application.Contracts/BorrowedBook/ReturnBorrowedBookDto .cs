using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

public class ReturnBorrowedBookDto : EntityDto<int>
{
    [Required]
    public DateTime ReturnDate { get; set; }
}

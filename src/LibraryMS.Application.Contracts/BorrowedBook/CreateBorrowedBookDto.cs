using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
public class CreateBorrowedBookDto
{
    [Required]
    public int BookId { get; set; }
    [Required]
    public int BorrowerId { get; set; }
    [Required]
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned { get; set; }
}


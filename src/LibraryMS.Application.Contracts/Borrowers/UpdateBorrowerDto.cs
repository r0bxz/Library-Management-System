using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
public class UpdateBorrowerDto : CreateBorrowerDto
{
    public int Id { get; set; }

}
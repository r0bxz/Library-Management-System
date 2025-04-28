using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;


public class UpdateBookDto : CreateBookDto
{
	public int Id { get; set; }
}
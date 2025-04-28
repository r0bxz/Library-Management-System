using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;


public class UpdateCategoryDto: CreateCategoryDto
{
    public int Id { get; set; }
}
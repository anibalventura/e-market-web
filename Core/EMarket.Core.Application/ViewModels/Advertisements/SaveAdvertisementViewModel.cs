﻿using Microsoft.AspNetCore.Http;
using EMarket.Core.Application.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMarket.Core.Application.ViewModels.Advertisements
{
	public class SaveAdvertisementViewModel
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter an advertisement name.")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar el precio del producto")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        [DataType(DataType.Text)]
        public string ImageUrl { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter an advertisement category.")]
        public int CategoryId { get; set; }

        public List<CategoryViewModel> Categories { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }

        public int UserId { get; set; }
    }
}

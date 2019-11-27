namespace Sample.AspNetCore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public string ImageUrl { get; set; }
        public string ItemUrl { get; set; }
        public string Type { get; set; }
        public string Class { get; set; }

        [Required(ErrorMessage = "Please provide a number greater than zero!")]
        [Display(Name = "Unit price")]
        [Range(1, Int32.MaxValue)]
        public long Price { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sample.AspNetCore3.Models
{
    public class Cart
    {
        public bool Vat { get; set; }
        public double VatPercentage { get; set; }
        private List<CartLine> cartLineCollection { get; set; } = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = cartLineCollection.FirstOrDefault(p => p.Product.Id == product.Id);

            if (line == null)
            {
                cartLineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }

        }

        public virtual void RemoveItem(Product product, int quantity)
        {
            CartLine line = cartLineCollection.FirstOrDefault(p => p.Product.Id == product.Id);

            if (line == null)
            {
                return;
            }
            else
            {
                if (quantity >= line.Quantity)
                {
                    cartLineCollection.Remove(line);
                    return;
                }
                else line.Quantity -= quantity;
            }
        }

        public virtual long CalculateTotal() => cartLineCollection.Sum(e => e.Quantity * e.Product.Price);

        public virtual void Clear() => cartLineCollection.Clear();
        public virtual IEnumerable<CartLine> CartLines => cartLineCollection;

    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        [Required(ErrorMessage = "Please provide a number greater than zero!")]
        [Display(Name = "Unit quantity")]
        [Range(1, Int32.MaxValue)]
        public int Quantity { get; set; }
    }


}
namespace Sample.AspNetCore3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Cart
    {
        public string PaymentOrderLink { get; set; }
        public bool Vat { get; set; }
        public double VatPercentage { get; set; }
        private List<CartLine> CartLineCollection { get; set; } = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            var line = CartLineCollection.FirstOrDefault(p => p.Product.ProductId == product.ProductId);

            if (line == null)
            {
                CartLineCollection.Add(new CartLine
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
            var line = CartLineCollection.FirstOrDefault(p => p.Product.ProductId == product.ProductId);

            if (line == null)
            {
                return;
            }
            else
            {
                if (quantity >= line.Quantity)
                {
                    CartLineCollection.Remove(line);
                    return;
                }
                else line.Quantity -= quantity;
            }
        }

        public virtual long CalculateTotal() => CartLineCollection.Sum(e => e.Quantity * e.Product.Price);

        public virtual void Clear() => CartLineCollection.Clear();
        public virtual IEnumerable<CartLine> CartLines => CartLineCollection;

        public virtual void Update()
        {

        }

    }

    
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }

        [Required(ErrorMessage = "Please provide a number greater than zero!")]
        [Display(Name = "Unit quantity")]
        [Range(1, Int32.MaxValue)]
        public int Quantity { get; set; }

        public long CalculateTotal() => Quantity * Product.Price;
    }


}
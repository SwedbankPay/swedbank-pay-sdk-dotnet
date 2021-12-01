using System;

using SwedbankPay.Sdk;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace Sample.AspNetCore.Models
{
    public class Cart
    {
        private List<CartLine> CartLineCollection { get; set; } = new List<CartLine>();
        
        [JsonInclude]
        public virtual IEnumerable<CartLine> CartLines
        {
            get => CartLineCollection;
            private set => CartLineCollection = value.ToList();
        }
        public string PaymentOrderLink { get; set; }
        public string PaymentLink { get; set; }
        public bool Vat { get; set; }
        public PaymentInstrument Instrument { get; set; }
        public string ConsumerUiScriptSource { get; set; }
        public string ConsumerProfileRef { get; set; }


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


        public virtual decimal CalculateTotal()
        {
            return CartLineCollection.Sum(e => e.Quantity * e.Product.Price);
        }


        public virtual void Clear()
        {
            CartLineCollection.Clear();
        }


        public virtual void RemoveItem(Product product, int quantity)
        {
            var line = CartLineCollection.FirstOrDefault(p => p.Product.ProductId == product.ProductId);

            if (line != null)
            {
                if (quantity >= line.Quantity)
                {
                    CartLineCollection.Remove(line);
                }
                else
                {
                    line.Quantity -= quantity;
                }
            }
        }


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
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }


        public decimal CalculateTotal()
        {
            return Quantity * Product.Price;
        }
    }
}
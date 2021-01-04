using System.Collections.Generic;
using System.Linq;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class InvoicePaymentCaptureRequestDetailsDto
    {
        public InvoicePaymentCaptureRequestDetailsDto(ICaptureTransaction transaction)
        {
            Amount = transaction.Amount.InLowestMonetaryUnit;
            Description = transaction.Description;
            if( transaction.ItemDescriptions != null && transaction.ItemDescriptions.Any())
            {
                ItemDescriptions = new List<ItemDescriptionDto>();
                foreach (var item in transaction.ItemDescriptions)
                {
                    ItemDescriptions.Add(new ItemDescriptionDto(item));
                }
            }

            if(transaction.OrderItems != null && transaction.OrderItems.Any())
            {
                OrderItems = new List<OrderItemDto>();
                foreach (var item in transaction.OrderItems)
                {
                    OrderItems.Add(new OrderItemDto(item));
                }
            }

            PayeeReference = transaction.PayeeReference;
            TransactionActivity = transaction.TransactionActivity.Value;
            VatAmount = transaction.VatAmount.InLowestMonetaryUnit;

            if (transaction.VatSummary != null && transaction.VatSummary.Any())
            {
                VatSummary = new List<VatSummaryDto>();
                foreach (var item in transaction.VatSummary)
                {
                    VatSummary.Add(new VatSummaryDto(item));
                }
            }
        }

        public long Amount { get; }

        public string Description { get; }

        public List<ItemDescriptionDto> ItemDescriptions { get; set; }

        public List<OrderItemDto> OrderItems { get; }

        public string PayeeReference { get; }

        public string TransactionActivity { get; set; }

        public long VatAmount { get; }

        List<VatSummaryDto> VatSummary { get; set; }
    }
}
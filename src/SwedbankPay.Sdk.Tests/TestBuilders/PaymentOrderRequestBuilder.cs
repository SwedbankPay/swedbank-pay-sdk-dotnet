using SwedbankPay.Sdk.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder.OrderItems;
using SwedbankPay.Sdk.PaymentOrder.Urls;

namespace SwedbankPay.Sdk.Tests.TestBuilders;

public class PaymentOrderRequestBuilder
{
    private Amount? _amount;
    private Currency? _currency;
    private string? _description;
    // private bool _generateRecurrenceToken;
    private Language? _language;
    private Operation? _operation;
    private List<OrderItem>? _orderItems;
    private PayeeInfo? _payeeInfo;
    private Urls? _urls;
    private string? _userAgent;
    private Amount? _vatAmount;
    private string? _implementation;
    

    public PaymentOrderRequest Build()
    {
        var req = new PaymentOrderRequest(_operation!, _currency!, _amount!, _vatAmount!, _description!,
            _userAgent!, _language!, _urls!, _payeeInfo!)
        {
            OrderItems = _orderItems!,
            Implementation = _implementation,
        };

        return req;
    }


    public PaymentOrderRequestBuilder WithAmounts(long longAmount = 30000, long longVatAmount = 7500)
    {
        if (longAmount - longVatAmount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(longVatAmount),
                $"{longVatAmount} cant be greater than {longAmount}");
        }

        _amount = new Amount(longAmount);
        _vatAmount = new Amount(longVatAmount);

        return this;
    }


    public PaymentOrderRequestBuilder WithLanguageCode(string code)
    {
        _language = new Language(code);
        return this;
    }


    // public PaymentOrderRequestBuilder WithMetadata()
    // {
    //     this.metadata = new Metadata
    //     {
    //         ["testvalue"] = 3,
    //         ["testvalue2"] = "test"
    //     };
    //     return this;
    // }


    public PaymentOrderRequestBuilder WithOrderItems()
    {
        _orderItems = new List<OrderItem>
        {
            new("p1", "Product1", OrderItemType.Product, "ProductGroup1", 4, "pcs", new Amount(300), 0,
                new Amount(1200), new Amount(0))
            {
                ItemUrl = "https://example.com/products/123",
                ImageUrl = "https://example.com/products/123.jpg"
            },
            new("p2", "Product2", OrderItemType.Product, "ProductGroup1", 1, "pcs", new Amount(500), 0,
                new Amount(500), new Amount(0))
        };
        _amount = new Amount(_orderItems.Sum(s => s.Amount));
        _vatAmount = new Amount(_orderItems.Sum(s => s.VatAmount));

        return this;
    }
    
    public PaymentOrderRequestBuilder WithTestValues(string payeeId)
    {
        _operation = Operation.Purchase;
        _currency = new Currency("SEK");
        _amount = new Amount(1700);
        _vatAmount = new Amount(0);
        _description = "Test Description";
        _userAgent = "useragent";
        _language = new Language("sv-SE");
        // _implementation = "Checkoutv3";
        _implementation = "PaymentsOnly";
        _urls = new Urls(new List<Uri> { new Uri("https://example.com") },new Uri("https://example.com/payment-completed"),
            new Uri("https://example.com/payment-canceled"), new Uri("https://example.com/payment-callback"));
       
      
        _payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
        return this;
    }
}
using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CurrentPaymentResponseDto
    {
        public string Id { get; set; }
        public string MenuElementName { get; set; }
        public PaymentResponseDto Payment { get; set; }
        public List<HttpOperationDto> Operations { get; set; }

        internal ICurrentPaymentResponse Map()
        {
            var authorizations = new CardPaymentAuthorizationListResponse(Payment.Authorizations.Authorizaiton.Map());
            var payment = new CurrentPaymentResponseObject(Payment.Number,
                                                            Enum.Parse<PaymentInstrument>(Payment.Instrument),
                                                            Payment.Created,
                                                            Payment.Updated,
                                                            Payment.Amount,
                                                            authorizations,
                                                            Payment.Cancellations,
                                                            Payment.Captures,
                                                            Payment.Currency,
                                                            Payment.Description,
                                                            Payment.Intent,
                                                            Payment.Language,
                                                            Payment.Operation,
                                                            Payment.PayeeInfo,
                                                            Payment.PayerReference,
                                                            Payment.PaymentToken,
                                                            Payment.Prices,
                                                            Payment.Reversals,
                                                            Payment.State,
                                                            Payment.Transactions,
                                                            Payment.Urls,
                                                            Payment.UserAgent,
                                                            Payment.Sales);
            return new CurrentPaymentResponse(PaymentOrder, MenuElementName, payment);
        }
    }

    public class PaymentResponseDto
    {
        public string Number { get; set; }
        public string Instrument { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int Amount { get; set; }
        public AuthorizationTransactionResponseDto Authorizations { get; set; }
        public CancellationTransactionResponseDto Cancellations { get; set; }
        public CaptureTransactionResponseDto Captures { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string Intent { get; set; }
        public string Language { get; set; }
        public string Operation { get; set; }
        public PayeeInfoDto PayeeInfo { get; set; }
        public string PayerReference { get; set; }
        public string PaymentToken { get; set; }
        public PricesListResponseDto Prices { get; set; }
        public TransactionListResponseDto Reversals { get; set; }
        public string State { get; set; }
        public TransactionListResponseDto Transactions { get; set; }
        public IdLink Urls { get; set; }
        public string UserAgent { get; set; }
        public TransactionListResponseDto Sales { get; set; }
        public string CorporationId { get; set; }
        public string Id { get; set; }
        public int RemainingReversalAmount { get; set; }
        public IdLink Metadata { get; set; }
    }

    public class CaptureTransactionResponseDto
    {
        public IdLink Id { get; set; }
        public string Payment { get; set; }
        public List<PaymentOrderTransactionDto> Capture { get; set; }
    }

    internal class PaymentAuthorization: IPaymentAuthorization
    {
        private string id;
        private int amount;
        private int vatAmount;
        private string created;
        private string description;
        private string number;
        private string payeeReference;
        private string type;

        public PaymentAuthorization(string id, int amount, int vatAmount, string created, string description, string number, string payeeReference, string type)
        {
            this.id = id;
            this.amount = amount;
            this.vatAmount = vatAmount;
            this.created = created;
            this.description = description;
            this.number = number;
            this.payeeReference = payeeReference;
            this.type = type;
        }

        public string AcquirerStan => throw new NotImplementedException();

        public string AcquirerTerminalId => throw new NotImplementedException();

        public DateTime AcquirerTransactionTime => throw new NotImplementedException();

        public string AcquirerTransactionType => throw new NotImplementedException();

        public string AuthenticationStatus => throw new NotImplementedException();

        public string CardBrand => throw new NotImplementedException();

        public string CardType => throw new NotImplementedException();

        public string CountryCode => throw new NotImplementedException();

        public bool Direct => throw new NotImplementedException();

        public string ExpiryDate => throw new NotImplementedException();

        public string ExternalNonPaymentToken => throw new NotImplementedException();

        public string ExternalSiteId => throw new NotImplementedException();

        public string IssuerAuthorizationApprovalCode => throw new NotImplementedException();

        public string IssuingBank => throw new NotImplementedException();

        public string MaskedPan => throw new NotImplementedException();

        public string NonPaymentToken => throw new NotImplementedException();

        public string PanToken => throw new NotImplementedException();

        public string PaymentToken => throw new NotImplementedException();

        public string RecurrenceToken => throw new NotImplementedException();

        public CardPaymentAuthorizationRequestTransaction Transaction => throw new NotImplementedException();

        public string TransactionInitiator => throw new NotImplementedException();
    }

    public class PaymentOrderTransactionDto
    {
        public string Id { get; set; }
        public string Created { get; set; }
        public string Updated { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string Number { get; set; }
        public int Amount { get; set; }
        public int VatAmount { get; set; }
        public string Description { get; set; }
        public string PayeeReference { get; set; }
    }

    public class CancellationTransactionResponseDto
    {
        public string Payment { get; set; }
        public List<PaymentOrderTransactionDto> Cancellations { get; set; }
    }


    public class AuthorizationTransactionResponseDto
    {
        public string Payment { get; set; }
        public List<PaymentOrderTransactionDto> Authorizaiton { get; set; }
    }

}
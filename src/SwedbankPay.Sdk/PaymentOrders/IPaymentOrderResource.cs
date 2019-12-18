using SwedbankPay.Sdk.Exceptions;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface IPaymentOrderResource
    {
        /// <summary>
        ///     Creates a payment order
        /// </summary>
        /// <param name="paymentOrderRequest"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="CouldNotPlacePaymentOrderException"></exception>
        /// <exception cref="SdkException"></exception>
        /// <returns></returns>
        Task<PaymentOrder> Create(PaymentOrderRequest paymentOrderRequest, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);


        /// <summary>
        ///     Get payment order for the given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="CouldNotFindPaymentException"></exception>
        /// <exception cref="SdkException"></exception>
        /// <returns></returns>
        Task<PaymentOrder> Get(string id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);
    }
}
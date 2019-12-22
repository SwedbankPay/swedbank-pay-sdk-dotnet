#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk
{
    public class ExecuteRequestWrapper<TRequest, TResponse> : ExecuteWrapperBase
    {
        private readonly SwedbankPayHttpClient Client;
        private readonly HttpRequestMessage HttpRequestMessage;


        internal ExecuteRequestWrapper(HttpRequestMessage httpRequestMessage,
                                       SwedbankPayHttpClient swedbankPayHttpClient)
        {
            this.HttpRequestMessage = httpRequestMessage;
            this.Client = swedbankPayHttpClient;
        }


        /// <summary>
        ///     Execute the HttpRequest
        /// </summary>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="SwedbankPay.Sdk.Exceptions.HttpResponseException"></exception>
        /// <returns></returns>
        public async Task<TResponse> Execute(TRequest objRequest)
        {
            UpdateRequest(this.HttpRequestMessage, objRequest);
            return await this.Client.SendHttpRequestAndProcessHttpResponse<TResponse>(this.HttpRequestMessage);
        }
    }
}
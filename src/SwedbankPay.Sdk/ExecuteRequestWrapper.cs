#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using System;
using System.Net.Http;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Exceptions;

namespace SwedbankPay.Sdk
{
    public class ExecuteRequestWrapper<TRequest, TResponse> : ExecuteWrapperBase
        where TResponse : new()
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
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="HttpResponseException"></exception>
        /// <returns></returns>
        public async Task<TResponse> Execute(TRequest objRequest)
        {
            UpdateRequest(this.HttpRequestMessage, objRequest);
            return await this.Client.SendHttpRequestAndProcessHttpResponse<TResponse>(this.HttpRequestMessage);
        }
    }
}
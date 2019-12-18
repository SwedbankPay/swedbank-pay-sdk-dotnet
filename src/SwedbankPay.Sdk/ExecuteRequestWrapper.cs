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

namespace SwedbankPay.Sdk
{
    public class ExecuteRequestWrapper<TRequest, TResponse>
        where TResponse : new()
    {
        private readonly SwedbankPayHttpClient Client;
        private readonly HttpRequestMessage HttpRequestMessage;
        private readonly Func<HttpResponseMessage, ProblemsContainer, Exception> OnError;


        internal ExecuteRequestWrapper(HttpRequestMessage httpRequestMessage,
                                       SwedbankPayHttpClient swedbankPayHttpClient,
                                       Func<HttpResponseMessage, ProblemsContainer, Exception> onError)
        {
            this.HttpRequestMessage = httpRequestMessage;
            this.Client = swedbankPayHttpClient;
            this.OnError = onError;
        }


        public async Task<TResponse> Execute(TRequest objRequest)
        {
            return await this.Client.SendHttpRequestAndProcessHttpResponse<TResponse>(this.HttpRequestMessage, this.OnError, objRequest);
        }
    }
}
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
    public class ExecuteWrapper<TResponse>
        where TResponse : new()
    {
        protected readonly HttpRequestMessage HttpRequestMessage;
        private readonly Func<HttpResponseMessage, ProblemsContainer, Exception> OnError;
        private readonly object Request;


        internal ExecuteWrapper(HttpRequestMessage httpRequestMessage,
                                SwedbankPayHttpClient swedbankPayHttpClient,
                                Func<HttpResponseMessage, ProblemsContainer, Exception> onError,
                                object request = null)
        {
            this.HttpRequestMessage = httpRequestMessage;
            this.OnError = onError;
            Client = swedbankPayHttpClient;
            this.Request = request;
        }


        private SwedbankPayHttpClient Client { get; }


        public async Task<TResponse> Execute()
        {
            return await Client.SendHttpRequestAndProcessHttpResponse<TResponse>(this.HttpRequestMessage, this.OnError, this.Request);
        }
    }
}
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
        private readonly Func<ProblemsContainer, Exception> OnError;


        internal ExecuteRequestWrapper(HttpRequestMessage httpRequestMessage,
                                       SwedbankPayHttpClient swedbankPayHttpClient,
                                       Func<ProblemsContainer, Exception> onError)
        {
            this.HttpRequestMessage = httpRequestMessage;
            this.Client = swedbankPayHttpClient;
            this.OnError = onError;
        }


        public async Task<TResponse> Execute(TRequest objRequest)
        {
            return await this.Client.HttpRequest<TResponse>(this.HttpRequestMessage, this.OnError, objRequest);
        }
    }
}
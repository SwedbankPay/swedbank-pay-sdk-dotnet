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
    public class ExecuteWrapper<TResponse> : ExecuteWrapperBase
    {
        protected readonly HttpRequestMessage HttpRequestMessage;


        internal ExecuteWrapper(HttpRequestMessage httpRequestMessage,
                                SwedbankPayHttpClient swedbankPayHttpClient,
                                object request = null)
        {
            this.HttpRequestMessage = httpRequestMessage;
            Client = swedbankPayHttpClient;
            UpdateRequest(this.HttpRequestMessage, request);
        }


        private SwedbankPayHttpClient Client { get; }


        /// <summary>
        ///     Execute the HttpRequest
        /// </summary>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="SwedbankPay.Sdk.Exceptions.HttpResponseException"></exception>
        /// <returns></returns>
        public async Task<TResponse> Execute()
        {
            return await Client.SendHttpRequestAndProcessHttpResponse<TResponse>(this.HttpRequestMessage);
        }
    }
}
using Microsoft.AspNetCore.Http;

namespace Sample.AspNetCore
{
    using SwedbankPay.Client;

    public class QueryStringSelector : ISelectClient
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public QueryStringSelector(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        
        public string Select()
        {
            var val = "someAccount"; //_contextAccessor.HttpContext.Request.Query["selector"];
            return val;
        }
    }
}
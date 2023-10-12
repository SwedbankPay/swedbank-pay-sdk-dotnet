namespace SwedbankPay.Sdk.Tests.TestHelpers;

public class FakeDelegatingHandler : DelegatingHandler
{
    public List<HttpResponseMessage> FakeResponseList { get; } = new List<HttpResponseMessage>();
    public List<HttpRequestMessage> RequestMessageList { get; } = new List<HttpRequestMessage>();

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        RequestMessageList.Add(request);
        var fakeResponse = FakeResponseList[0];
        FakeResponseList.RemoveAt(0);
        return await Task.FromResult(fakeResponse);
    }
}
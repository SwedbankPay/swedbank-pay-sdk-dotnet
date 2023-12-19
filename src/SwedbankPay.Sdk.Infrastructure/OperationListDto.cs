namespace SwedbankPay.Sdk.Infrastructure;

internal class OperationListDto : List<HttpOperationDto>
{
    public OperationListDto()
    {
    }

    public OperationListDto(IEnumerable<HttpOperationDto> operations)
        : base(operations)
    {
    }

    public override string ToString()
    {
        return string.Join(", ", this.Select(o => o.Rel));
    }

    public IOperationList Map()
    {
        var list = new OperationList();
        foreach (var item in this)
        {
            var rel = new LinkRelation(item.Rel);
            var href = new Uri(item.Href, UriKind.RelativeOrAbsolute);
            list.Add(new HttpOperation(href, rel, item.Method, item.ContentType));
        }

        return list;
    }
}
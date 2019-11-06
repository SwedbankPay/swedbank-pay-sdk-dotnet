using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
    public class Header<TOwner> : Control<TOwner> where TOwner : BasePage<TOwner>
    {
        [FindByContent("")]
        public LinkDelegate<ProductsPage, TOwner> Section1 { get; private set; }

        [FindByContent("")]
        public LinkDelegate<ProductsPage, TOwner> Section2 { get; private set; }

        [FindByContent("")]
        public LinkDelegate<ProductsPage, TOwner> Section3 { get; private set; }
    }
}

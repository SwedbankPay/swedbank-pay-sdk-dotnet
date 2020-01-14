using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
    [WaitForDocumentReadyState]
    public abstract class BasePage<TOwner> : Page<TOwner>
        where TOwner : BasePage<TOwner>
    {
        [FindByClass("")] public Footer<TOwner> Footer { get; private set; }

        [FindByClass("navbar-nav")] public Header<TOwner> Header { get; private set; }

        [FindById("")] public TextInput<TOwner> SearchInput { get; private set; }
    }
}
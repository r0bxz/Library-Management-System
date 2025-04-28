using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace LibraryMS.Pages;

[Collection(LibraryMSTestConsts.CollectionDefinitionName)]
public class Index_Tests : LibraryMSWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}

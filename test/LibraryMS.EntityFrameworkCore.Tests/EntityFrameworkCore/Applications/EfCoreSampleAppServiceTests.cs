using LibraryMS.Samples;
using Xunit;

namespace LibraryMS.EntityFrameworkCore.Applications;

[Collection(LibraryMSTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<LibraryMSEntityFrameworkCoreTestModule>
{

}

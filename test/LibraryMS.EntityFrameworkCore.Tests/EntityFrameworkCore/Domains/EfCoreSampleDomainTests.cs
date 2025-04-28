using LibraryMS.Samples;
using Xunit;

namespace LibraryMS.EntityFrameworkCore.Domains;

[Collection(LibraryMSTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<LibraryMSEntityFrameworkCoreTestModule>
{

}

using Xunit;

namespace LibraryMS.EntityFrameworkCore;

[CollectionDefinition(LibraryMSTestConsts.CollectionDefinitionName)]
public class LibraryMSEntityFrameworkCoreCollection : ICollectionFixture<LibraryMSEntityFrameworkCoreFixture>
{

}

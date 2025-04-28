using Microsoft.AspNetCore.Builder;
using LibraryMS;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("LibraryMS.Web.csproj"); 
await builder.RunAbpModuleAsync<LibraryMSWebTestModule>(applicationName: "LibraryMS.Web");

public partial class Program
{
}

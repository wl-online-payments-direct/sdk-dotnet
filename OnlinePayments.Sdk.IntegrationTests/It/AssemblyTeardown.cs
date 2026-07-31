using NUnit.Framework;

namespace OnlinePayments.Sdk.It;

[SetUpFixture]
public class AssemblyTeardown
{
    [OneTimeTearDown]
    public void OneTimeTearDown() => IntegrationTest.DisposeServiceProvider();
}

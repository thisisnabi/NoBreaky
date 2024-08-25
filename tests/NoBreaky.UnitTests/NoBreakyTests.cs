using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace NoBreaky.UnitTests
{
    public class NoBreakyTests
    {
        [Fact]
        public void App_Should_Have_thisisnabi_Endpoint()
        {
            var client = NoBreaky<Program>.Create();

            client.Endpoint("/thisisnabi")
                  .IsSafe();
        }

    }
}

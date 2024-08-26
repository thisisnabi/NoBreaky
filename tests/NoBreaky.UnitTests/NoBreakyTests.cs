using System.ComponentModel.DataAnnotations;

namespace NoBreaky.UnitTests;

public class NoBreakyTests
{
    public class ContractRequest
    {
        public string Name { get; set; }

        [Required()]
        public int OrderId { get; set; }
    }
     
    public class ContractResponse
    {
        public string Name { get; set; }

        [Required()]
        public int OrderId { get; set; }
    }


    [Fact]
    public void App_Should_Have_thisisnabi_Endpoint()
    {
        var client = NoBreaky<Program>.Create();

        client.Endpoint("/thisisnabi")
              .IsGetMethod()
              .RequestWith(request => {
                  request.WithHeaders(header =>
                  {
                      header.Add<int>("Nabi").IsRequired();
                      header.Add<string>("Diman");
                  });
                  request.WithRoutes(header =>
                  {
                      header.Add<int>("Nile").IsRequired();
                      header.Add<long>("Nick");
                  });
                  request.WithForm(header =>
                  {
                      header.Add<int>("Smko").IsRequired();
                      header.Add<long>("Dlnia");
                  });
                  request.WithQueryString(header =>
                  {
                      header.Add<int>("UserId").IsRequired();
                      header.Add<long>("Clmko");
                  });
                  request.WithBody<ContractRequest>();
              })
              .ResponseOn<ContractResponse>()
              .IsSafe();
    }

}

using FreeMediatR;
using FreeMediatR.DependencyInjection;
using FreeMediatRSample;
using Microsoft.Extensions.DependencyInjection;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var mediator = BuildMediator();

        var testRequest = new TestRequest { Message = "Ping" };

        var testResponse = await mediator.Send(testRequest);
        Console.Write($"Message sent: {testRequest.Message}, handler responded: {TestResponse.Message}");
    }

    private static IMediator BuildMediator()
    {
        var services = new ServiceCollection();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(TestHandler).Assembly);
        });

        var provider = services.BuildServiceProvider();

        return provider.GetRequiredService<IMediator>();
    }
}
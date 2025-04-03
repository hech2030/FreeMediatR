using FreeMediatR;

namespace FreeMediatRSample;

internal class TestHandler : IRequestHandler<TestRequest, TestResponse>
{
    public Task<TestResponse> Handle(TestRequest request, CancellationToken cancellationToken)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Message))
        {
            throw new ArgumentNullException(nameof(request));
        }
        return Task.Run(() => new TestResponse { Message = "Pong" });
    }
}
using FreeMediatR.Contracts;

namespace FreeMediatRSample;

internal class TestRequest : IRequest<TestResponse>
{
    public required string Message { get; set; }
}

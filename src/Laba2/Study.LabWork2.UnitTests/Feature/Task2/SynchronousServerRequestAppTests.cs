using System.Text.Json;
using NUnit.Framework;
using Study.LabWork2.Abstractions.Feature.Task2.DtoModels;
using Study.LabWork2.Feature.Task2;

namespace Study.LabWork2.UnitTests.Feature.Task2;

public sealed class SynchronousServerRequestAppTests {
    [Test]
    public void ExecuteRequests_WithWorkingEndpoints_ReturnsSuccessfulResult() {
        var application = new SynchronousServerRequestApp();

        ServerConfigDto[] servers = {
            new ServerConfigDto { Name = "Post",
                                  Url = "https://jsonplaceholder.typicode.com/posts/4" },
            new ServerConfigDto { Name = "User",
                                  Url = "https://jsonplaceholder.typicode.com/users/2" },
            new ServerConfigDto { Name = "Todo",
                                  Url = "https://jsonplaceholder.typicode.com/todos/7" }
        };

        ExecutionResultDto<JsonElement> result = application.ExecuteRequests<JsonElement>(servers);

        Assert.That(result.Version, Is.EqualTo("Synchronous"));
        Assert.That(result.SuccessfulRequests, Is.EqualTo(3));
        Assert.That(result.FailedRequests, Is.EqualTo(0));
        Assert.That(result.Responses.Count, Is.EqualTo(3));
        Assert.That(result.TotalExecutionTime, Is.GreaterThan(TimeSpan.Zero));
    }

    [Test]
    public void ExecuteRequests_WithBrokenEndpoint_StopsAfterError() {
        var application = new SynchronousServerRequestApp();

        ServerConfigDto[] servers = {
            new ServerConfigDto { Name = "Correct",
                                  Url = "https://jsonplaceholder.typicode.com/posts/4" },
            new ServerConfigDto { Name = "Wrong",
                                  Url = "https://jsonplaceholder.typicode.com/unknown-section" },
            new ServerConfigDto { Name = "Will not be requested",
                                  Url = "https://jsonplaceholder.typicode.com/todos/7" }
        };

        ExecutionResultDto<JsonElement> result = application.ExecuteRequests<JsonElement>(servers);

        Assert.That(result.Version, Is.EqualTo("Synchronous"));
        Assert.That(result.SuccessfulRequests, Is.EqualTo(1));
        Assert.That(result.FailedRequests, Is.EqualTo(1));
        Assert.That(result.Responses.Count, Is.EqualTo(1));
    }

    [Test]
    public void ExecuteRequests_WithEmptyServerArray_ThrowsException() {
        var application = new SynchronousServerRequestApp();

        Assert.Throws<ArgumentException>(
            () => application.ExecuteRequests<JsonElement>(Array.Empty<ServerConfigDto>()));
    }
}

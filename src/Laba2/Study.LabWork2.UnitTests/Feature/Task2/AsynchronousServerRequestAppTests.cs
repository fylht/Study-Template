using System.Text.Json;
using NUnit.Framework;
using Study.LabWork2.Abstractions.Feature.Task2.DtoModels;
using Study.LabWork2.Feature.Task2;

namespace Study.LabWork2.UnitTests.Feature.Task2;

public sealed class AsynchronousServerRequestAppTests {
    [Test]
    public void ExecuteRequests_WithWorkingEndpoints_ReturnsThreeResponses() {
        var application = new AsynchronousServerRequestApp();

        ServerConfigDto[] servers = {
            new ServerConfigDto { Name = "Post",
                                  Url = "https://jsonplaceholder.typicode.com/posts/4" },
            new ServerConfigDto { Name = "User",
                                  Url = "https://jsonplaceholder.typicode.com/users/2" },
            new ServerConfigDto { Name = "Todo",
                                  Url = "https://jsonplaceholder.typicode.com/todos/7" }
        };

        ExecutionResultDto<JsonElement> result = application.ExecuteRequests<JsonElement>(servers);

        Assert.That(result.Version, Is.EqualTo("Asynchronous"));
        Assert.That(result.SuccessfulRequests, Is.EqualTo(3));
        Assert.That(result.FailedRequests, Is.EqualTo(0));
        Assert.That(result.Responses.Count, Is.EqualTo(3));
        Assert.That(result.TotalExecutionTime, Is.GreaterThan(TimeSpan.Zero));
    }

    [Test]
    public void ExecuteRequests_WithOneBrokenEndpoint_CountsFailure() {
        var application = new AsynchronousServerRequestApp();

        ServerConfigDto[] servers = {
            new ServerConfigDto { Name = "Post",
                                  Url = "https://jsonplaceholder.typicode.com/posts/4" },
            new ServerConfigDto {
                Name = "Broken", Url = "https://jsonplaceholder.typicode.com/not-existing-resource"
            },
            new ServerConfigDto { Name = "Todo",
                                  Url = "https://jsonplaceholder.typicode.com/todos/7" }
        };

        ExecutionResultDto<JsonElement> result = application.ExecuteRequests<JsonElement>(servers);

        Assert.That(result.Version, Is.EqualTo("Asynchronous"));
        Assert.That(result.SuccessfulRequests, Is.EqualTo(2));
        Assert.That(result.FailedRequests, Is.EqualTo(1));
        Assert.That(result.Responses.Count, Is.EqualTo(2));
    }

    [Test]
    public void ExecuteRequests_WhenServersAreMissing_ThrowsException() {
        var application = new AsynchronousServerRequestApp();

        Assert.Throws<ArgumentException>(
            () => application.ExecuteRequests<JsonElement>(Array.Empty<ServerConfigDto>()));
    }
}

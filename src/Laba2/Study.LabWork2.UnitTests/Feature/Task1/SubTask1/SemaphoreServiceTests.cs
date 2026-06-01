using NUnit.Framework;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

public sealed class SemaphoreServiceTests {
    [Test]
    public void CountPrimes_ForRangeFromTwoToTwo_ReturnsOne() {
        var service = new SemaphoreService();

        var result = service.CountPrimes(2, 2, 1);

        Assert.That(result.PrimeCount, Is.EqualTo(1));
        Assert.That(result.FoundPrimes, Is.EqualTo(new[] { 2 }));
    }

    [Test]
    public void CountPrimes_ForRangeRequiredByLab_ReturnsCorrectAmount() {
        var service = new SemaphoreService();

        var result = service.CountPrimes(1, 10_000, 4);

        Assert.That(result.PrimeCount, Is.EqualTo(1229));
        Assert.That(result.SynchronizationType, Is.EqualTo("Semaphore"));
    }

    [Test]
    public void CountPrimes_WithNegativeThreadCount_ThrowsException() {
        var service = new SemaphoreService();

        Assert.Throws<ArgumentException>(() => service.CountPrimes(1, 100, -1));
    }
}

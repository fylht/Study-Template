using NUnit.Framework;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

public sealed class MonitorServiceTests {
    [Test]
    public void CountPrimes_ForSmallRange_FindsExpectedNumbers() {
        var service = new MonitorService();

        var result = service.CountPrimes(1, 20, 3);

        Assert.That(result.PrimeCount, Is.EqualTo(8));
        Assert.That(result.FoundPrimes, Is.EqualTo(new[] { 2, 3, 5, 7, 11, 13, 17, 19 }));
    }

    [Test]
    public void CountPrimes_ForOneToTenThousand_ReturnsKnownAmount() {
        var service = new MonitorService();

        var result = service.CountPrimes(1, 10_000, 4);

        Assert.That(result.PrimeCount, Is.EqualTo(1229));
        Assert.That(result.SynchronizationType, Is.EqualTo("Monitor"));
    }

    [Test]
    public void CountPrimes_WithWrongThreadCount_ThrowsException() {
        var service = new MonitorService();

        Assert.Throws<ArgumentException>(() => service.CountPrimes(1, 100, 0));
    }
}

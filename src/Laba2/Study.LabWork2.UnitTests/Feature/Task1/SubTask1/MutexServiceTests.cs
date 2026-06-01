using NUnit.Framework;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

public sealed class MutexServiceTests {
    [Test]
    public void CountPrimes_ForRangeFromOneToTen_ReturnsFour() {
        var service = new MutexService();

        var result = service.CountPrimes(1, 10, 2);

        Assert.That(result.PrimeCount, Is.EqualTo(4));
        Assert.That(result.FoundPrimes, Is.EqualTo(new[] { 2, 3, 5, 7 }));
    }

    [Test]
    public void CountPrimes_ForFullLabRange_Returns1229() {
        var service = new MutexService();

        var result = service.CountPrimes(1, 10_000, 4);

        Assert.That(result.PrimeCount, Is.EqualTo(1229));
        Assert.That(result.SynchronizationType, Is.EqualTo("Mutex"));
    }

    [Test]
    public void CountPrimes_WhenStartGreaterThanEnd_ThrowsException() {
        var service = new MutexService();

        Assert.Throws<ArgumentException>(() => service.CountPrimes(50, 10, 2));
    }
}

using NUnit.Framework;
using Study.LabWork2.Feature.Task1.SubTask2;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask2;

public sealed class NumberSetProcessorTests {
    [Test]
    public void Process_AfterRun_ReturnsFifteenRows() {
        string path = Path.Combine(Path.GetTempPath(), $"packs_{Guid.NewGuid()}.txt");

        var processor = new NumberSetProcessor(3, path);

        processor.Process();

        var result = processor.GetResult();

        Assert.That(result.ProcessedSetsCount, Is.EqualTo(15));
        Assert.That(result.Results.Count, Is.EqualTo(15));
    }

    [Test]
    public void Process_TotalSumMatchesSumOfRows() {
        string path = Path.Combine(Path.GetTempPath(), $"packs_{Guid.NewGuid()}.txt");

        var processor = new NumberSetProcessor(4, path);

        processor.Process();

        var result = processor.GetResult();

        int expected = result.Results.Sum(row => row.Sum);

        Assert.That(result.TotalSum, Is.EqualTo(expected));
    }

    [Test]
    public void Process_CreatesDataFile_WhenFileDoesNotExist() {
        string path = Path.Combine(Path.GetTempPath(), $"packs_{Guid.NewGuid()}.txt");

        var processor = new NumberSetProcessor(2, path);

        processor.Process();

        Assert.That(File.Exists(path), Is.True);
    }
}

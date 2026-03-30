using NUnit.Framework;
using Study.LabWork1.Features.Task1.Services;

namespace Study.LabWork1.UnitTests.Features.Task1;

[TestFixture]
public class Task1
{
    [Test]
    public void Constructor_Should_Create_Model_With_Valid_Values()
    {
        var model = new HSLModel(210, 50, 60);

        Assert.That(model.Hue, Is.EqualTo(210));
        Assert.That(model.Saturation, Is.EqualTo(50));
        Assert.That(model.Lightness, Is.EqualTo(60));
    }

    [Test]
    public void Constructor_Should_Throw_When_Hue_Is_Less_Than_Zero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new HSLModel(-1, 50, 60));
    }

    [Test]
    public void Constructor_Should_Throw_When_Hue_Is_Greater_Than_360()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new HSLModel(361, 50, 60));
    }

    [Test]
    public void Constructor_Should_Throw_When_Saturation_Is_Less_Than_Zero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new HSLModel(210, -1, 60));
    }

    [Test]
    public void Constructor_Should_Throw_When_Saturation_Is_Greater_Than_100()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new HSLModel(210, 101, 60));
    }

    [Test]
    public void Constructor_Should_Throw_When_Lightness_Is_Less_Than_Zero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new HSLModel(210, 50, -1));
    }

    [Test]
    public void Constructor_Should_Throw_When_Lightness_Is_Greater_Than_100()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new HSLModel(210, 50, 101));
    }

    [Test]
    public void ToString_Should_Return_HSL_Format()
    {
        var model = new HSLModel(210, 50, 60);

        Assert.That(model.ToString(), Is.EqualTo("hsl(210, 50%, 60%)"));
    }

    [Test]
    public void ToHex_Should_Return_Correct_Hex_Value()
    {
        var model = new HSLModel(210, 50, 60);

        Assert.That(model.ToHEX(), Is.EqualTo("#6699CC"));
    }

    [Test]
    public void ToRgb_Should_Return_Correct_Values()
    {
        var model = new HSLModel(210, 50, 60);

        var (R, G, B) = model.ToRGB();

        Assert.That(R, Is.EqualTo(102));
        Assert.That(G, Is.EqualTo(153));
        Assert.That(B, Is.EqualTo(204));
    }

    [Test]
    public void Plus_Operator_With_Scalar_Should_Add_Values()
    {
        var model = new HSLModel(100, 20, 30);

        var result = model + 10;

        Assert.That(result.Hue, Is.EqualTo(110));
        Assert.That(result.Saturation, Is.EqualTo(30));
        Assert.That(result.Lightness, Is.EqualTo(40));
    }

    [Test]
    public void Plus_Operator_With_Model_Should_Add_Values()
    {
        var first = new HSLModel(100, 20, 30);
        var second = new HSLModel(10, 5, 15);

        var result = first + second;

        Assert.That(result.Hue, Is.EqualTo(110));
        Assert.That(result.Saturation, Is.EqualTo(25));
        Assert.That(result.Lightness, Is.EqualTo(45));
    }

    [Test]
    public void Minus_Operator_With_Scalar_Should_Subtract_Values()
    {
        var model = new HSLModel(100, 50, 60);

        var result = model - 10;

        Assert.That(result.Hue, Is.EqualTo(90));
        Assert.That(result.Saturation, Is.EqualTo(40));
        Assert.That(result.Lightness, Is.EqualTo(50));
    }

    [Test]
    public void Minus_Operator_With_Model_Should_Subtract_Values()
    {
        var first = new HSLModel(100, 50, 60);
        var second = new HSLModel(10, 5, 15);

        var result = first - second;

        Assert.That(result.Hue, Is.EqualTo(90));
        Assert.That(result.Saturation, Is.EqualTo(45));
        Assert.That(result.Lightness, Is.EqualTo(45));
    }

    [Test]
    public void Multiply_Operator_With_Scalar_Should_Multiply_Values()
    {
        var model = new HSLModel(10, 20, 30);

        var result = model * 2;

        Assert.That(result.Hue, Is.EqualTo(20));
        Assert.That(result.Saturation, Is.EqualTo(40));
        Assert.That(result.Lightness, Is.EqualTo(60));
    }

    [Test]
    public void Multiply_Operator_With_Model_Should_Multiply_Values()
    {
        var first = new HSLModel(10, 2, 3);
        var second = new HSLModel(2, 3, 4);

        var result = first * second;

        Assert.That(result.Hue, Is.EqualTo(20));
        Assert.That(result.Saturation, Is.EqualTo(6));
        Assert.That(result.Lightness, Is.EqualTo(12));
    }

    [Test]
    public void Divide_Operator_With_Scalar_Should_Divide_Values()
    {
        var model = new HSLModel(100, 50, 60);

        var result = model / 2;

        Assert.That(result.Hue, Is.EqualTo(50));
        Assert.That(result.Saturation, Is.EqualTo(25));
        Assert.That(result.Lightness, Is.EqualTo(30));
    }

    [Test]
    public void Equals_Operator_Should_Return_True_For_Equal_Models()
    {
        var first = new HSLModel(210, 50, 60);
        var second = new HSLModel(210, 50, 60);

        Assert.That(first == second, Is.True);
    }

    [Test]
    public void NotEquals_Operator_Should_Return_True_For_Different_Models()
    {
        var first = new HSLModel(210, 50, 60);
        var second = new HSLModel(100, 20, 30);

        Assert.That(first != second, Is.True);
    }
}

using Study.LabWork1.Features.Task1;
using Study.LabWork1.Shared.Abstractions;

namespace Study.LabWork1.Shared.Services;

/// <summary>
/// Реализация заданий Л/Р
/// </summary>
public class RunService : IRunService
{
    /// <summary>
    /// Задание 1
    /// </summary>
    public void RunTask1()
    {
        Console.WriteLine("=== Вариант 7. Множества ===\n");

        var setA = new MySet<int>(new[] { 1, 2, 3, 4 });
        var setB = new MySet<int>(new[] { 3, 4, 5, 6 });

        Console.WriteLine($"Множество A: {setA}");
        Console.WriteLine($"Множество B: {setB}");
        Console.WriteLine();

        var union = setA | setB;
        Console.WriteLine($"A | B (объединение): {union}");

        var intersect = setA & setB;
        Console.WriteLine($"A & B (пересечение): {intersect}");

        var diff = setA - setB;
        Console.WriteLine($"A - B (разность): {diff}");

        var symDiff = setA / setB;
        Console.WriteLine($"A / B (симметричная разность): {symDiff}");
        Console.WriteLine();

        var setC = new MySet<int>(new[] { 4, 3, 2, 1 });
        Console.WriteLine($"Множество C: {setC}");
        Console.WriteLine($"A == C (равны по содержимому): {setA == setC}");
        Console.WriteLine($"A == B: {setA == setB}");
        Console.WriteLine();

        Console.WriteLine("=== Пример со строками ===");
        var words1 = new MySet<string>(new[] { "яблоко", "банан", "вишня" });
        var words2 = new MySet<string>(new[] { "банан", "арбуз", "груша" });

        Console.WriteLine($"Слова 1: {words1}");
        Console.WriteLine($"Слова 2: {words2}");
        Console.WriteLine($"Объединение: {words1 | words2}");
        Console.WriteLine($"Пересечение: {words1 & words2}");
        Console.WriteLine();

        Console.WriteLine($"Размер множества A: {setA.Size}");
        Console.WriteLine($"Размер пересечения: {intersect.Size}");
    }

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2() => throw new NotImplementedException();

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
}

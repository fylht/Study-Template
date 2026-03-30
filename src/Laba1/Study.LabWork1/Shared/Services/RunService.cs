using Study.LabWork1.Features.Task3.Services;
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
    public void RunTask1() => throw new NotImplementedException();

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2() => throw new NotImplementedException();

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() {
        Node<int> root = new Node<int>(1);

        Node<int> child1 = new Node<int>(2);
        Node<int> child2 = new Node<int>(3);
        Node<int> child3 = new Node<int>(4);

        Node<int> grandChild1 = new Node<int>(5);
        Node<int> grandChild2 = new Node<int>(6);
        Node<int> grandChild3 = new Node<int>(7);

        root.Children.Add(child1);
        root.Children.Add(child2);
        root.Children.Add(child3);

        child1.Children.Add(grandChild1);
        child1.Children.Add(grandChild2);

        child2.Children.Add(grandChild3);

        Console.WriteLine("Значения всех потомков узла root:");
        root.PrintChildren();
    }
}

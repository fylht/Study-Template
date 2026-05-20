using NUnit.Framework;
using Study.LabWork1.Features.Task1;
using System.Collections.Generic;

namespace Study.LabWork1.UnitTests.Features.Task1
{
    [TestFixture]
    internal class MySetTests
    {
        #region Тесты конструктора

        [Test]
        public void Constructor_RemovesDuplicates()
        {
            var items = new List<int> { 1, 1, 2, 2, 3 };
            var set = new MySet<int>(items);

            Assert.That(set.Size, Is.EqualTo(3), "Дубликаты должны быть удалены");
        }

        [Test]
        public void Constructor_EmptyCollection_CreatesEmptySet()
        {
            var set = new MySet<int>(new List<int>());

            Assert.That(set.Size, Is.EqualTo(0), "Пустое множество должно иметь размер 0");
        }

        #endregion

        #region Тесты ToString

        [Test]
        public void ToString_ReturnsCorrectFormat()
        {
            var set = new MySet<int>(new List<int> { 1, 2, 3 });
            var result = set.ToString();

            Assert.That(result, Does.StartWith("{"), "Результат должен начинаться с '{'");
            Assert.That(result, Does.EndWith("}"), "Результат должен заканчиваться на '}'");
            Assert.That(result, Does.Contain("1"), "Результат должен содержать '1'");
            Assert.That(result, Does.Contain("2"), "Результат должен содержать '2'");
            Assert.That(result, Does.Contain("3"), "Результат должен содержать '3'");
        }

        [Test]
        public void ToString_EmptySet_ReturnsEmptyBraces()
        {
            var set = new MySet<int>(new List<int>());
            var result = set.ToString();

            Assert.That(result, Is.EqualTo("{}"), "Пустое множество должно выводиться как '{}'");
        }

        #endregion

        #region Тесты оператора объединения (|)

        [Test]
        public void Operator_Union_DisjointSets_CombinesAllElements()
        {
            var setA = new MySet<int>(new List<int> { 1, 2 });
            var setB = new MySet<int>(new List<int> { 3, 4 });

            var result = setA | setB;

            Assert.That(result.Size, Is.EqualTo(4), "Объединение должно содержать 4 элемента");
        }

        [Test]
        public void Operator_Union_OverlappingSets_NoDuplicates()
        {
            var setA = new MySet<int>(new List<int> { 1, 2, 3 });
            var setB = new MySet<int>(new List<int> { 3, 4, 5 });

            var result = setA | setB;

            Assert.That(result.Size, Is.EqualTo(5), "Объединение должно содержать 5 элементов без дубликатов");
        }

        #endregion

        #region Тесты оператора пересечения (&)

        [Test]
        public void Operator_Intersection_FindsCommon()
        {
            var setA = new MySet<int>(new List<int> { 1, 2, 3 });
            var setB = new MySet<int>(new List<int> { 2, 3, 4 });

            var result = setA & setB;

            Assert.That(result.Size, Is.EqualTo(2), "Пересечение должно содержать 2 элемента");
        }

        [Test]
        public void Operator_Intersection_NoCommonElements_ReturnsEmptySet()
        {
            var setA = new MySet<int>(new List<int> { 1, 2 });
            var setB = new MySet<int>(new List<int> { 3, 4 });

            var result = setA & setB;

            Assert.That(result.Size, Is.EqualTo(0), "Пересечение должно быть пустым");
        }

        #endregion

        #region Тесты оператора разности (-)

        [Test]
        public void Operator_Difference_RemovesElements()
        {
            var setA = new MySet<int>(new List<int> { 1, 2, 3, 4 });
            var setB = new MySet<int>(new List<int> { 3, 4 });

            var result = setA - setB;

            Assert.That(result.Size, Is.EqualTo(2), "Разность должна содержать 2 элемента");
        }

        [Test]
        public void Operator_Difference_NoCommonElements_ReturnsOriginalSet()
        {
            var setA = new MySet<int>(new List<int> { 1, 2 });
            var setB = new MySet<int>(new List<int> { 3, 4 });

            var result = setA - setB;

            Assert.That(result.Size, Is.EqualTo(2), "Разность должна содержать все элементы первого множества");
        }

        #endregion

        #region Тесты оператора симметричной разности (/)

        [Test]
        public void Operator_SymmetricDifference_FindsUnique()
        {
            var setA = new MySet<int>(new List<int> { 1, 2, 3 });
            var setB = new MySet<int>(new List<int> { 3, 4, 5 });

            var result = setA / setB;

            Assert.That(result.Size, Is.EqualTo(4), "Симметричная разность должна содержать 4 элемента");
        }

        [Test]
        public void Operator_SymmetricDifference_IdenticalSets_ReturnsEmptySet()
        {
            var setA = new MySet<int>(new List<int> { 1, 2, 3 });
            var setB = new MySet<int>(new List<int> { 3, 2, 1 });

            var result = setA / setB;

            Assert.That(result.Size, Is.EqualTo(0), "Симметричная разность идентичных множеств должна быть пустой");
        }

        #endregion

        #region Тесты сравнения

        [Test]
        public void Operator_Equals_ComparesByValue()
        {
            var setA = new MySet<int>(new List<int> { 1, 2, 3 });
            var setB = new MySet<int>(new List<int> { 3, 2, 1 });

            Assert.That(setA == setB, Is.True, "Множества с одинаковыми элементами должны быть равны");
            Assert.That(setA.Equals(setB), Is.True, "Метод Equals должен возвращать true");
        }

        [Test]
        public void Operator_NotEquals_WorksCorrectly()
        {
            var setA = new MySet<int>(new List<int> { 1, 2, 3 });
            var setB = new MySet<int>(new List<int> { 4, 5, 6 });

            Assert.That(setA != setB, Is.True, "Множества с разными элементами не должны быть равны");
            Assert.That(setA == setB, Is.False, "Оператор == должен вернуть false");
        }

        #endregion

        #region Тесты неизменяемости

        [Test]
        public void Immutability_OriginalSetNotChanged()
        {
            var setA = new MySet<int>(new List<int> { 1, 2 });
            var setB = new MySet<int>(new List<int> { 3, 4 });
            var originalSize = setA.Size;

            var _ = setA | setB;

            Assert.That(setA.Size, Is.EqualTo(originalSize),
                "Исходное множество не должно измениться после операции");
        }

        #endregion
    }
}

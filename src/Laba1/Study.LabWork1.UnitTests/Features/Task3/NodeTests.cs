using System.IO;
using NUnit.Framework;
using Study.LabWork1.Features.Task3.Services;

namespace Study.LabWork1.UnitTests.Features.Task3
{
    [TestFixture]
    public class NodeTests
    {
        [TearDown]
        public void TearDown()
        {
            var standardOutput = new StreamWriter(Console.OpenStandardOutput())
            {
                AutoFlush = true
            };
            Console.SetOut(standardOutput);
        }

        [Test]
        public void Constructor_CreatesNodeWithValue()
        {
            var node = new Node<string>("Test");

            Assert.That(node.Value, Is.EqualTo("Test"));
            Assert.That(node.Children, Is.Not.Null);
            Assert.That(node.Children.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddChild_AddsNodeToChildren()
        {
            var root = new Node<string>("Root");
            var child = new Node<string>("Child");

            root.AddChild(child);

            Assert.That(root.Children.Count, Is.EqualTo(1));
            Assert.That(root.Children[0], Is.SameAs(child));
            Assert.That(root.Children[0].Value, Is.EqualTo("Child"));
        }

        [Test]
        public void AddChild_MultipleChildren_AllAdded()
        {
            var root = new Node<string>("Root");
            var child1 = new Node<string>("Child1");
            var child2 = new Node<string>("Child2");
            var child3 = new Node<string>("Child3");

            root.AddChild(child1);
            root.AddChild(child2);
            root.AddChild(child3);

            Assert.That(root.Children.Count, Is.EqualTo(3));
            Assert.That(root.Children[0].Value, Is.EqualTo("Child1"));
            Assert.That(root.Children[1].Value, Is.EqualTo("Child2"));
            Assert.That(root.Children[2].Value, Is.EqualTo("Child3"));
        }

        [Test]
        public void PrintChildren_OutputsAllChildrenRecursively()
        {
            var root = new Node<string>("A");
            var b = new Node<string>("B");
            var c = new Node<string>("C");
            var d = new Node<string>("D");

            root.AddChild(b);
            root.AddChild(c);
            b.AddChild(d);

            using var sw = new StringWriter();
            Console.SetOut(sw);

            root.PrintChildren();

            var output = sw.ToString();

            Assert.That(output, Does.Contain("B"));
            Assert.That(output, Does.Contain("C"));
            Assert.That(output, Does.Contain("D"));
        }

        [Test]
        public void PrintChildren_NodeWithoutChildren_PrintsNothing()
        {
            var root = new Node<string>("Root");

            using var sw = new StringWriter();
            Console.SetOut(sw);

            root.PrintChildren();

            var output = sw.ToString();

            Assert.That(output, Is.EqualTo(string.Empty));
        }

        [Test]
        public void TreeStructure_MatchesConfiguration()
        {
            var root = new Node<string>("A");
            var b = new Node<string>("B");
            var c = new Node<string>("C");
            var d = new Node<string>("D");
            var e = new Node<string>("E");

            root.AddChild(b);
            root.AddChild(c);
            b.AddChild(d);
            b.AddChild(e);

            Assert.That(root.Children.Count, Is.EqualTo(2));
            Assert.That(root.Children[0].Value, Is.EqualTo("B"));
            Assert.That(root.Children[1].Value, Is.EqualTo("C"));
            Assert.That(root.Children[0].Children.Count, Is.EqualTo(2));
            Assert.That(root.Children[0].Children[0].Value, Is.EqualTo("D"));
            Assert.That(root.Children[0].Children[1].Value, Is.EqualTo("E"));
            Assert.That(root.Children[1].Children.Count, Is.EqualTo(0));
        }
    }
}

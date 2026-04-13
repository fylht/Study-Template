using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Study.LabWork1.Features.Task3.Services
{
    public class Node<T>
    {
        public T Value { get; set; }
        public List<Node<T>> Children { get; set; }

        public Node(T value)
        {
            Value = value;
            Children = new List<Node<T>>();
        }

        public void AddChild(Node<T> child)
        {
            Children.Add(child);
        }

        public void PrintChildren()
        {
            foreach (var child in Children)
            {
                Console.WriteLine(child.Value);
                child.PrintChildren();
            }
        }
    }
}

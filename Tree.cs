using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTree
{
    internal class Tree
    {
        private readonly List<Node> _nodes;

        public Tree()
        {
            _nodes = new List<Node>();
        }

        public void Build(int[] values)
        {
            SetupNodes(values);
            ReadTree();
        }

        private void SetupNodes(int[] values)
        {
            foreach (var value in values)
            {
                if (_nodes.Count == 0)
                {
                    var newNode = new Node(value, 0, null, null);
                    _nodes.Add(newNode);
                }
                else
                {
                    var firstNode = _nodes[0];
                    AddNode(value, firstNode);
                }
            }
        }

        private void AddNode(int value, Node currentNode)
        {
            if (value < currentNode.Value)
            {
                if (currentNode.Left == null)
                {
                    var newNode = new Node(value, currentNode.Generation + 1, null, null);
                    currentNode.Left = newNode;
                    _nodes.Add(newNode);
                }
                else
                {
                    AddNode(value, currentNode.Left);
                }
            }
            else if (value > currentNode.Value)
            {
                if (currentNode.Right == null)
                {
                    var newNode = new Node(value, currentNode.Generation + 1, null, null);
                    currentNode.Right = newNode;
                    _nodes.Add(newNode);
                }
                else
                {
                    AddNode(value, currentNode.Right);
                }
            }
            else
            {
                throw new Exception($"Числа не должны повторяться. Уберите {value}");
            }
        }

        private void ReadTree()
        {
            var lastGen = _nodes.Last().Generation;

            for (int curGen = 0; curGen <= lastGen; curGen++)
            {
                var dist = MeasureDistance(curGen, lastGen);
                var map = GetMap(curGen);
                
                Console.WriteLine(String.Concat(dist, map));
            }
        }

        private string GetMap(int curGen)
        {
            var members = _nodes.Where(n => n.Generation == curGen)
                                .Select(n => n.Value)
                                .Order()
                                .ToList();

            return String.Join("\t\t", members);
        }

        private static string MeasureDistance(int curGen, int lastGen)
        {
            var sb = new StringBuilder();
            for (int i = 0; i <= (lastGen - curGen); i++)
            {
                sb.Append('\t');
            }

            return sb.ToString();
        }
    }
}

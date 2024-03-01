namespace SimpleTree
{
    internal class Node
    {
        public Node() { }
        public Node(int value, int generation, Node? left, Node? right) 
        {
            Value = value;
            Generation = generation;
            Left = left;
            Right = right;
        }
        public int Value { get; init; }
        public int Generation { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public override string? ToString()
        {
            return $"Value ";
        }
    }
}

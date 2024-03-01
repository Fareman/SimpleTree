namespace SimpleTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = [5, 7, 4, 1, 3, 9, 6];
            
            new Tree().Build(values);
            
            Console.ReadKey();
        }
    }
}

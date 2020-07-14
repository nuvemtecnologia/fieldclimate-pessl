namespace Fieldclimate.Pessl.Domain.Model
{
    public class Node
    {
        public string name { get; set; }
    }

    public class NodeRoot
    {
        public Node X { get; set; }
    }
}
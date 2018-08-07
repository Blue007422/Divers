class Node<T> where T : IComparable
{
    public List<Node<T>> children { get; private set; }

    public T Data { get; private set; }

    public Node(T data)
    {
        children = new List<Node<T>>();
        Data = data;
    }

    public void AddChildren(Node<T> child)
    {
        children.Add(child);
    }

    public Node<T> GetChild(T t)
    {
        
        foreach(Node<T> c in children)
        {
            if(c.Data.CompareTo(t) == 0)
            {
                return c;
            }
            
        }
        
        return null;
        
    }

    public int CountNode()
    {
    
        if(children == null || children.Count == 0)
        {
            return 1;
        }
        else
        {

            int somme = 0;

            foreach(Node<T> c in children)
            {
                somme += c.CountNode();                            
            }

            return somme + 1;
        }

    }

}

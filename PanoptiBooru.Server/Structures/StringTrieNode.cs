using System.Diagnostics;
using System.Text;

namespace PanoptiBooru.Server.Structures;

public class StringTrieNode
{
    public string Value { get; private set; }

    public SortedList<string, StringTrieNode> Children { get; private set; }

    protected StringTrieNode(string value, IEnumerable<string>? values = null)
    {
        Value = value;

        Children = new SortedList<string, StringTrieNode>();

        if (values != null)
        {
            var buckets = new Dictionary<char, List<string>>();
            
            foreach (string val in values)
            {
                if (val.Length == 0)
                {
                    if (!Children.ContainsKey(string.Empty))
                    {
                        Children.Add(string.Empty, new StringTrieNode(string.Empty, null));
                    }
                    continue;
                }

                if (!buckets.TryGetValue(val[0], out var subChildren))
                {
                    subChildren = buckets[val[0]] = new List<string>();
                }
                subChildren.Add(val[1..]);
            }

            foreach (var (key, subChildren) in buckets.OrderBy(p => p.Key))
            {
                string childValue = key.ToString();
                Children.Add(childValue, new StringTrieNode(childValue, subChildren));
            }
        }
    }

    internal IEnumerable<string> GetAll(string prefix, int depth = 0)
    {
        if (Children.ContainsKey(string.Empty))
        {
            yield return prefix;
        }

        var queue = new Queue<(StringTrieNode Node, string Value)>();

        foreach (var (c, node) in Children)
        {
            queue.Enqueue((node, prefix + c));
        }

        while (queue.TryDequeue(out var tuple))
        {
            if (tuple.Node.Children.Count == 0)
            {
                yield return tuple.Value;
            }
            else
            {
                foreach (var (v, n) in tuple.Node.Children)
                {
                    queue.Enqueue((n, tuple.Value + v));
                }
            }
        }
    }

    internal StringTrieNode AddChild(string fullValue)
    {
        throw new NotImplementedException();
    }
}

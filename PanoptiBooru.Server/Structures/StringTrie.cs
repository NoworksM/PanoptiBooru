namespace PanoptiBooru.Server.Structures;

public class StringTrie : StringTrieNode
{
    // ReSharper disable once ContextualLoggerProblem
    public StringTrie(IEnumerable<string> values) : base(string.Empty, values)
    {
    }

    public IEnumerable<string> GetAll()
    {
        foreach (string value in GetAll(string.Empty))
        {
            yield return value;
        }
    }

    public IEnumerable<string> GetByPrefix(string searchTerm, int? limit = null)
    {
        int emitted = 0;

        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            foreach (string value in GetAll())
            {
                yield return value;
                emitted++;

                if (limit.HasValue && emitted == limit.Value)
                {
                    yield break;
                }
            }
        }
        else
        {
            int idx = 1;
            string prefix = searchTerm[..idx];
            string suffix = searchTerm[idx..];

            void IncrementDepthTraces()
            {
                idx++;
                prefix = searchTerm[..idx];
                suffix = searchTerm[idx..];
            };
            
            if (!Children.TryGetValue(prefix[^1..], out var node))
            {
                yield break;
            }

            IncrementDepthTraces();

            while (node != default)
            {
                if (suffix.Length == 0)
                {
                    foreach (string value in node.GetAll(prefix[..^1]))
                    {
                        yield return value;
                    }
                    break;
                }
                
                if (!node.Children.TryGetValue(prefix[^1..], out node))
                {
                    yield break;
                }
                
                IncrementDepthTraces();
            }
        }
    }
}

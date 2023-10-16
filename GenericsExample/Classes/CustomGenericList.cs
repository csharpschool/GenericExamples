namespace GenericsExample.Classes;

public class CustomGenericList<T>
{
    private readonly List<T> _collection = new List<T>();

    public void Add(T item) => _collection.Add(item);
    
    public List<T> Get(Func<T, bool>? expression = null) =>
        expression is null 
            ? _collection 
            : _collection.Where(expression).ToList();

    public T? Single(Func<T, bool> expression)
    {
        var item = _collection.SingleOrDefault(expression);

        return item ?? throw new InvalidOperationException("More than one matching item found.");
    }
}


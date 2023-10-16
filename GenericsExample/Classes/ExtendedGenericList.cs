namespace GenericsExample.Classes;

public class ExtendedGenericList<T> : List<T> where T : class
{
    public List<T> Get(Func<T, bool>? expression = null) =>
        expression is null
            ? this
            : this.Where(expression).ToList();

    public T? Single(Func<T, bool> expression)
    {
        var item = this.SingleOrDefault(expression);

        return item ?? throw new InvalidOperationException("More than one matching item found.");
    }
}

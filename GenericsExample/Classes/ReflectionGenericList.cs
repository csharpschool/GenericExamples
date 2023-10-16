using GenericsExample.Interfaces;
using System.Reflection;
using GenericsExample.Extensions;

namespace GenericsExample.Classes;

public class ReflectionGenericList
{
    private readonly List<IAnimal> _animals = new()
    {
        new Animal { Id = 1, Name = "Spotty" },
        new Animal { Id = 2, Name = "Blacky" },
        new Animal { Id = 3, Name = "Spinner" }
    };

    private readonly List<IProduct> _products = new()
    {
        new Product { Id = 1, Title = "Panasonic TV" },
        new Product { Id = 2, Title = "Radio" },
        new Product { Id = 3, Title = "Sony TV" }
    };

    public List<T> Get<T>(Func<T, bool>? expression) where T : class
    {
        try
        {
            return GetType()// Buiult-in method that returns the object's type (class/struct)
                .GetVaraibles()
                .FindCollection<T>()
                .GetData(this) // Send in the current object of the Data class to get the collection data
                .ToQueryable<T>() // Delay fetching data until it's filtered
                .Filter(expression);

            /*var collections = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.FieldType == typeof(List<T>) && f.IsInitOnly)
                ?? throw new InvalidOperationException("Unsupported type");

            var value = collections.GetValue(this) ?? throw new InvalidDataException();

            var collection = ((List<T>)value).AsQueryable();

            if (expression is null) return collection.ToList();

            return collection.Where(expression).ToList();*/
        }
        catch (Exception ex)
        {
            throw;
        }
        
    }

}

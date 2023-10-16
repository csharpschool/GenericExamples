using GenericsExample.Interfaces;

namespace GenericsExample.Classes;

public class Product : IProduct
{
    public int Id { get; set; }
    public string Title { get; set; }
}

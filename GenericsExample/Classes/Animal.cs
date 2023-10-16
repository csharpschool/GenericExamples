using GenericsExample.Interfaces;

namespace GenericsExample.Classes;

public class Animal : IAnimal
{
    public int Id { get; set; }
    public string Name { get; set; }
}

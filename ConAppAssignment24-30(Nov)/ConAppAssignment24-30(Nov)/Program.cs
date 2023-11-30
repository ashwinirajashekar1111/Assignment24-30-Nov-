using System;
using System.Reflection;
class Source
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}

class Destination
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string AdditionalProperty { get; set; }
}




class Program
{
    static void MapProperties(object source, object destination)
    {
        var sourceType = source.GetType();
        var destinationType = destination.GetType();

        foreach (var destProp in destinationType.GetProperties())
        {
            var sourceProp = sourceType.GetProperty(destProp.Name);

            if (sourceProp != null && sourceProp.PropertyType == destProp.PropertyType)
            {
                var value = sourceProp.GetValue(source);
                destProp.SetValue(destination, value);
            }
        }
    }

    static void Main()
    {
        Source sourceInstance = new Source
        {
            Id = 1,
            Name = "Example",
            Price = 19.99
        };

        Destination destinationInstance = new Destination();

        MapProperties(sourceInstance, destinationInstance);

        Console.WriteLine("Mapped Properties:");
        Console.WriteLine($"Id: {destinationInstance.Id}");
        Console.WriteLine($"Name: {destinationInstance.Name}");
        Console.WriteLine($"Price: {destinationInstance.Price}");
        Console.WriteLine($"AdditionalProperty: {destinationInstance.AdditionalProperty}");
    }
}

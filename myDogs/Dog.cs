using System.Security.AccessControl;

public class Dog : Observer{
    public string Name {get; private set;}
    public string Breed {get; private set;}
    public int Age {get; private set;}
    public int Aggression {get; set;}
    public int Hunger {get; set;}

    

    public Dog(string name, string breed, int age, int aggression, int hunger)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(name));
        ArgumentNullException.ThrowIfNull(breed, nameof(breed));

        this.Name = name;
        this.Breed = breed;
        this.Age = age;
        this.Aggression = aggression;
        this.Hunger = hunger;

    }

    // TODO add a null constructor
    public void update(string roadName)
    {
        Console.WriteLine(roadName + " has called me to interact");
    }

    public override string ToString()
    {
        return $"[Name: {Name,5}, Breed: {Breed,9}, Age: {Age,2}, Aggression: {Aggression,2}, Hunger: {Hunger,2}]";
    }
}

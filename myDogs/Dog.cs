using System.Security.AccessControl;

public class Dog : Observer{
    public string Name {get; private set;}
    public int Age {get; private set;}
    public int Aggression {get; set;}
    public int Hunger {get; set;}

    

    public Dog(string name, int age, int aggression, int hunger)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(name));

        this.Name = name;
        this.Age = age;
        this.Aggression = aggression;
        this.Hunger = hunger;

    }

    // TODO add a null constructor
    public void update(string roadName)
    {
        Console.WriteLine(roadName + " has called me to interact");
    }
}

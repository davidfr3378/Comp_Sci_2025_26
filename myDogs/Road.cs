using System;
using System.ComponentModel;
using System.Net;
using System.Reflection.PortableExecutable;

public class Road : Subject
{
    private int maxPedestrians { get; } = 2;
    public string Name { get; set; }

    public event Action<Dog, Dog> OnTwoDogsPresent;
    private List<Dog> pedestrians = new List<Dog>();

    // Constructor
    public Road(string name)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(name));
        getName(name);
    }

    //
    public void attach(Dog d)
    {

        //Make sure they aren't adding more than allowed
        switch (pedestrians.Count)
        {
            case int n when n >= 0 && n < maxPedestrians:
                pedestrians.Add(d);
                break;
            default:
                Console.WriteLine($" -- You can't add more than {maxPedestrians} per road");
                // 
                break;

        }

        // When two dogs are on the road, trigger an event 
        if (pedestrians.Count == maxPedestrians) OnTwoDogsPresent?.Invoke(pedestrians[0], pedestrians[1]); 
    }

    public void retach(Dog d)
    {
        pedestrians.Remove(d);
    }

    public void notify()
    {
        pedestrians.ForEach(p => p.update(this.Name));
    }

    //
    public void getName(string name){
        this.Name = name;
    }

}

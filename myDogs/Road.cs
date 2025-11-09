using System;
using System.ComponentModel;
using System.Net;
using System.Reflection.PortableExecutable;

public class Road : Subject
{
    private int maxPedestrians { get; } = 2;
    public string Name { get; private set; }
    int Subject.maxPedestrians { get => maxPedestrians;} // TODO Understand this later

    private List<Observer> pedestrians = new List<Observer>();

    Road(string Name)
    {
        ArgumentNullException.ThrowIfNull(Name, nameof(Name));
        this.Name = Name;
    }

    //
    public void attach(Observer o)
    {
        //Make sure they aren't adding more than allowed
        switch (pedestrians.Count)
        {
            case int n when n >= 0 && n < maxPedestrians:
                pedestrians.Add(o);
                break;
            default:
                Console.WriteLine($" -- You can't add more than {maxPedestrians} per road");
                // 
                break;

        }

        observeMaxPedestrians(); 
    }

    public void retach(Observer o)
    {
        pedestrians.Remove(o);

    }

    public void notify()
    {
        pedestrians.ForEach(p => p.update(this.Name));
    }

    private bool observeMaxPedestrians()
    {
        if (pedestrians.Count == maxPedestrians)
            return true;
        else
            return false;
    }
}



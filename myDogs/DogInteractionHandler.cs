using System;

public class DogInteractionHandler
{

    public DogInteractionHandler(Road road)
    {
        road.OnTwoDogsPresent += interactionHandler;
    }

    private void interactionHandler(Dog a, Dog b)
    {
        Console.WriteLine($"{a.Name} and {b.Name} have seen each other");

        // If either of the dogs has agrresion > 5
        if ((Math.Max(a.Aggression, b.Aggression)) > 5)
        {
            Console.WriteLine(
                a.Aggression > b.Aggression ? $"{a.Name} attacks and beats {b.Name}" :
                a.Aggression < b.Aggression ? $"{b.Name} attacks and beats {a.Name}" :
                "A and B are evenly matched"
            );
        }
        else
        {
            Console.WriteLine("They are friendly");
        }
    }
}

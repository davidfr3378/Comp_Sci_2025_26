using System;

public class DogInteractionHandler{

    public DogInteractionHandler(Road road){
        road.OnTwoDogsPresent += interactionHandler;
    }

    private void interactionHandler(Dog a, Dog b){
        Console.WriteLine($"{a.Name} and {b.Name} have seen each other");
        
        Console.WriteLine(
            a.aggression > b.aggression ? $"{a.Name} attacks and beats {b.Name}" :
            a.aggression < b.aggression ? $"{b.Name} attacks and beats {a.Name}" :
            "A and B are evenly matched"
        );
    }
}
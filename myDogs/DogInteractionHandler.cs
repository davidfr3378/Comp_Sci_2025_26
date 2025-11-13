using System;

public class DogInteractionHandler{

    public DogInteractionHandler(Road road){
        road.OnTwoDogsPresent += interactionHandler;
    }

    private void interactionHandler(Observer a, Observer b){
        Console.WriteLine($"Observer {a.Name} and {b.Name} have been called to fight");
    }
}
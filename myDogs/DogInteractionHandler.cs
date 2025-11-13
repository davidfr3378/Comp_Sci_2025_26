using System;

public class DogInteractionHandler{

    public DogInteractionHandler(Road road){
        road.OnTwoDogsPresent += interactionHandler;
    }

    private void interactionHandler(Dog a, Dog b){
        Console.WriteLine($"{a.Name} and {b.Name} have seen each other");
        
        if ((a.Aggresion > b.Aggresion) && (a.Hunger > b.Hunger)){
            Console.WriteLine($"{a.Name} is more agressive and hungry. It kills {b.Name}");
        }

    }
}
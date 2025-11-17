using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// I did this assignment in different files but will join them together into one file to make submission easier
/// </summary>

// small note: using simple observer names (Subject/Observer) to match the assignment prompt — kept them minimal.

public interface Subject
{
    // attach an observer (Dog)
    void attach(Dog d);
    // remove observer
    void detach(Dog d);
    // notify observers of some change
    void notify();
}

public interface Observer
{
    // called when the Subject wants to inform the observer
    void update(string roadName);
}

public class Road : Subject
{
    // max number of dogs that can be on the road at once — set as a read-only property
    private int maxPedestrians { get; } = 2;

    // public name so other parts of the program can reference this road
    public string Name { get; set; }

    // event fired when two dogs are present — subscribers can react (like handling interactions)
    public event Action<Dog, Dog> OnTwoDogsPresent;

    // keep track of current dogs on this road
    private List<Dog> pedestrians = new List<Dog>();

    // Constructor
    public Road(string name)
    {
        // validate quickly — avoids nulls creeping in later
        ArgumentNullException.ThrowIfNull(name, nameof(name));
        setName(name);
    }

    public void attach(Dog d)
    {
        // Make sure they aren't adding more than allowed
        // I used a switch here mostly to avoid an if/else clutter — felt cleaner for the bounds check.
        switch (pedestrians.Count)
        {
            case int n when n >= 0 && n < maxPedestrians:
                // add the dog to the list if there's space
                pedestrians.Add(d);
                break;
            default:
                // tell the user why the add failed — kept this simple for CLI feedback
                Console.WriteLine($" -- You can't add more than {maxPedestrians} per road");
                break;
        }

        // When two dogs are on the road, trigger an event 
        // null-safe invocation so we don't crash if nobody subscribed
        if (pedestrians.Count == maxPedestrians) OnTwoDogsPresent?.Invoke(pedestrians[0], pedestrians[1]);
    }

    public void detach(Dog d)
    {
        // remove the dog when they leave — Remove is fine even if the dog isn't present (it will just do nothing)
        pedestrians.Remove(d);
    }

    public void notify()
    {
        // send an update to every dog currently on the road
        pedestrians.ForEach(p => p.update(this.Name));
    }

    public void setName(string name)
    {
        // trivial setter separated out in case we want validation later
        this.Name = name;
    }
}

public class Dog : Observer
{
    // Basic attributes — kept getters private where we don't want external classes mutating them directly
    public string Name { get; private set; }
    public string Breed { get; private set; }
    public int Age { get; private set; }

    // these are supposed to be mutable, so left as public set
    public int Aggression { get; set; }
    public int Hunger { get; set; }

    public Dog(string name, string breed, int age, int aggression, int hunger)
    {
        // quick null checks so we don't get weird null name/breed later
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
        // This is intentionally simple — the dog "responds" to being notified
        Console.WriteLine($"{roadName} has called me to interact");
    }

    public override string ToString()
    {
        // formatted nicely for the console; padding makes columns look decent when printed in a list
        return $"[Name: {Name,5}, Breed: {Breed,9}, Age: {Age,2}, Aggression: {Aggression,2}, Hunger: {Hunger,2}]";
    }
}

public class DogInteractionHandler
{
    // Subscribe to a road's event when this handler is created
    public DogInteractionHandler(Road road)
    {
        road.OnTwoDogsPresent += interactionHandler;
    }

    private void interactionHandler(Dog a, Dog b)
    {
        // short status line so user can follow what's happening
        Console.WriteLine($"{a.Name} and {b.Name} have seen each other");

        // If either of the dogs has aggression > 5
        // I used Math.Max for clarity — we're checking whether one of them is "high aggression"
        if (Math.Max(a.Aggression, b.Aggression) >= 5)
        {
            // ternaries to pick the appropriate outcome message. Keeps the logic compact.
            Console.WriteLine(
                a.Aggression > b.Aggression ? $"{a.Name} attacks and beats {b.Name}" :
                a.Aggression < b.Aggression ? $"{b.Name} attacks and beats {a.Name}" :
                $"{a.Name} and {b.Name} are evenly matched"
            );
        }
        else
        {
            // friendly meeting fallback
            Console.WriteLine("They are friendly");
        }
    }
}

class submission
{
    // store the user's dogs separately from bots
    static List<Dog> userDogs = new List<Dog>();
    static List<Road> roadList = new List<Road>();
    static bool quit = false;

    public static void Main(String[] args)
    {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Welcome to Doggo Sims\n");

        int choice;
        int roadChoice;
        int dogChoice;

        // - Roads
        // create roads and hook up interaction handlers immediately so events are handled automatically
        Road road1 = new Road("Road 1"); new DogInteractionHandler(road1); roadList.Add(road1);
        Road road2 = new Road("Road 2"); new DogInteractionHandler(road2); roadList.Add(road2);
        Road road3 = new Road("Road 3"); new DogInteractionHandler(road3); roadList.Add(road3);
        Road road4 = new Road("Road 4"); new DogInteractionHandler(road4); roadList.Add(road4);

        // - Dogs 
        // Bots (pre-placed on roads so user sees activity immediately)
        Dog dog1 = new Dog("Bot 1", "German Sheperd", 4, 10, 2); road1.attach(dog1);
        Dog dog2 = new Dog("Bot 2", "Rottweiler", 1, 8, 7); road2.attach(dog2);
        Dog dog3 = new Dog("Bot 3", "Labrador Retriever", 12, 6, 6); road3.attach(dog3);
        Dog dog4 = new Dog("Bot 4", "Beagle", 234, 5, 4); road4.attach(dog4);

        // Gift the user two dogs, print attributes
        Console.WriteLine("You have been gifted two dogs");
        Dog dog5 = new Dog("Dan", "Dachshund", 3, 9, 9); userDogs.Add(dog5);
        Dog dog6 = new Dog("Han", "Boxer", 8, 9, 9); userDogs.Add(dog6);
        // show the user what they got — ToString already formats it
        userDogs.ForEach(dog => Console.WriteLine(dog.ToString()));

        // Let the user create two more dogs
        Console.WriteLine("\nCreate two more!");
        userDogs.Add(createDog());
        userDogs.Add(createDog());

        // -- Main Loop --
        while (quit == false)
        {
            choice = getUserChoice();

            switch (choice)
            {
                case 1:
                    // simulate picking a road and a dog, then attach the dog to cause interactions
                    roadChoice = getRoadChoice();
                    dogChoice = getDogChoice();

                    roadList[roadChoice].attach(userDogs[dogChoice]);

                    // - Meeting happens
                    Console.WriteLine();
                    // detach to simulate leaving — keeps the road free again
                    roadList[roadChoice].detach(userDogs[dogChoice]);
                    break;

                case 2:
                    // print all user dogs and their stats — simple list view
                    Console.WriteLine("--------------------------------------------");
                    userDogs.ForEach(dog => Console.WriteLine(dog.ToString()));
                    Console.WriteLine("--------------------------------------------");
                    break;

                case 3:
                    // change stats for a chosen dog
                    dogChoice = getDogChoice();
                    changeDogStats(dogChoice);
                    break;

                case 4:
                    // quit flag flips and program exits loop
                    quit = true;
                    Console.WriteLine("Goodbye User");
                    break;

                default:
                    // shouldn't happen because getUserChoice validates, but kept for completeness
                    break;
            }
        }
    }

    // ------- UTILITIES -------

    public static int getUserChoice()
    {
        // allowed string choices — kept as strings so we can compare directly to trimmed input
        string[] optionsList = { "1", "2", "3", "4" };

        Console.WriteLine("-------------------------");
        Console.WriteLine("\nChoose an option: ");
        Console.WriteLine("[1] Simulate a meeting");
        Console.WriteLine("[2] View all dog and their attributes ");
        Console.WriteLine("[3] Edit a dogs stats");
        Console.WriteLine("[4] Quit\n");
        Console.WriteLine("-------------------------");

        while (true)
        {
            Console.Write("Choice: ");
            string option = Console.ReadLine().Trim().ToLower();

            // loop until valid input — no exceptions, just repeat prompt
            if (optionsList.Contains(option))
                return int.Parse(option);
        }
    }

    public static int getRoadChoice()
    {
        Console.WriteLine("\nAvailable Roads: ");
        for (int i = 0; i < roadList.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {roadList[i].Name}");
        }

        while (true)
        {
            Console.Write("\nYour choice: ");
            string choice = Console.ReadLine().Trim().ToLower();

            // parse and check bounds, then return zero-based index
            if (int.TryParse(choice, out int intChoice) && (intChoice >= 1 && intChoice <= roadList.Count))
            {
                Console.WriteLine("-------------------------");
                return intChoice - 1;
            }
        }
    }

    public static int getDogChoice()
    {
        Console.WriteLine("\nAvailable Dogs: ");
        for (int i = 0; i < userDogs.Count; i++)
        {
            // only showing names here to keep the menu tidy
            Console.WriteLine($"[{i + 1}] {userDogs[i].Name}");
        }

        while (true)
        {
            Console.Write("\nYour choice: ");
            string choice = Console.ReadLine().Trim().ToLower();

            // same pattern as road choice — defensive parsing
            if (int.TryParse(choice, out int intChoice) && (intChoice >= 1 && intChoice <= userDogs.Count))
            {
                Console.WriteLine("-------------------------");
                return intChoice - 1;
            }
        }
    }

    public static Dog createDog()
    {
        // loop until user enters valid values
        while (true)
        {
            Console.Write("\nEnter Dog Name: "); string Name = Console.ReadLine();
            Console.Write("Enter Dog Breed: "); string Breed = Console.ReadLine();
            Console.Write("Enter Dog Age: "); string Age = Console.ReadLine();
            Console.Write("Enter Dog Aggression: "); string Aggresssion = Console.ReadLine();
            Console.Write("Enter Dog Hunger: "); string Hunger = Console.ReadLine();

            // validate all fields; if good, return a new Dog instance
            if ((!string.IsNullOrEmpty(Name)) && (!string.IsNullOrEmpty(Breed)) && int.TryParse(Age, out int iAge) && int.TryParse(Aggresssion, out int iAggression) && int.TryParse(Hunger, out int iHunger))
            {
                return new Dog(Name, Breed, iAge, iAggression, iHunger);
            }
            else
            {
                // quick feedback and let the user try again
                Console.WriteLine("** Unacceptable values entered **");
            }
        }
    }

    public static void changeDogStats(int dogIndex)
    {
        Console.WriteLine("What stat do you wish to change: ");
        Console.Write("(1) Aggression \n (2) Hunger\n Choice: ");
        string choice = Console.ReadLine().Trim().ToLower();

        bool flag = true;
        switch (choice)
        {
            case "1":
                // loop until a valid aggression value is provided
                while (flag)
                {
                    Console.Write("Enter new value (1-10): ");
                    string newVal = Console.ReadLine();

                    // if the value entered is between 1 and 10
                    if (int.TryParse(newVal, out int val) && val >= 1 && val <= 10)
                    {
                        userDogs[dogIndex].Aggression = val;
                        flag = false;
                    }
                }
                break;

            case "2":
                // loop until a valid hunger value is provided
                while (flag)
                {
                    Console.Write("Enter new value: ");
                    string newVal = Console.ReadLine();

                    // same validation pattern as aggression
                    if (int.TryParse(newVal, out int val) && val >= 1 && val <= 10)
                    {
                        userDogs[dogIndex].Hunger = val;
                        flag = false;
                    }
                }
                break;

            default:
                // basic error message for unexpected input
                Console.WriteLine(" ** Unacceptable value entered! **");
                break;
        }
    }
}

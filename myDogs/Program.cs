using System;

class Program
{
    static List<Dog> userDogs = new List<Dog>();
    static List<Road> roadList = new List<Road>();
    static Boolean quit = false;
    public static void Main(String[] args)
    {
        Console.WriteLine("---------------------------------------------"); 
        Console.WriteLine("Welcome to Doggo Sims\n"); 


        // -- Setup --

        int choice;
        int roadChoice;
        int dogChoice;


        // - Roads

        Road road1 = new Road("Road 1"); new DogInteractionHandler(road1); roadList.Add(road1);
        Road road2 = new Road("Road 2"); new DogInteractionHandler(road2); roadList.Add(road2);
        Road road3 = new Road("Road 3"); new DogInteractionHandler(road3); roadList.Add(road3);
        Road road4 = new Road("Road 4"); new DogInteractionHandler(road4); roadList.Add(road4);


        // - Dogs 

        // Bots
        Dog dog1 = new Dog("Bot 1", "German Sheperd", 4, 10, 2);  road1.attach(dog1);
        Dog dog2 = new Dog("Bot 2", "Rottweiler", 1, 8, 7);  road2.attach(dog2);
        Dog dog3 = new Dog("Bot 3", "Labrador Retriever", 12, 6, 6); road3.attach(dog3);
        Dog dog4 = new Dog("Bot 4", "Beagle", 234, 5, 4);  road4.attach(dog4);


        // Gift the user two dogs, print attributes
        Console.WriteLine("You have been gifted two dogs");
        Dog dog5 = new Dog("Dan", "Dachshund", 3, 9, 9);  userDogs.Add(dog5);
        Dog dog6 = new Dog("Han", "Boxer", 8, 9, 9);  userDogs.Add(dog6);
        userDogs.ForEach(dog => Console.WriteLine(dog.ToString()));

        // Let the user create two more dogs
        Console.WriteLine("\nCreate two more!");
        userDogs.Add(createDog());
        userDogs.Add(createDog());


        // -- Main Loop --
        while(quit == false)
        {
            choice = getUserChoice();

            switch (choice)
            {
                case 1:
                    roadChoice = getRoadChoice();
                    dogChoice  = getDogChoice();

                    roadList[roadChoice].attach(userDogs[dogChoice]);

                    // - Meeting happens
                    Console.WriteLine();
                    roadList[roadChoice].detach(userDogs[dogChoice]);
                    break;

                case 2:
                    Console.WriteLine("--------------------------------------------");
                    userDogs.ForEach(dog => Console.WriteLine(dog.ToString()));
                    Console.WriteLine("--------------------------------------------");
                    break;
                
                case 3:
                    dogChoice = getDogChoice();
                    changeDogStats(dogChoice);
                    break;

                case 4:
                    quit = true;
                    Console.WriteLine("Goodbye User");
                    break; 

                default:
                    break;
            }
            

        }

    }


    // ------- UTILITIES -------

    public static int getUserChoice()
    {
        string[] optionsList = {"1","2","3", "4"};

        Console.WriteLine("-------------------------");
        Console.WriteLine("\nChoose an option: ");
        Console.WriteLine("[1] Simulate a meeting");
        Console.WriteLine("[2] View all dog and their attributes ");
        Console.WriteLine("[3] Edit a dogs stats");
        
        Console.WriteLine("[4] Quit\n");
        Console.WriteLine("-------------------------");

        while(true){
        Console.Write("Choice: ");
        string option = Console.ReadLine().Trim().ToLower();

        if(optionsList.Contains(option))
            return int.Parse(option);
        }
    }

    public static int getRoadChoice()
    {
        Console.WriteLine("\nAvailable Roads: ");
        for(int i = 0; i < roadList.Count; i++)
        {
            Console.WriteLine($"[{i+1}] {roadList[i].Name}");
        }

        while (true)
        {
            Console.Write("\nYour choice: ");
            string choice = Console.ReadLine().Trim().ToLower();

            if(int.TryParse(choice, out int intChoice) && (intChoice <= roadList.Count))
                Console.WriteLine("-------------------------");
                return intChoice - 1;
                
        }
    }

    public static int getDogChoice()
    {
        Console.WriteLine("\nAvailable Dogs: ");
        for(int i = 0; i < userDogs.Count; i++)
        {
            Console.WriteLine($"[{i+1}] {userDogs[i].Name}");
        }

        while (true)
        {
            Console.Write("\nYour choice: ");
            string choice = Console.ReadLine().Trim().ToLower();

            if(int.TryParse(choice, out int intChoice) && (intChoice <= userDogs.Count))
                Console.WriteLine("-------------------------");
                return intChoice - 1;
                
        }
    }

    public static Dog createDog()
    {
        while(true){
        Console.Write("\nEnter Dog Name: "); string Name = Console.ReadLine(); 
        Console.Write("Enter Dog Breed: "); string Breed = Console.ReadLine();
        Console.Write("Enter Dog Age: "); string Age = Console.ReadLine();
        Console.Write("Enter Dog Aggression: "); string Aggresssion = Console.ReadLine(); 
        Console.Write("Enter Dog Hunger: "); string Hunger = Console.ReadLine(); 

            if ((!string.IsNullOrEmpty(Name)) && (!string.IsNullOrEmpty(Breed)) && int.TryParse(Age, out int iAge) && int.TryParse(Aggresssion, out int iAggression) && int.TryParse(Hunger, out int iHunger))
            {
                return new Dog(Name, Breed, iAge, iAggression, iHunger);
            }
            else
            {
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
                while(flag){
                    Console.Write("Enter new value: "); 
                    string newVal = Console.ReadLine();

                    if(int.TryParse(newVal, out int val))
                    {
                        userDogs[dogIndex].Aggression = val;
                        flag = false;
                    }
                }
                break;
                
            case "2":
                while(flag){
                    Console.Write("Enter new value: "); 
                    string newVal = Console.ReadLine();

                    if(int.TryParse(newVal, out int val))
                    {
                        userDogs[dogIndex].Hunger = val;
                        flag = false;
                    }
                }
                break;

            default:
                Console.WriteLine(" ** Unacceptable value entered! **");
                break;
        }
    }

}
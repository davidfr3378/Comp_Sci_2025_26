using System;

class Program
{
    static List<Dog> userDogs = new List<Dog>();
    static List<Road> roadList = new List<Road>();
    static Boolean quit = false;
    public static void Main(String[] args)
    {
        Console.WriteLine("---------------------------------------------"); 
        Console.WriteLine("Welcome to Doggo Sims"); 


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
        Dog dog1 = new Dog("Bot 1", 4, 10, 2);  road1.attach(dog1);
        Dog dog2 = new Dog("Bot 2", 1, 8, 7);  road2.attach(dog2);
        Dog dog3 = new Dog("Bot 3", 12, 6, 6); road3.attach(dog3);
        Dog dog4 = new Dog("Bot 4", 234, 5, 4);  road4.attach(dog4);

        //Users Dogs
        Dog dog5 = new Dog("Dan", 3, 9, 9);  userDogs.Add(dog5);
        Dog dog6 = new Dog("Han", 8, 9, 9);  userDogs.Add(dog6);
        Dog dog7 = new Dog("Kan", 10, 9, 9); userDogs.Add(dog7);
        Dog dog8 = new Dog("Wan", 2, 9, 9);  userDogs.Add(dog8);


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
                    dogChoice = getDogChoice();
                    //TODO: How's this gonna work?
                    break;

                case 3:
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
        string[] optionsList = {"1","2","3"};

        Console.WriteLine("-------------------------");
        Console.WriteLine("\nChoose an option: ");
        Console.WriteLine("[1] Simulate a meeting");
        Console.WriteLine("[2] Edit a dogs stats");

        Console.WriteLine("[3] Quit\n");
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

}
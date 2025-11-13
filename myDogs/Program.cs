using System;

class Program
{
    public static void Main(String[] args)
    {
        // Do stuff here

        //Subj.
        Road r1 = new Road("Road 1");
        DogInteractionHandler r1InteractHandler = new DogInteractionHandler(r1);

        //Obj.
        Observer dog1 = new Dog("Dan", 3, 4, 5); r1.attach(dog1);
        Observer dog2 = new Dog("Han", 3, 4, 5); r1.attach(dog2);
    }

}
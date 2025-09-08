import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Scanner;

import Map.GameMap;

public class GameMaker {
    private boolean running = true;
    Player player;
    //List of all Objects including Items, the Player, Mobs, etc.
    static HashMap<Integer, GameObject> objectList = new HashMap<Integer, GameObject>();
    //TODO Map making 
    static GameMap map = new GameMap(30, 50);
    //static List<GameObject> objects = new ArrayList<>();  objects.add(player);  //TODO I could change this to a HashMap (Integers to Objects) for O(1) lookups
    private Scanner scanner = new Scanner(System.in);

    public GameMaker(){
        // * CREATING BASIC MAP 
        dummyObject blank = new dummyObject(100); objectList.put(blank.getID(), blank);
        map.setCell(6, 4, blank.getID()); //TODO dw, Ignore

        //Creating a wall
        dummyObject wall = new dummyObject(62); objectList.put(wall.getID(), wall);
            map.setCell(8, 3, wall.getID());
        // * End of crating basic objects

        //* Items:



        //Create a player at (9,5) and give them a couple items
        player = new Player(new Coordinate(7,10), 0);  objectList.put(player.getID(), player);
        map.setCell(7, 10, player.getID());

        //Items
                //object ahead
        Item basicSword = new Item("Sword", "A basic sword", "Kills", 21, new Coordinate(7,4));
        objectList.put(basicSword.getID(), basicSword); map.setCell(7, 4, basicSword.getID());
    }

    public void start(){
        while (running) {
            // 1. Print the map
            map.print();

            // 2. Ask for input
            System.out.print("Enter move (w/a/s/d) or q to quit: ");
            String input = scanner.nextLine().trim().toLowerCase();

            // 3. Process input
            try{
                switch (input) {
                case "w" -> player.moveForward();
                case "s" -> player.moveBackward();
                case "a" -> player.moveLeft();
                case "d" -> player.moveRight();
                case "q" -> running = false;
                default -> System.out.println("Invalid input.");
            }
            }catch(ArrayIndexOutOfBoundsException e){
                System.out.println("Stay clear of the edge");
            }
            

            // 4. Update state (items, interactions, etc.)
            //map.checkInteractions(player);
        }
        System.out.println("Thanks for playing!");
    }


}

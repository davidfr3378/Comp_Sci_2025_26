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
        MemoryShard memoryshard1 = new MemoryShard("Mem1", "Mem1 des", "mem1 eff", 10, new Coordinate(,), 0);  //1
        objectList.put(memoryshard1.getID(), MemoryShard1); map.setCell(8, 3, memoryshard1.getID());

        MemoryShard memoryshard2 = new MemoryShard("Mem2", "Mem2 des", "mem2 eff", 11, new Coordinate(,), 1);  //2
        objectList.put(memoryshard2.getID(), MemoryShard2); map.setCell(8, 3, memoryshard2.getID());

        MemoryShard memoryshard3 = new MemoryShard("Mem3", "Mem3 des", "mem3 eff", 12, new Coordinate(,), 2);  //3
        objectList.put(memoryshard3.getID(), MemoryShard3); map.setCell(8, 3, memoryshard3.getID());

        MemoryShard memoryshard4 = new MemoryShard("Mem4", "Mem4 des", "mem4 eff", 12, new Coordinate(,), 3);  //4
        objectList.put(memoryshard4.getID(), MemoryShard4); map.setCell(8, 3, memoryshard4.getID());

        MemoryShard memoryshard5 = new MemoryShard("Mem5", "Mem5 des", "mem5 eff", 14, new Coordinate(,), 4);  //5
        objectList.put(memoryshard5.getID(), MemoryShard5); map.setCell(8, 3, memoryshard5.getID());

        MemoryShard memoryshard6 = new MemoryShard("Mem6", "Mem6 des", "mem6 eff", 15, new Coordinate(,), 5);  //6
        objectList.put(memoryshard6.getID(), MemoryShard6); map.setCell(8, 3, memoryshard6.getID());

        MemoryShard memoryshard7 = new MemoryShard("Mem7", "Mem7 des", "mem7 eff", 16, new Coordinate(,), 6);  //7
        objectList.put(memoryshard7.getID(), MemoryShard7); map.setCell(8, 3, memoryshard7.getID());

        MemoryShard memoryshard8 = new MemoryShard("Mem8", "Mem8 des", "mem8 eff", 17, new Coordinate(,), 7);  //8
        objectList.put(memoryshard8.getID(), MemoryShard8); map.setCell(8, 3, memoryshard8.getID());

        MemoryShard memoryshard9 = new MemoryShard("Mem9", "Mem9 des", "mem9 eff", 18, new Coordinate(,), 8);  //9
        objectList.put(memoryshard9.getID(), MemoryShard9); map.setCell(8, 3, memoryshard9.getID());


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

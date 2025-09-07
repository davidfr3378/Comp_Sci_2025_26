import java.util.ArrayList;
import java.util.List;

import Map.GameMap;

public class GameMaker {
    //List of all Objects including Items, the Player, Mobs, etc.
    static List<GameObject> objects = new ArrayList<>();   //TODO I could change this to a HashMap (Integers to Objects) for O(1) lookups
    
    public static void main(String[] args){
        //TODO Map making 
        GameMap map = new GameMap(9, 9);

        //Create a player at (9,5) and give them a couple items
        Player player = new Player(new Coordinate(8,4), 0); objects.add(player);
        map.setCell(8, 4, player.getID());

        //Create walls beside the player and an item before them
        //left wall
        dummyObject wall1 = new dummyObject(62); objects.add(wall1);
        map.setCell(8, 3, wall1.getID());
        dummyObject wall2 = new dummyObject(63); objects.add(wall2);
        map.setCell(7, 3, wall2.getID());
        dummyObject wall3 = new dummyObject(64); objects.add(wall3);
        map.setCell(6, 3, wall3.getID());
        //right wall
        dummyObject wall4 = new dummyObject(65); objects.add(wall4);
        map.setCell(8, 5, wall4.getID());
        dummyObject wall5 = new dummyObject(66); objects.add(wall5);
        map.setCell(7, 5, wall5.getID());
        dummyObject wall6 = new dummyObject(67); objects.add(wall6);
        map.setCell(6, 5, wall6.getID());
        //object ahead
        Item basicSword = new Item("Sword", "A basic sword", "Kills", 21, new Coordinate(7,4));
        objects.add(basicSword); map.setCell(7, 4, basicSword.getID());

        //Creating a basic sword and giving the user. 
        

        //Print Items
        // System.out.println("\nPrinting Inventory:");
        // player.printInventory();
        // System.out.println();

        //Check locations
        player.moveForward();
        //System.out.println("To players left is : " + player.checkRightDirection());
        System.out.println("\nPrinting Inventory:");
        player.printInventory();
        System.out.println();

        System.out.println(player.getLocation()); 
        }

}

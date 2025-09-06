import java.util.ArrayList;
import java.util.List;

import Map.GameMap;

public class GameMaker {
    static List<GameObject> objects = new ArrayList<>();   //TODO I could change this to a HashMap (Integers to Objects) for O(1) lookups
    
    public static void main(String[] args){
        //TODO Map making 
        GameMap map = new GameMap(9, 9);

        //List of all Objects including Items, the Player, Mobs, etc.
        
        //Create a player at (9,5) and give them a couple items
        Player player = new Player(new Coordinate(9,5), 0); objects.add(player);

        //Creating a basic sword and giving the user. 
        Item basicSword = new Item("Sword", "A basic sword", "Kills", 1);
        player.addInventory(basicSword); objects.add(basicSword);

        //Creating a basic sword and giving the user. 
        Item basicShield = new Item("Sword", "A basic sword", "Kills", 2);
        player.addInventory(basicShield); objects.add(basicShield);

        //Creating a basic sword and giving the user. 
        Item healPotion = new Item("Sword", "A basic sword", "Kills", 3);
        player.addInventory(healPotion); objects.add(healPotion);

        //Print Items
        player.printInventory();

        //Check locations
        System.out.println("Player is at: " + player.getLocation());
        System.out.println("To players forward is : " + player.checkForwardDirection());
        System.out.println("To players left is : " + player.checkLeftDirection());
        }

}

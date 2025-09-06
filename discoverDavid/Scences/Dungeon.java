public class Dungeon {
  public static void main(String[] args) {
    System.out.println("Hello World");

    //Create a player at (9,5) and give them a couple items
    Player player = new Player(new Coordinate(9,5), 0);
    player.addInventory(new Item("Sword", "A basic sword", "Kills", 1));
    player.addInventory(new Item("Shield", "A basic shield", "+5 Health", 1));
    player.addInventory(new Item("Potion", "A basic heal potion", "+ 10 Health", 1));

    //Print Items
    player.printInventory();

    //Check locations
    System.out.println("Player is at: " + player.getLocation());
    System.out.println("To players forward is : " + player.checkForwardDirection());
    System.out.println("To players left is : " + player.checkLeftDirection());
  }
}
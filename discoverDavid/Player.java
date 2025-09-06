public class Player{
    private Coordinate currentLocation;
    private Inventory<Item> inventory;
    //private List<> 

    public Player(Coordinate location){
        this.currentLocation = location;
        this.inventory = new Inventory<>();
    }

    //LOCATION
    //get currentLocation
    public Coordinate getLocation(){
        return currentLocation;
    }

    //checkFront
    public Coordinate checkForwardDirection(){
        int x = currentLocation.getRow() - 1;
        int y = currentLocation.getCol();

        Coordinate forwardDirection = new Coordinate(x, y);
        return forwardDirection;
    }
    //checkBack
    public Coordinate checkBackwardDirection(){
        int x = currentLocation.getRow() + 1;
        int y = currentLocation.getCol();

        Coordinate backwardDirection = new Coordinate(x, y);
        return backwardDirection;
    }

    //checkLeft
    public Coordinate checkLeftDirection(){
        int x = currentLocation.getRow();
        int y = currentLocation.getCol() - 1;

        Coordinate leftLocation = new Coordinate(x, y);
        return leftLocation;
    }
    //checkRight
    public Coordinate checkRightDirection(){
        int x = currentLocation.getRow();
        int y = currentLocation.getCol() + 1;

        Coordinate RightLocation = new Coordinate(x, y);
        return RightLocation;
    }

    //INVENTORY
    //add item to inventory
    public void addInventory(Item item){
        inventory.addItem(item);
    }

    //remove item to inventory
    public void remInventory(Item item){
        inventory.removeItem(item);
    }

    //view all item in inventory
    public void printInventory(){
        inventory.printItems(); 
    }



}
//Requirements
/*
Inventory:
Able to add and remove Items
Able to call Item methods
Able to enable/use items

Memory
Able to gain (and potentially lose) memory shards
Able to check and set memory shards (and their type) (Foundations, Ambitions, Personality)
*/
public class Player extends GameObject{
    private Coordinate currentLocation;
    private ObjectType type = ObjectType.PLAYER;

    private Inventory<Item> inventory;
    //private List<> 

    public Player(Coordinate location, int ID){
        super(ID);
        this.currentLocation = location;
        this.inventory = new Inventory<>();
    }


    //LOCATION
    //getLOCATION
    //get currentLocation
    public Coordinate getLocation(){
        return currentLocation;
    }

    //setLOCATION
    public void setLocation(Coordinate coordinate){
        currentLocation = coordinate;
    }

    //checkLOCATION
    //checkFront
    public GameObject checkForwardDirection(){
        int x = currentLocation.getRow() - 1;
        int y = currentLocation.getCol();

        Location forwardDirection = new Location(new Coordinate(x, y));
        GameObject atForwardLocation = forwardDirection.findID(forwardDirection);
        return atForwardLocation;
    }
    //checkBack
    public GameObject checkBackwardDirection(){
        int x = currentLocation.getRow() + 1;
        int y = currentLocation.getCol();

        Location backwardDirection = new Location(new Coordinate(x, y));
        GameObject atBackwardLocation = backwardDirection.findID(backwardDirection);
        return atBackwardLocation;
    }

    //checkLeft
    public GameObject checkLeftDirection(){
        int x = currentLocation.getRow();
        int y = currentLocation.getCol() - 1;

        Location leftLocation = new Location(new Coordinate(x, y));
        GameObject atLeftLocation = leftLocation.findID(leftLocation);
        return atLeftLocation;
    }
    //checkRight
    public GameObject checkRightDirection(){
        int x = currentLocation.getRow();
        int y = currentLocation.getCol() + 1;

        Location rightLocation = new Location(new Coordinate(x, y));
        GameObject atRightLocation = rightLocation.findID(rightLocation);
        return atRightLocation;
    }

    

    //changeLOCATION
    //Move LEFT
    public void moveLeft(){
        System.out.println("\nMoving Left\n");
        GameObject object = checkLeftDirection();
        object.Interact(this);
        currentLocation.
    }
    //Move RIGHT
    public void moveRight(){
        System.out.println("\nMoving Right\n");
        GameObject object = checkRightDirection();
        object.Interact(this);
    }
    //Move FORWARD
    public void moveForward(){
        System.out.println("\nMoving Forward\n");
        GameObject object = checkForwardDirection();
        object.Interact(this);
    }
    //Move BACKWARD
    public void moveBackward(){
        System.out.println("\nMoving Backward\n");
        GameObject object = checkBackwardDirection();
        object.Interact(this);
    }

    //INVENTORY
    //add item to inventory
    public void addInventory(Item item){
        System.out.println("Item added to inventory\n" + item + "\n");
        inventory.addItem(item);
    }

    //remove item to inventory
    public void remInventory(Item item){
        System.out.println("Item added to inventory\n" + item + "\n");
        inventory.removeItem(item);
    }

    //view all item in inventory
    public void printInventory(){
        inventory.printItems(); 
    }

    //Intreact implementation
    @Override
    public void Interact(Player player) { System.out.println("I am, THE PLAYER"); }


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
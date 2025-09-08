import Map.GameMap;

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
    public void translate(Coordinate currLocation, Coordinate goal){
        //Clear both locations in map
        //TODO ensure the item deletes it's location
        //TODO I don't like hardcoding values. Make a file for constants. 
        GameMaker.map.setCell(currLocation.getRow(), currLocation.getCol(), 100); //clear current location
        GameMaker.map.setCell(goal.getRow(), goal.getCol(), 100); //clear goal
        GameMaker.map.setCell(goal.getRow(), goal.getCol(), this.getID()); //add player to goal cell
    }
    //Move LEFT
    public void moveLeft(){
        GameObject object = checkLeftDirection(); //can of worms
        
        if(objVerified(object)){
            object.Interact(this); //Interact with what you got
            //change location from player pov
            currentLocation.setCol(currentLocation.getCol()-1);
            //change location from map pov
            Coordinate past = new Coordinate(currentLocation.getRow(), currentLocation.getCol() + 1); //create a coordinate wie past position
            translate(past, currentLocation); //use translate to change the map. 
            //change translate to accedpt coordinates, then create new ones
            //TODO is it neccessary for each item to store a copy of their location? 
        }else{
            System.out.println("You can't do that");
        }
        
    }
    //Move RIGHT
    public void moveRight(){
        GameObject object = checkRightDirection();
        if(objVerified(object)){
            object.Interact(this);
            currentLocation.setCol(currentLocation.getCol()+1);
            Coordinate past = new Coordinate(currentLocation.getRow(), currentLocation.getCol() - 1); //create a coordinate wie past position
            translate(past, currentLocation);
        }else{
            System.out.println("You can't do that");
        }
        
    }
    //Move FORWARD
    public void moveForward(){
        GameObject object = checkForwardDirection();
        if(objVerified(object)){
        //System.out.println("obj id is"+object.getID());
        object.Interact(this);
        currentLocation.setRow(currentLocation.getRow()-1);
        Coordinate past = new Coordinate(currentLocation.getRow() + 1, currentLocation.getCol()); //create a coordinate wie past position
        translate(past, currentLocation);
        }else{
            System.out.println("You can't do that");
        }
        

    }
    //Move BACKWARD
    public void moveBackward(){
        GameObject object = checkBackwardDirection();
        if(objVerified(object)){
            object.Interact(this);
            currentLocation.setRow(currentLocation.getRow()+1);
            Coordinate past = new Coordinate(currentLocation.getRow() - 1, currentLocation.getCol()); //create a coordinate wie past position
            translate(past, currentLocation);
        }else{
            System.out.println("You can't do that");
        }
        
    }
    
    //Tells you if you're fine to interact with an object based: 0 =Player;  62 = Walls
    private boolean objVerified(GameObject object) {
        int ID = object.getID();
        if(ID == 0 || ID == 62){
            return false;
        }
        return true;
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
Memory shard are items
*/
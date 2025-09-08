public class Item extends GameObject{
    private String name;
    private String message; 
    private Coordinate coordinate;
    private ObjectType type = ObjectType.ITEM;

    public Item(String name, String description, String effect, int ID, Coordinate coordinate){
        super(ID);
        this.name = name;
        this.coordinate = coordinate;
    }

    //getters 
    public String getName(){
        return name;
    }


    public Coordinate getLocation(){
        return coordinate;
    }

    //Overide to string
    @Override
    public String toString(){
        return "[Name: " + this.name + "| Description: " + "ID:" + this.getID() + "]" ;
    }

    public void Interact(Player player){
        player.addInventory(this);  
        GameMaker.objectList.remove(this.getID());
    }
}

//To do
/*
Info:
Name
Description
List of effects
^^^^^^^^No of items
*/
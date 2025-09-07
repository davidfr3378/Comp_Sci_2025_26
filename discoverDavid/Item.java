public class Item extends GameObject{
    private String name;
    private String description;
    private String effect; 
    private Coordinate coordinate;
    private ObjectType type = ObjectType.ITEM;

    public Item(String name, String description, String effect, int ID, Coordinate coordinate){
        super(ID);
        this.name = name;
        this.description = description;
        this.effect = effect;
        this.coordinate = coordinate;
    }

    //getters 
    public String getName(){
        return name;
    }

    public String getDescription(){
        return description;
    }

    public String getEffect(){
        return effect;
    }

    public Coordinate getLocation(){
        return coordinate;
    }

    //Overide to string
    @Override
    public String toString(){
        return "[Name: " + this.name + "| Description: " + this.description 
                            + "| Effect: " + this.effect + "ID:" + this.getID() + "]" ;
    }

    public void Interact(Player player){
        player.addInventory(this);  
        GameMaker.objects.remove(this);
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
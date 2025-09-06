import java.util.ArrayList; 

public class Item extends GameObject{
    private String name;
    private String description;
    private String effect; 
    private ObjectType type = ObjectType.ITEM;

    public Item(String name, String description, String effect, int ID){
        super(ID);
        this.name = name;
        this.description = description;
        this.effect = effect;
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

    //Overide to string
    @Override
    public String toString(){
        return "[Name: " + this.name + "| Description: " + this.description 
                            + "| Effect: " + this.effect + "]";
    }

    public void Interact(Player player){
        player.addInventory(this);  
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
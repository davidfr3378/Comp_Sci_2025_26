import java.util.ArrayList; 

public class Item{
    private String name;
    private String description;
    private String effect; 

    public Item(String name, String description, String effect){
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

}

//To do
/*
Info:
Name
Description
List of effects
^^^^^^^^No of items
*/
public abstract class GameObject {
    private int ID;
    private ObjectType type;

    GameObject(int ID){
        this.ID = ID;
    }

    //get ID
    public int getID(){
        return ID;
    }

    //set ID
    public void setID(int ID){
        this.ID = ID;
    }

    //get ID
    public ObjectType getType(){
        return type;
    } 

    //set ID
    public void setType(ObjectType type){
        this.type = type;
    }
    
    public abstract void Interact(Player player);


}

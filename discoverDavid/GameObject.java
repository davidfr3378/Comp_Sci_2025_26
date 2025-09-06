public abstract class GameObject {
    private int ID;

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

    public abstract void Interact(Player player);


}

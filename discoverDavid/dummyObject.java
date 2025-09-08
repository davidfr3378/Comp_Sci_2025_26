public class dummyObject extends GameObject {

    public dummyObject(int ID){
        super(ID);
    }


    @Override
    public void Interact(Player player) {
    }
    
    @Override
    public String toString(){
        return "[Name: Wall" + "| Description: a sturdy wall" + "| Effect: " + "Stop cheaters" + "ID:" + this.getID() + "]";
    }

    
}

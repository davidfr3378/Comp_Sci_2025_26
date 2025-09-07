public class dummyObject extends GameObject {

    public dummyObject(int ID){
        super(ID);
    }


    @Override
    public void Interact(Player player) {
        System.out.println("I'm an Object though a blank one");
    }
    
    @Override
    public String toString(){
        return "[Name: Wall" + "| Description: a sturdy wall" + "| Effect: " + "Stop cheaters" + "ID:" + this.getID() + "]";
    }
}

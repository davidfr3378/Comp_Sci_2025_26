import Map.GameMap;

public class Location {
    private Coordinate coordinate;
    private int ID;

    public Location(Coordinate coordinate){
        this.coordinate = coordinate;
        //findID(this);
    }

    /*
    I have been give a Coordinate on the map, and want to return the GameObject in that location
    I first check the Coordinate on the map and get the ID of the object there (the ID's are stored on the map)
    If the ID is registered in the objects list  (in GameMaker), I retunr the Object from that list
    If NOT, then I return a new GameObject with ID: 62, which in this context I have defined as empty (Blank)
    */ 
    public GameObject findID(Location location) {
        //System.out.println("Row of object ahead"+location.coordinate.getRow() + "Column of object ahead"+location.coordinate.getCol());
        int Id = GameMap.getCell(location.coordinate.getRow(), location.coordinate.getCol());
        //System.out.println(Id);
         for (GameObject o : GameMaker.objects){
            if (o.getID() == Id){
                return o;
            }
         }
         return new dummyObject(98);
    }
        

}

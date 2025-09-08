import Map.GameMap;
//TODO what is even the point of Location anymore? It's use has been overtaken. 
public class Location {
    private Coordinate coordinate;
    private int ID;

    public Location(Coordinate coordinate){
        this.coordinate = coordinate;
        //findID(this);
    }

    /*
    I have been given a location with a coordinate. I search for what ID on the map at that coordinate
    If it exist I search for an object with that ID, and if that exists I return it to the user. 
    Else I return a dummyObject (ID 99)
    */ 
    //Get Coordinate
    public Coordinate getCoordinate(){
        return this.coordinate;
    }

    //Set ID
    public void setID(int ID){
        this.ID = ID;
    }


    public GameObject findID(Location location) {
        int Id;
        try {
            Id = GameMap.getCell(location.coordinate.getRow(), location.coordinate.getCol());
        } catch (Exception e) {
            return new dummyObject(100);
        }
        
        try {
            return GameMaker.objectList.get(Id);
        } catch (Exception e) {
            return new dummyObject(100);
        }
  
    }

    //Override equals() and hashCode() for proper comparison in collections
    @Override
    public String toString() {
        return "Coordinates: " + coordinate + " Id: " + ID;
    }

    
        
}

public class GameMap {
    private char[][] map = {
                                {'#','#','#','#','#','#','#','b','#'},
                                {'#','m','b','b','m','b','m','b','b'},
                                {'#','b','m','#','b','#','#','#','#'}, 
                                {'#','b','b','#','m','#','b','b','b'}, 
                                {'#','m','b','#','b','#','b','b','b'}, 
                                {'#','b','#','#','b','#','#','#','#'}, 
                                {'#','b','b','b','b','b','m','b','m'}, 
                                {'#','m','b','#','m','#','#','#','#'}, 
                                {'b','b','b','#','b','#','b','b','b'},
                            };
    
    public GameMap(){
    }


    
    //Check what a coordinate holds
    public char checkCoordinate(int row, int col){
        return map[row][col];
    }

    //Check if a coordinate is wall
    public boolean isWall(int row, int col){
        if (map[row][col]== '#'){
            return true;
        }
        return false;
    }
}

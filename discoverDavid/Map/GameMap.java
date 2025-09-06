package Map;
public class GameMap {
    private static int[][] map;

    public GameMap(int rows, int cols) {
        map = new int[rows][cols];

        // initialize everything to BLANK
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                map[r][c] = 62;
            }
        }
    }

    public void setCell(int row, int col, int ID) {
        map[row][col] = ID;
    }

    public static int getCell(int row, int col) {
        return map[row][col];
    }

    public void printMap() {
        for (int r = 0; r < map.length; r++) {
            for (int c = 0; c < map[r].length; c++) {

                //If 
                if(map[r][c] == 0){
                    System.out.println("@ "); //You
                }else if(map[r][c] == 62){
                    System.out.print(". "); //Blank
                }else if(map[r][c] == 77){
                    System.out.print("# "); //Wall
                }else if(map[r][c] <= 20){
                    System.out.println("M "); //Mobs
                }else if(map[r][c] > 20 && map[r][c] <= 60){
                    System.out.println("I "); //Items
                }

            }
            System.out.println();
        }
    }
}

/*
 * private static char[][] map = {
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
 * 
 */
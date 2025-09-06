public class Coordinate {
    private final int row;
    private final int col;

    public Coordinate(int row, int col) {
        this.row = row;
        this.col = col;
    }

    public int getRow() {
        return row;
    }

    public int getCol() {
        return col;
    }

    //Override equals() and hashCode() for proper comparison in collections
    @Override
    public String toString() {
        return "(" + row + ", " + col + ")";
    }
}

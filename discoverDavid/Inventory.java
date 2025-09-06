import java.util.ArrayList;
import java.util.List;

public class Inventory<T extends Item> {
    private List<T> inventory = new ArrayList<>();

    public Inventory(){}

    //add items to inventory
    public void addItem(T item){
        this.inventory.add(item);
    }

    //remove items from the inventory
    public void removeItem(T item){
        this.inventory.remove(item);
    }

    //View all 
    public void printItems(){
        for(T item : inventory){
            System.out.println(item);
        }
    }
}


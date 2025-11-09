public interface Subject
{
    public int maxPedestrians { get;}

    void attach(Observer o);
    void retach(Observer o);
    void notify();

    
}
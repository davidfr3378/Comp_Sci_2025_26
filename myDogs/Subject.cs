public interface Subject
{
    void attach(Observer o);
    void retach(Observer o);
    void notify();

    
}
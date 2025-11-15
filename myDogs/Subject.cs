public interface Subject
{
    void attach(Dog d);
    void detach(Dog d);
    void notify();
}
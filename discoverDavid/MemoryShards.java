public class MemoryShards extends Item{
    private int memoryIndex;

    private static final String[] messages = {
        //Foundations & Capabilities
        "\nHi, I'm David! I'm in grade 12 and I was born in Enugu, Nigeria \n  I speak English fluently and am a passive/receptive Igbo billingual (that is I can hear very well but not speak)",
        "\nI have fair knowledge of Java and Python. \n I used Java to make this, and made mini data pipeline (specifically an Mini ETL pipeline) in Python. \n I am not artisitc at all, as you can tell from this Icebreaker project. \n",
        "\nAs for rmy other strengths, I am fairly atheletic. \\n" + 
                        " Although I don't look it, I'm very fast and have high anaerobic capacity. \\n",

        //Ambitions & Achievements
        "\nMy favourite subject in school is Computer Technology, with my favourite class OAT being Grade 10 Comp. Eng. \n Outside of strict school classes, My favourite subjects are Comp. Science and Math, although one of those fields seems to be dying...\n Going back to school, my second favourite elective is Computer Science. I shan't give reasons for any of my choices. Simply due to limited estate",
        "\nRegarding hopes, I hope to enter a good university, hoping to get a major in a degree both related to computr science and not tending towards automation and death by clanker, but it seems that won't happen",
        "\nBeyond this year, I probably have similar hopes to you all: \n" +
                "\tNot die yet" +
                "\t Get a degree I want, get a masters " +
                "\t Get an interesting job (do somthing fun with your life in your youth y'all)" +
                "\t Enter a marriage in service to God" +
                "\t Not die still" +
                "\t Idk what else (I'm writing these late (I'm an early bird) so by brain is fried rn)",
        //Personality & Preferences
        "For my hobbies, ",
    };
    public MemoryShards(String name, String description, String effect, int ID, Coordinate coordinate, int memoryIndex) {
        super(name, description, effect, ID, coordinate);
        this.memoryIndex = memoryIndex;
    }

    @Override
    public void Interact(Player player){
        System.out.println("YOu have aquired a memory shard\n\n" + messages[memoryIndex] + "\n");
    }
    
}

public class MemoryShard extends Item{
    private int memoryIndex;
    static int tab_const = 0;
    private static final String[] messages = {
        //Foundations & Capabilities
        "\t".repeat(tab_const) + "\nHi, I'm David! I'm in grade 10 and I was born in Enugu, Nigeria \n" +"\t".repeat(tab_const) + "  I speak English fluently and am a passive/receptive Igbo billingual (that is I can hear very well but not speak)",
        "\t".repeat(tab_const) + "\nI have fair knowledge of Java and Python. \n" +"\t".repeat(tab_const) + " I used Java to make this, and made mini data pipeline (specifically an Mini ETL pipeline) in Python. \n" +"\t".repeat(tab_const) + " I am not artisitc at all, as you can tell from this Icebreaker project. \n" +"\t".repeat(tab_const) + "",
        "\t".repeat(tab_const) + "\nAs for my other strengths, I am fairly atheletic. \n" +"\t".repeat(tab_const) + "" + 
                        " Although I don't look it, I'm very fast and have high anaerobic capacity. \n",

        //Ambitions & Achievements
        "\t".repeat(tab_const) + "\nMy favourite subject in school is Computer Technology, with my favourite class OAT being Grade 10 Comp. Eng. \n" +"\t".repeat(tab_const) + " Outside of strict school classes, My favourite subjects are Comp. Science and Math, although one of those fields seems to be dying...\n" +"\t".repeat(tab_const) + " Going back to school, my second favourite elective is Computer Science. I shan't give reasons for any of my choices. Simply due to limited estate",
        "\t".repeat(tab_const) + "\nRegarding hopes, I hope to enter a good university, hoping to get a major in a degree both related to computr science and not tending towards automation and death by clanker, but it seems that won't happen",
        "\t".repeat(tab_const) + "\nBeyond this year, I probably have similar hopes to you all: \n" +"\t".repeat(tab_const) + 
                "\tNot die yet\n" +"\t".repeat(tab_const) + "" +
                "\t Get a degree I want, get a masters \n" +"\t".repeat(tab_const) + "" +
                "\t Get an interesting job (do somthing fun with your life in your youth y'all)\n" +"\t".repeat(tab_const) + "" +
                "\t Enter a marriage in service to God\n" +"\t".repeat(tab_const) + "" +
                "\t Not die still\n" +"\t".repeat(tab_const) + "" +
                "\t Idk what else (I'm writing these late (I'm an early bird) so by brain is fried rn)\n",
        //Personality & Preferences
        "\t".repeat(tab_const) + "For my hobbies, I like biking (it's very relaxing), \n" +"\t".repeat(tab_const) + "learning (how can want to live if live if you don't want to learn). Cuurently studying the AoPS Volume 1 for the CSMC, \n" +"\t".repeat(tab_const) + "reading web novels (I've read or am curently reading: LOTM (), ORV(220 something), SGWOM(1033), SS(1800), Genetic Ascension(837), LITOW(637), TPR (1600), \n" +"\t".repeat(tab_const) + " and programming. ",
        "\t".repeat(tab_const) + "I'm not watching any shows right now because of school, but I watch a fair bit of anime and read a lot of manga, manhwa, manhua. \n" +"\t".repeat(tab_const) + " I don't consider any food in particular my favourite, but I tend to prefer either traditional food or fried and baked. (My heart is cooked)",
        "\t".repeat(tab_const) + "Fun facts: ",
        //Special 
        "You guys get to choose what you want to hear this time:\n" +  //9
        "\t 1. First time I ever heard a gunshot\n"+
        "\t 2. Boarding school pants incident\n",
        "You guys get to choose what you want to hear this time:\n" + //10
        "\t 1. First fight.\n" +
        "\t 2. Most recent embarrasing moment \n"

    };
    public MemoryShard(String name, String description, String effect, int ID, Coordinate coordinate, int memoryIndex) {
        super(name, description, effect, ID, coordinate);
        this.memoryIndex = memoryIndex;
    }

    @Override
    public void Interact(Player player){
        System.out.println("You have aquired a memory shard\n\n" + messages[memoryIndex] + "\n");
    }

    @Override
    public String toString(){
        return "Memory shard " + memoryIndex;
    }
    
}


namespace Index;

public class Challenge1 {

    public void IndexOfCapitals(string input){

        List<int> aList = new List<int>();

        for(int i = 0; i < input.Count(); i++){
            if(Char.IsUpper(input, i)){
                aList.Add(i);
            }
        }
        Console.Write("[{0}]", string.Join(",", aList));
    }

    public static void Main(string[] args){
        while(true){
            Console.Write("\nPlease enter a word [Enter 0 to exit Program]: ");
            string testString = Console.ReadLine()!;
            if(testString == "0"){
                break;
            }
            Challenge1 c1 = new Challenge1();

            c1.IndexOfCapitals(testString);
        }

    }
}

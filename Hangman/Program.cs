using System.Text;

Random rnd = new Random();
string[] words = new string[] { "file","horse","set","tango","left","juice","speak","world","dance","sting","double","return","csharp","parent","retail","dog","jumping","chew","hail","runtime","method","con","keyboard","flag","america","inbound","sale","clothing","object","syntax","gas","dirt","hold", "mango"};

StringBuilder sb = new StringBuilder("");
StringBuilder inputString = new StringBuilder("");
string inputStringS = inputString.ToString();
StringBuilder spaceString = new StringBuilder("");
sb.Insert(0,words[rnd.Next(0, words.Length - 1)]);
//sb.Insert(0,"file");
//Console.WriteLine(sb);
Console.WriteLine("Please input a letter: ");

//Variable intiliazation
int guessCount = 0;
int errorMax = 6;
int correctGuess = 0;


//This will display a nice _ _ _ _ _ for the string length
for(int i = 0;i < sb.Length; i++)
{
    spaceString.Insert(i, "_");
    
}
char[] spaceChar = spaceString.ToString().ToCharArray();

Console.WriteLine(spaceString);
// Console.WriteLine("");
string sbString = sb.ToString();
char[] sbChar= sbString.ToCharArray();
char inputStringNew;

while(guessCount < errorMax)
{   
    try{

    inputStringNew = Char.Parse(Console.ReadLine()!);
    }
    catch(FormatException ) {
        Console.WriteLine("Error! Invlid input, please input a single letter...");
        Console.Write(spaceString + "\n");
        continue;
    }
    
    if (!Char.IsLetter(inputStringNew)){
        Console.WriteLine("Error! This is not a letter, plese try again");
    

        continue;
    }
    if(inputStringS.Contains(inputStringNew)) {
        Console.WriteLine("Error! Already used this letter, please try again");
        continue;
    }
    else if(sbString.Contains(inputStringNew) ) {
        Console.WriteLine("Yes! You guessed correctly.");
        for(int i = 0; i < sb.Length; i++) {
            if (inputStringNew == sbChar[i]) {
                spaceString = spaceString.Remove(i, 1);
                spaceString = spaceString.Insert(i, inputStringNew);
                Console.Write(spaceString);
            }
            if(i+1 == sb.Length)
            Console.WriteLine("");
        }
        correctGuess++;
        inputString.Append(inputStringNew);
        inputStringS = inputString.ToString();
        if(correctGuess == sb.Length) {
            Console.WriteLine("Congrats!!! You Correctly Guessed The Word: " + sb);
            break;
        }
    }
    else
    {
    Console.WriteLine("You guessed Wrong!");
        guessCount++;
        Console.WriteLine("You have: " + (errorMax - guessCount) + " guesses remaining...");
        Console.Write(spaceString + "\n");
    }
    
}

if( guessCount == errorMax ){
Console.WriteLine("You failed. " + "The word was : " + sb);
}
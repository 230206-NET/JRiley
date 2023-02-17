// See https://aka.ms/new-console-template for more information

namespace RockPaperScissors;

public class RockPaperGame {
        public RockPaperGame() {
            string cpuMove = "";
            int userWins = 0, cpuWins = 0;

            //Creating an array of valid moves
            string[] validMoves = {"ROCK", "PAPER", "SCISSORS"};

            //Generating a random object to select a random move for the CPU
            Random rand = new Random();

            //Introduction + gathering user input
            Console.WriteLine("\n\t--WELCOME TO ROCK PAPER SCISSORS--" + "\n\nTHE FIRST PLAYER TO 3 VICTORIES WILL WIN THE GAME!");

            Console.WriteLine("How many games would you like to play? :");
            int games = int.Parse(Console.ReadLine()!);
            //Converting userInput to all Upper case to solve string matching issues



            //This method will return the cpu's random move
            string getCpuMove(){
            cpuMove = validMoves[rand.Next(0, validMoves.Length - 1)];
            //Console.WriteLine("The CPU chose: " + cpuMove);
            return cpuMove;
            }

            string calculateWin(){
                string message = "";
            if (userWins > cpuWins) {
                message = "\nCONGRATULATIONS!! YOU WON THE MATCH!!";
                return message;
            } 
            else {
                message = "\nSORRY! THE CPU WINS :(";
                return message;
            }
            }            

            string checkMove(string userIn){

                foreach (string item in validMoves)
                {
                    if (userIn.Equals(cpuMove)){
                Console.WriteLine(cpuMove);
                Console.WriteLine("\nYou tied this round, please try again!");
                break;
                    }
                    if (userIn.Equals(item)){
                        break;
                    }
                }
                return "\nInvalid Move, please try again..\n";
            }
            
            while(userWins < games && cpuWins < games) {

            cpuMove = getCpuMove();

            Console.WriteLine("\nPlease select your move (Rock, Paper, or Scissors): ");
            string userInput = Console.ReadLine()!;
            string userMove = userInput.ToUpper();


            // if (userMove.Equals(cpuMove)){
            //     Console.WriteLine("\nYou tied this round, try again!");
            //     continue;
            // }

            Console.WriteLine(cpuMove);
            Console.WriteLine(checkMove(userMove));


            switch(userMove) {
                case "ROCK":
                    if (cpuMove.Equals("PAPER")){
                        Console.WriteLine("YOU LOSE!! You chose " + userMove + " and CPU chose PAPER!");
                        cpuWins++;
                        break;
                    }
                    else {
                        Console.WriteLine("YOU WON!!! You chose " + userMove + " and CPU chose SCISSORS!");
                        userWins++;
                        break;
                    }
                case "PAPER":
                    if (cpuMove.Equals("SCISSORS")){
                        Console.WriteLine("YOU LOSE!! You chose " + userMove + " and CPU chose SCISSORS!");
                        cpuWins++;
                        break;
                    }
                    else {
                        Console.WriteLine("YOU WON!!! You chose " + userMove + " and CPU chose ROCK!");
                        userWins++;
                        break;
                    }        
                case "SCISSORS":
                    if (cpuMove.Equals("ROCK")){
                        Console.WriteLine("YOU LOSE!! You chose " + userMove + " and CPU chose ROCK!");
                        cpuWins++;
                        break;
                    }
                    else {
                        Console.WriteLine("YOU WON!!! You chose " + userMove + " and CPU chose PAPER!");
                        userWins++;
                        break;
                    }
                default: 
                    Console.WriteLine(checkMove(userInput));
                    break;
                
            }
            Console.WriteLine("The Score is: \n" + "-------------\n" + "USER: " + userWins + "\n-------------" + "\nCPU: " + cpuWins + "\n-------------");
            
            }
            Console.WriteLine(calculateWin());
        }
    }



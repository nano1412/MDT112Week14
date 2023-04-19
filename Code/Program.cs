using System;

class Program{
  static void Main(string[] args){
    //declear varible
    char[] table = new char[9]
      {'1','2','3',
       '4','5','6',
       '7','8','9'};
    int turn = 0;
    bool isWin = false;
    char playerLetter = 'X';
    int position = 0;
    int playerRound = (turn % 2)+1;

    //play Game
    for(;!isWin && turn <9;turn++){
      //Check who will play
      playerLetter = turn % 2 == 0? 'X':'O';
      playerRound = (turn % 2)+1;

      //Display and Input position
      DisplayPlayer(playerRound);
      DisplayTable(table);
      position = InputPosition(playerRound);

      //Check is position empty and valid
      if(IsPositionValid(position,table)){
        Console.Clear();
        table[position - 1] = playerLetter;
      } else {
        Console.Clear();
        InvalidPlacement(ref turn, playerLetter);
      }

      //Check is there any winner
      isWin = CheckWinCondition(table);
    }

    //Display winner and end the game
    DisplayTable(table);
    if(isWin){
      Console.WriteLine("Player {0} is win", playerRound);
    } else {
      Console.WriteLine("The game is draw");
    }
  }
  static void DisplayPlayer(int playerRound){
    Console.WriteLine("Player 1: X and Player 2: O");
    Console.WriteLine("---------------------------");
    Console.WriteLine("Player {0} turn", playerRound);
  }
  static void DisplayTable(char[]table){
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  {0}  |  {1}  |  {2}  ",table[0],table[1],table[2]);
    Console.WriteLine("     |     |     ");
    Console.WriteLine("-----|-----|-----");
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  {0}  |  {1}  |  {2}  ",table[3],table[4],table[5]);
    Console.WriteLine("     |     |     ");
    Console.WriteLine("-----|-----|-----");
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  {0}  |  {1}  |  {2}  ",table[6],table[7],table[8]);
    Console.WriteLine("     |     |     ");
  }

  static int InputPosition(int playerRound){
    Console.Write("Player {0} pick the spot:", playerRound);
    return int.Parse(Console.ReadLine());
  }

  static bool IsPositionValid(int position, char[] table){
    if(position > 9 || position < 1){
      return false;
    }
    return table[position - 1] != 'X' && table[position - 1] != 'O';
  }
  static void InvalidPlacement(ref int turn, char playerLetter){
    Console.WriteLine("Invalid input, Player {0} ({1}) please pick number between 1-9 and the position must be empty", (turn % 2)+1,playerLetter);
    turn--;
  }
  static bool CheckWinCondition(char[] table){
    return Checker(table[0],table[1],table[2]) || //horizontal top
           Checker(table[3],table[4],table[5]) || //horizontal middle
           Checker(table[6],table[7],table[8]) || //horizontal bottom
           Checker(table[0],table[3],table[6]) || //vertical left
           Checker(table[1],table[4],table[7]) || //vertical middle
           Checker(table[2],table[5],table[8]) || //vertical right
           Checker(table[0],table[4],table[8]) || //diagonal \
           Checker(table[2],table[4],table[6]);   //diagonal /
  }

  static bool Checker(char p1, char p2, char p3){
    return p1 == p2 && p2 == p3;
  }
}
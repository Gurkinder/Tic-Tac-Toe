using Assignment2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        public ArrayList moveOfP;           //Here we store the moveset of the Player
        public int move;                    //Here we store the number of moves completed in the game
        public ArrayList moveOfC;           //Here we store the moveset of the Computer
        Program()
        {
            // Here we initialize the variables in the game
            move = 0;
            moveOfC = new ArrayList();       
            moveOfP = new ArrayList();       
            //moveOfP and moveOfC contains 5 and 4 turns with 2 parameters which are x and y coordinates of the turn
            //which are sotred in a string with a space in between
        }
        public bool CheckWin()      
        {
            // here we check if win conditions of the player 
            bool endgame = false;
            if (moveOfP.Count > 2 || moveOfC.Count > 2)
            {
                if (moveOfP.Contains("1 1") && moveOfP.Contains("1 2") && moveOfP.Contains("1 3") ||
                    moveOfP.Contains("2 1") && moveOfP.Contains("2 2") && moveOfP.Contains("2 3") ||
                    moveOfP.Contains("3 1") && moveOfP.Contains("3 2") && moveOfP.Contains("3 3") ||
                    moveOfP.Contains("1 1") && moveOfP.Contains("2 1") && moveOfP.Contains("3 1") ||
                    moveOfP.Contains("1 2") && moveOfP.Contains("2 2") && moveOfP.Contains("3 2") ||
                    moveOfP.Contains("1 3") && moveOfP.Contains("2 3") && moveOfP.Contains("3 3") ||
                    moveOfP.Contains("1 1") && moveOfP.Contains("2 2") && moveOfP.Contains("3 3") ||
                    moveOfP.Contains("3 1") && moveOfP.Contains("2 2") && moveOfP.Contains("1 3"))
                {
                    Console.WriteLine("You Won, Game Over");
                    Console.WriteLine("Moves taken = {0}", move);
                    endgame = true;
                }
                // here we check if win conditions of the player 
                else if (moveOfC.Contains("1 1") && moveOfC.Contains("1 2") && moveOfC.Contains("1 3") ||
                    moveOfC.Contains("2 1") && moveOfC.Contains("2 2") && moveOfC.Contains("2 3") ||
                    moveOfC.Contains("3 1") && moveOfC.Contains("3 2") && moveOfC.Contains("3 3") ||
                    moveOfC.Contains("1 1") && moveOfC.Contains("2 1") && moveOfC.Contains("3 1") ||
                    moveOfC.Contains("1 2") && moveOfC.Contains("2 2") && moveOfC.Contains("3 2") ||
                    moveOfC.Contains("1 3") && moveOfC.Contains("2 3") && moveOfC.Contains("3 3") ||
                    moveOfC.Contains("1 1") && moveOfC.Contains("2 2") && moveOfC.Contains("3 3") ||
                    moveOfC.Contains("3 1") && moveOfC.Contains("2 2") && moveOfC.Contains("1 3"))
                {
                    Console.WriteLine("Computer Won, Game Over");
                    Console.WriteLine("Moves taken = {0}", move);
                    endgame = true;
                }
            }
            return endgame;
        }
        public void DisplayBoard()
        {
            // here we design the board
            Console.WriteLine("    1\t   2\t  3");
            for (int i = 1; i < 4; i++) {
                Console.WriteLine("  ----------------------");
                Console.WriteLine(i+" |      |      |      |");
                Console.WriteLine("  |      |      |      |");
                Console.WriteLine("  |      |      |      |");
                Console.WriteLine("  |      |      |      |");
            }
            Console.WriteLine("  ----------------------");
        }
        public bool CheckTurnC()
        {
            // here we validate the turn of Computer
            bool valid = true;
            for (int i = 0; i < move; i++)
            {
                //here we validate if the computer does not repeat its own turn
                if ((string)moveOfC[move] == (string)moveOfC[i])
                {
                    valid = false;
                }
                //Console.WriteLine("moveOfC[{0}] = {1}\nmoveOfC[{2}] = {3}",i, (string)moveOfC[i],j, (string)moveOfC[j]);
                //Console.ReadLine();
            }
            //here we validate if the computer does not repeat the player's turn
            for (int i = 0; i <= move; i++)
            {
                if ((string)moveOfC[move] == (string)moveOfP[i])
                {
                    valid = false;
                }
            }
            return valid;
        }
        public bool CheckTurnP()
        {
            // here we validate the turn of Player
            bool valid = true;
            for (int i = 0; i < move; i++)
            {
                //here we validate if the Player does not repeat its own turn
                if ((String)moveOfP[move] == (String)moveOfP[i])
                {
                    valid = false;
                }
                //Console.WriteLine("\ni[{0}] = {1}\n j[{2}] = {3}", i, (string)moveOfP[i], j, (string)moveOfP[j]);
                //Console.ReadLine();
                //here we validate if the Player does not repeat the Computer's turn
                if ((String)moveOfP[move] == (String)moveOfC[i])
                {
                    valid = false;
                    
                    Console.ReadLine();
                }
                //Console.WriteLine("\ni[{0}] = {1}\n j[{2}] = {3}", move, (string)moveOfP[move], i, (string)moveOfC[i]);
            }
            return valid;
        }
        public int GetX(String temp)
        {
            //here we extract x from string
            string[] res = temp.Split(' ');
            int x = int.Parse(res[0]);
            return x;
        }
        public int GetY(String temp)
        {
            //here we extract y from string
            string[] res = temp.Split(' ');
            int y = int.Parse(res[1]);
            return y;
        }
        public void RefreshBoard()
        {
            //here we refresh the board with the moves completed by the player 
            for (int i = 0; i < moveOfP.Count; i++)
            {
                String temp = (string)moveOfP[i];
                int x = GetX(temp);
                int y = GetY(temp);
                if (x == 1)
                {
                    if (y == 1)
                    {
                        MakeMoveX(4, 2);
                    }
                    else if (y == 2)
                    {
                        MakeMoveX(4, 7);
                    }
                    else if (y == 3)
                    {
                        MakeMoveX(4, 12);
                    }
                }
                if (x == 2)
                {
                    if (y == 1)
                    {
                        MakeMoveX(11, 2);
                    }
                    else if (y == 2)
                    {
                        MakeMoveX(11, 7);
                    }
                    else if (y == 3)
                    {
                        MakeMoveX(11, 12);
                    }
                }
                if (x == 3)
                {
                    if (y == 1)
                    {
                        MakeMoveX(18, 2);
                    }
                    else if (y == 2)
                    {
                        MakeMoveX(18, 7);
                    }
                    else if (y == 3)
                    {
                        MakeMoveX(18, 12);
                    }
                }
            }
            //here we refresh the board with the moves completed by the computer
            for (int i = 0; i < moveOfC.Count; i++)
            {
                String temp = (string)moveOfC[i];
                int x = GetX(temp);
                int y = GetY(temp);
                if (x == 1)
                {
                    if (y == 1)
                    {
                        MakeMoveP(4, 2);
                    }
                    else if (y == 2)
                    {
                        MakeMoveP(4, 7);
                    }
                    else if (y == 3)
                    {
                        MakeMoveP(4, 12);
                    }
                }
                if (x == 2)
                {
                    if (y == 1)
                    {
                        MakeMoveP(11, 2);
                    }
                    else if (y == 2)
                    {
                        MakeMoveP(11, 7);
                    }
                    else if (y == 3)
                    {
                        MakeMoveP(11, 12);
                    }
                }
                if (x == 3)
                {
                    if (y == 1)
                    {
                        MakeMoveP(18, 2);
                    }
                    else if (y == 2)
                    {
                        MakeMoveP(18, 7);
                    }
                    else if (y == 3)
                    {
                        MakeMoveP(18, 12);
                    }
                }
            }
        }
        public void DesignX(int x, int y)
        {
            //Here design the move of the player
            Console.SetCursorPosition(x, y++);
            Console.Write("\\  /");
            Console.SetCursorPosition(x, y++);
            Console.Write(" \\/ ");
            Console.SetCursorPosition(x, y++);
            Console.Write(" /\\ ");
            Console.SetCursorPosition(x, y++);
            Console.Write("/  \\");
            Console.SetCursorPosition(x, y++);
            Console.WriteLine();
        }
         public void MakeMoveX(int x, int y)
        {
            //Here we draw the move of the player on the board
            int xOC = Console.CursorLeft;
            int yOC = Console.CursorTop;
            DesignX(x, y);
            Console.SetCursorPosition(xOC, yOC);
        }
        public void MakeMoveP(int x, int y)
        {
            //Here we draw the move of the computer on the board
            int xOC = Console.CursorLeft;
            int yOC = Console.CursorTop;
            DesignP(x, y);
            Console.SetCursorPosition(xOC, yOC);
        }
        public void DesignP(int x, int y)
        {
            //Here design the move of the computer
            Console.SetCursorPosition(x, y++);
            Console.Write("  |  ");
            Console.SetCursorPosition(x, y++);
            Console.Write("--|--");
            Console.SetCursorPosition(x, y++);
            Console.Write("  |  ");
            Console.SetCursorPosition(x, y++);
            Console.Write("     ");
            Console.SetCursorPosition(x, y++);
            Console.WriteLine();
        }

    static void Main(string[] args)
        {
            Program p1 = new Program(); //Here we make an instance of Program
            bool play = true;       //play is the counter which will decide if the user wants to quit or play
            bool gameOn = true;     //game is the counter which will decide if the game is over or not
            while (play) {
                Console.Clear();            //Here we clear the console window
                p1.DisplayBoard();          //Here we display our design of the empty board
                p1.moveOfC.Clear();         //Here we clear the moveset of the Computer from the previous game
                p1.moveOfP.Clear();         //Here we clear the moveset of the Player from the previous game
                p1.move = 0;                //Here we clear the number of moves from the previous game to 0 for new game
                Console.WriteLine("Enter 'p' to play or 'q' to quit the game- ");
                char input= (char)Console.Read();       //Here we read the User's choice
                if (p1.move > 0)        //here we prevent errors from the readline in console
                {
                    Console.ReadLine();
                }
                switch (input)              
                {
                    case 'p':       //Here we begin the game
                        while (p1.move < 6 && gameOn == true)
                        {
                            Console.Clear();                //Here we clear the console window
                            p1.DisplayBoard();              //Here we display our design of the empty board
                            p1.RefreshBoard();              //Here we update the board with the different player moves
                            if (p1.CheckWin())              //Here we check for the win condition
                            {
                                break;
                            }
                            if (p1.move == 5)               //Here we check for the draw condition
                            {
                                Console.WriteLine("Its a Draw.\nGame Over");
                                Console.ReadLine();
                                Console.WriteLine("Moves taken = {0}", p1.move);
                                break;
                            }
                            Console.WriteLine("Follow the instructions to play the game-\n");   
                            Console.WriteLine("Its you turn\nEnter the X co-ordinate of your move-");
                            if (p1.move == 0)
                            {
                                Console.ReadLine();
                            }
                            string x = Console.ReadLine();      //Here we get the value of x form the player
                            int parseX;
                            int parseY;
                            if (int.TryParse(x, out parseX))        //Here we validate the value x
                            {
                                if (parseX == 1 || parseX == 2 || parseX == 3)
                                {            //Here we validate the value x
                                    Console.WriteLine("Enter the Y co-ordinate of your move-");
                                        string y = Console.ReadLine();          //Here we get the value of y form the player
                                    if (int.TryParse(y, out parseY))            //Here we validate the value y
                                    {
                                        if (parseY == 1 || parseY == 2 || parseY == 3)              //Here we validate the value y
                                        {
                                            Console.WriteLine("Press any key to continue", x, y);
                                            p1.moveOfP.Add(parseX + " " + parseY);              //Here we add the moves to the arraylist
                                            bool invalid = true;
                                            /*for (int i = 0; i <= p1.move ; i++)
                                            {
                                                for (int j = i+1; j <= p1.move ; j++)
                                                {
                                                    
                                                    Console.WriteLine("\ni[{0}] = {1}\n j[{2}] = {3}",i,(string)p1.moveOfP[i],j, (string)p1.moveOfP[j]);
                                                }
                                            }*/
                                            while (invalid)             //Here we validate the moves by the player
                                            {
                                                if (p1.CheckTurnP())
                                                {
                                                    invalid = false;
                                                }
                                                else
                                                {
                                                    //If the Player enters invalid input then he has to start from the beginning
                                                    Console.WriteLine("Invalid input, Game Over");
                                                    gameOn = false;
                                                    break;
                                                }
                                            }
                                            if (p1.move < 4) {              // here we limit moves of the computer to 4 and the player to 5
                                                Random r = new Random();
                                                int xOfC = r.Next(1, 4);        //Here we generate the moveset of the computer
                                                int yOfC = r.Next(1, 4);
                                                p1.moveOfC.Add(xOfC + " " + yOfC);         //Here we add the moveset of the 
                                                bool notValid = true;
                                                while (notValid)                //Here we validate the move of the computer
                                                {
                                                    if (p1.CheckTurnC())
                                                    {
                                                        notValid = false;
                                                    }
                                                    else
                                                    {
                                                        //Here we remove the previous value from the arraylist and then generate new 
                                                        //values and again run the check 
                                                        p1.moveOfC.Remove(xOfC + " " + yOfC);
                                                        xOfC = r.Next(1, 4);
                                                        yOfC = r.Next(1, 4);
                                                        p1.moveOfC.Add(xOfC + " " + yOfC);
                                                    }
                                                }
                                            }
                                            p1.move++;          //here we increment the number of moves
                                            Console.WriteLine("\nNumber of moves completed- {0}\n",p1.move);
                                            Console.ReadLine();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid value of y entered! Try again");
                                            Console.ReadLine();
                                        }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid value of x entered! Try again");
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid value of x entered! Try again");
                                Console.ReadLine();
                            }
                        }
                        break;
                    case 'q':
                        //Here we quit the program if the user inputs 'q'
                        Console.WriteLine("Program successfuly terminated.\n");
                        play = false;
                        Console.ReadLine();
                        break;
                    default:
                        // here we validate the user input
                        Console.WriteLine("\nInvalid Input entered! Please Try again\n");
                        Console.ReadLine();
                        break;
                }

                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }//This this the end of the main method
}//This this the end of the program
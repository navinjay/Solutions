using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackJack
{
    static class Constants
    {
        public const int winPoint=21;
        public const int computerCheckPoint = 17;

    }

    public class InputOutput
    {
        public int user = 0;
        public int userCard1 = 0;
        public int userCard2 = 0;
        public int userTurn = 0;
        public int comp = 0;
        public int compCard1 = 0;
        public int compCard2 = 0;
        public int compTurn = 0;
        public string checkOption = string.Empty;
        Random random = new Random();
        //Method to generate random numbers
        //input
        public int RandomCardValue()
        {
            return random.Next(1, 11);
        }

        //Result
        public string WinnerOrLoser(int userValue, int computerValue)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            if (userValue <= Constants.winPoint)
            {
                if (userValue == computerValue)
                    return ("Draw!");
                else if (userValue > computerValue)
                    return ("you have won!");
                else if (computerValue > userValue && computerValue <= Constants.winPoint)
                    return ("Computer has won!");
                else if (computerValue > Constants.winPoint)
                    return ("Computer Busted!");
                else
                    return ("");
            }
            else
                return ("you Busted!");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
    public class User:InputOutput
    {       
        //user first turn
        public void UserFirstCardDraw()
        {

            userCard1 = RandomCardValue();
            user += userCard1;

            userCard2 = RandomCardValue();
            user += userCard2;
            Console.Write("your cards:" + userCard1 + "+");
            Console.Write(" " + userCard2 + "=" + user);

            Console.WriteLine(Environment.NewLine);
        }
        //user remaining trns
        public void UserCardDrawn()
        {

            Console.WriteLine(UserChance(user));

        }
        
        public string UserChance(int userPoints)
        {
            user = userPoints;
            while (user < Constants.winPoint)
            {                
                Console.WriteLine("Do you want another card(y/n)?");
                String response = (Console.ReadLine().ToLower());
               checkOption= ValidateUserOption(response);
                if(checkOption=="no")
                {
                    break; 
                }
                if(checkOption=="invalid")
                {
                    continue;
                }               

            }
            
            if (user > Constants.winPoint)
            {
                return ("You have crossed 21");

            }
            return ("Now its computer's turn");
           
               
        }
        public string ValidateUserOption(string response)
        {
            if (response == "y")
            {
                userTurn = RandomCardValue();
                user += userTurn;
                Console.WriteLine("your Card:" + userTurn + "\n" + "your Total:" + user + "\n");
                return ("yes");
            }
            else if (response == "n")
            {
                return ("no");

            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please enter valid option");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                return ("invalid");

            }

        }
        

    }
    public  class Computer:User
    {       
        //computer first turn 
        public void ComputerFirstCardDraw()
        {

            compCard1 = RandomCardValue();
            comp += compCard1;

            compCard2 = RandomCardValue();
            comp += compCard2;
            Console.Write("Computer cards:" + compCard1 + "+");
            Console.Write(" " + compCard2 + "=" + comp);
            Console.WriteLine(Environment.NewLine);
        }
        //computer remaining trns
        public void ComputerCardDrawn()
        {
            if (ComputerChance(user))
            {
                Console.WriteLine("Comparing Scores.......");
                Console.WriteLine("Your Score :" + user);
                Console.WriteLine("Computer Score :" + comp + "\n");

                //check who has won

                Console.WriteLine(WinnerOrLoser(user, comp));
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You have busted!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        public bool ComputerChance(int userPoints)
        {
            user = userPoints;
            while (comp < Constants.computerCheckPoint && comp <= user && user <= Constants.winPoint)
            {
                compTurn = RandomCardValue();
                comp += compTurn;
                Console.WriteLine("computer takes card :" + compTurn + "\n");
            }
            if (user > Constants.winPoint)
                return false;
            else
                return true;

            
        }
       
    }
    
     public abstract class Game
    {       
         //main class
         public static void Main(string[] args)
         {
             Computer comObj = new Computer();
            try
            {
                //user first turn
                comObj.UserFirstCardDraw();

                //computer first turn
                comObj.ComputerFirstCardDraw();

                //user remaining turns
                comObj.UserCardDrawn();

                //computer remaining turns
                comObj.ComputerCardDrawn();
                
            }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);

             }
             Console.ReadLine();
        }
    }

}

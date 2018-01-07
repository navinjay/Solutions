using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackJack
{
     public class Game
    {
        // Declaring objects
         private int user = 0;
         private int comp = 0;
        private int userCard1=0;
        private int userCard2 = 0;
        private int compCard1=0;
        private int compCard2 = 0;
        private int userTurn = 0;
        private int compTurn = 0;
        Random random = new Random();
         //Method to generate random numbers
         public int RandomCardValue()
         {
            return random.Next(1, 11);
         }

         public void UserFirstCardDraw()
         {

             userCard1 = RandomCardValue();
             user += userCard1;

             userCard2 = RandomCardValue();
             user += userCard2;
             Console.Write("your cards:" + userCard1);
             Console.Write(" " + userCard2 + "=" + user);

             Console.WriteLine(Environment.NewLine);
         }
         public void ComputerFirstCardDraw()
         {

             compCard1 = RandomCardValue();
             comp +=compCard1;

             compCard2 = RandomCardValue();
             comp += compCard2;
             Console.Write("Computer cards:" + compCard1);
             Console.Write(" " + compCard2 + "=" + comp);
             Console.WriteLine(Environment.NewLine);
         }

         public void UserCardDrawn()
         {
             while (user < 21)
             {
                 Console.WriteLine("Do you want another card(y/n)?");
                 String response = (Console.ReadLine().ToLower());
                 if (response == "y")
                 {
                     userTurn = RandomCardValue();
                     user += userTurn;
                     Console.WriteLine("Hit:" + userTurn + "your Total is:" + user);
                 }
                 else if (response == "n")
                 {
                     break;
                 }
                 else { continue; }

             }
            
         }
         
         public void ComputerCardDrawn()
         {
             if (user <= 21)
             {
                 while (comp < 17 && comp <= user)
                 {
                     compTurn = RandomCardValue();
                     comp += compTurn;
                     Console.WriteLine("computer takes card :" + compTurn);

                 }
             }
            Console.WriteLine("Your Score :" + user);
            Console.WriteLine("Computer Score :"+comp);

            //check who has won

            Console.WriteLine(WinnerOrLoser(user, comp));




            
         }
         public string WinnerOrLoser(int userValue,int computerValue)
         {
             if (userValue <= 21)
             {
                 if (userValue == computerValue)
                     return ("Draw!");
                 else if (userValue > computerValue)
                     return ("you have won!");
                 else if (computerValue > userValue && computerValue <= 21)
                     return ("Computer has won!");
                 else if (computerValue > 21)
                     return ("Computer Busted!");
                 else
                     return ("");
             }
             else
                 return ("you Busted!");
         }

         //main class
        public static void Main(string[] args)
         {
             
            Game obj = new Game();

            
            try
            {
                //user first turn
                obj.UserFirstCardDraw();

                //computer first turn
                obj.ComputerFirstCardDraw();

                //user remaining turns
                obj.UserCardDrawn();
                //computer remaining turns
                obj.ComputerCardDrawn();
                
            }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);

             }
             Console.ReadLine();
        }
    }
}

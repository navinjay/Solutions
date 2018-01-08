using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using blackJack;
namespace blackJackTest
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void TestWinnerOrLoserDraw()
        {
            
            InputOutput result = new InputOutput();
            string expected=result.WinnerOrLoser(20, 20);
            string actual = "Draw!";
            Assert.AreEqual(expected, actual);      
        }
        [TestMethod]
        public void TestWinnerOrLoserUserWon()
        {
            InputOutput result = new InputOutput();
            string expected = result.WinnerOrLoser(21, 20);
            string actual = "you have won!";
            Assert.AreEqual(expected, actual); 
           
        }
        [TestMethod]
        public void TestWinnerOrLoserComputerWon()
        {
            InputOutput result = new InputOutput();
            string expected = result.WinnerOrLoser(18, 20);
            string actual = "Computer has won!";
            Assert.AreEqual(expected, actual); 
            
        }
        [TestMethod]
        public void TestWinnerOrLoserComputerBusted()
        {
            InputOutput result = new InputOutput();
            string expected = result.WinnerOrLoser(18, 22);
            string actual = "Computer Busted!";
            Assert.AreEqual(expected, actual); 
           
        }
   
        [TestMethod]
        public void TestWinnerOrLoserUserBusted()
        {
            InputOutput result = new InputOutput();
            string expected = result.WinnerOrLoser(22, 21);
            string actual = "you Busted!";
            Assert.AreEqual(expected, actual); 
            
        }
        [TestMethod]
        public void TestValidateUserOptionNo()
        {
            User result = new User();
            string expected = result.ValidateUserOption("n");
            string actual = "no";
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestValidateUserOptionInvalid()
        {
            User result = new User();
            string expected = result.ValidateUserOption("j");
            string actual = "invalid";
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestUserChanceCardBusted()
        {
            User result = new User();
            string expected = result.UserChance(22);
            string actual = "You have crossed 21";
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestComputerChanceUserBusted()
        {
            Computer result = new Computer();
            bool expected = result.ComputerChance(23);
            bool actual = false;
            Assert.AreEqual(expected, actual);

        }
       
       
    }
}

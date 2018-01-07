using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using blackJack;
namespace blackJackTest
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void TestDraw()
        {
            //Mock<Game> chk = new Mock<Game>();
            //chk.Setup(x => x.RandomUserCardValue("n")).Returns(4);

            Game obj = new Game();

            Assert.AreEqual(obj.WinnerOrLoser(20, 20), "Draw!");      
        }
        [TestMethod]
        public void TestUserWon()
        {
            
            Game obj = new Game();

            Assert.AreEqual(obj.WinnerOrLoser(21, 20), "you have won!");
        }
        [TestMethod]
        public void TestComputerWon()
        {

            Game obj = new Game();

            Assert.AreEqual(obj.WinnerOrLoser(18, 20), "Computer has won!");
        }
        [TestMethod]
        public void TestComputerBusted()
        {

            Game obj = new Game();

            Assert.AreEqual(obj.WinnerOrLoser(18, 22), "Computer Busted!");
        }
   
        [TestMethod]
        public void TestUserBusted()
        {

            Game obj = new Game();

            Assert.AreEqual(obj.WinnerOrLoser(22, 21), "you Busted!");
        }
       
    }
}

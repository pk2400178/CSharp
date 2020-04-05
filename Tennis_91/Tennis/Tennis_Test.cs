using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tennis
{
    [TestClass]
    public class Tennis_Test
    {
        TennisGame game = InitGame();
        private void AssertResult(string result)
        {
            Assert.AreEqual(game.GetScore(), result);
        }

        private static TennisGame InitGame()
        {
            return new TennisGame("Bob","Jack");
        }

        private void FirstPlayerHit(int hit)
        {
            for (int i = 0; i < hit; i++)
            {
                game.FirstPlayerScore();
            }
        }
        private void SecondPlayerHit(int hit)
        {
            for (int i = 0; i < hit; i++)
            {
                game.SecondPlayerScore();
            }
        }

        [TestMethod]
        public void Test_Love_ALL()
        {
            AssertResult("Love All");
        }

        [TestMethod]
        public void Test_Fifteen_Love()
        {
            FirstPlayerHit(1);
            AssertResult("Fifteen Love");
        }

        [TestMethod]
        public void Test_Thirty_Love()
        {
            FirstPlayerHit(2);
            AssertResult("Thirty Love");
        }
        [TestMethod]
        public void Test_Forty_Love()
        {
            FirstPlayerHit(3);
            AssertResult("Forty Love");
        }
        [TestMethod]
        public void Test_Love_Fifteen()
        {
            SecondPlayerHit(1);
            AssertResult("Love Fifteen");
        }
        [TestMethod]
        public void Test_Fifteen_All()
        {
            FirstPlayerHit(1);
            SecondPlayerHit(1);
            AssertResult("Fifteen All");
        }
        [TestMethod]
        public void Test_Thirty_All()
        {
            FirstPlayerHit(2);
            SecondPlayerHit(2);
            AssertResult("Thirty All");
        }
        [TestMethod]
        public void Test_Deuce()
        {
            FirstPlayerHit(3);
            SecondPlayerHit(3);
            AssertResult("Deuce");
        }
        [TestMethod]
        public void Test_Bob_Adv()
        {
            FirstPlayerHit(4);
            SecondPlayerHit(3);
            AssertResult("Bob Adv");
        }
        [TestMethod]
        public void Test_Jack_Adv()
        {
            FirstPlayerHit(3);
            SecondPlayerHit(4);
            AssertResult("Jack Adv");
        }
        [TestMethod]
        public void Test_Jack_Win()
        {
            FirstPlayerHit(3);
            SecondPlayerHit(5);
            AssertResult("Jack Win");
        }
        [TestMethod]
        public void Test_Bob_Win()
        {
            FirstPlayerHit(5);
            SecondPlayerHit(3);
            AssertResult("Bob Win");
        }
        [TestMethod]
        public void Test_Bob_WinGame()
        {
            FirstPlayerHit(4);
            SecondPlayerHit(1);
            AssertResult("Bob Win");
        }
    }
}
